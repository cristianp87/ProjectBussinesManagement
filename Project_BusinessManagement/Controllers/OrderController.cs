using Bll_Business;
using BO_BusinessManagement;
using Project_BusinessManagement.Filters;
using Project_BusinessManagement.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using IBusiness.Common;
using IBusiness.Management;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = "Administrador, Cajero")]
    [ConfigurationApp(pParameter: "IsRealizeOrder")]
    public class OrderController : Controller
    {
        #region Variables and Constants

        public ICustomer LCustomerFacade =
        FacadeProvider.Resolver<ICustomer>();

        public IInventory LInventory =
        FacadeProvider.Resolver<IInventory>();

        public readonly MParameter lParameter = new MParameter();

        public IOrder LOrder =
        FacadeProvider.Resolver<IOrder>();

        public IInvoiceItem LInvoiceItem =
        FacadeProvider.Resolver<IInvoiceItem>();

        public IInvoice LInvoice =
        FacadeProvider.Resolver<IInvoice>();

        public IProduct LiProduct =
        FacadeProvider.Resolver<IProduct>();
        #endregion

        // GET: Order
        public ActionResult Index(int pIdCustomer)
        {
            var lListOrder = this.LOrder.bll_GetListOrderByCustomer(pIdCustomer);
            return this.View(MOrder.MListOrder(lListOrder));
        }

        // GET: Order
        public ActionResult DashBoardOrder()
        {
            return this.View();
        }

        [HttpPost]
        public JsonResult GetCustomer(int pIdtypeIdentification, string pNoIdentification)
        {
            var lCustomer = this.LCustomerFacade.bll_GetCustomerByIdentification(pNoIdentification, pIdtypeIdentification);
            if (lCustomer.LException != null)
            {

                return this.Json(new { Success = false, Message = "ErrorDao! " + lCustomer.LMessageDao + " " + lCustomer.LException });
            }else if (lCustomer.LNameCustomer != null)
            {
                return this.Json(new { Success = true, Content = lCustomer });
            }
            else
            {
                return this.Json(new { Success = false, Message = "El cliente no existe en la base de datos." });
            }
        }

        [HttpPost]
        public JsonResult GetInventory()
        {
            var lListBoInventory = this.LInventory.bll_GetAllInventory();
            return this.Json(MInventory.MListInventory(lListBoInventory));
        }

        [HttpPost]
        public JsonResult GetTypeIdentification()
        {
            var lListTypeIdentification = Bll_TypeIdentification.bll_getListTypeIdentification();
            return this.Json(MTypeIdentification.MListAllTypeIdentification(lListTypeIdentification));
        }

        [HttpPost]
        public JsonResult GetOrderItem(int idProduct)
        {
            try
            {
                var lProduct = this.LiProduct.bll_GetProductById(idProduct);
                if(lProduct.LException != null)
                {                   
                    return this.Json(new { Success = false, Message = "ErrorDao! " + lProduct.LMessageDao + " " + lProduct.LException});
                }
                return lProduct.LCdProduct != null ? this.Json(new { Success = true, Content = MProduct.MProductById(lProduct) }) : this.Json(new { Success = false, Message = "El Producto no existe en la base de datos." });
            }catch(Exception e)
            {
                return this.Json(new { Success = false, Message = "Error! " + e.Message });
            }
            
            
        }

        

        [ConfigurationApp(pParameter: "CreateOrder")]
        // GET: Order/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Order/Create
        [HttpPost]
        public JsonResult Create(Bo_Order pOrder)
        {
            try
            {                      
                var lResult = this.LOrder.bll_InsertOrder(pOrder.LInventory.LIdInventory, pOrder.LCustomer.LIdCustomer, Bll_UtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectOrder).LIdObject, Bll_UtilsLib.bll_getStatusApproByObject(Bll_UtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectOrder).LIdObject).LIdStatus, pOrder.LListOrderItem, this.lParameter.lIsModuleInventory, Bll_UtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectOrderItem).LIdObject, Bll_UtilsLib.bll_getStatusApproByObject(Bll_UtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectOrderItem).LIdObject).LIdStatus);
                var lIdOrder = 0;
                if(int.TryParse(lResult, out lIdOrder))
                {
                    var lIdInvoice = 0;
                    var lListInvoiceItem = this.LInvoiceItem.bll_ChangeOrderItemToInvoiceItem(pOrder.LListOrderItem, Bll_UtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectInvoiceItem));
                    lResult = this.LInvoice.bll_InsertInvoiceAll(pOrder.LCustomer.LIdCustomer, lIdOrder, Bll_UtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectInvoice).LIdObject, lListInvoiceItem);
                    return int.TryParse(lResult, out lIdInvoice) ? this.Json(new { Success = true, Content = lIdInvoice }) : this.Json(new { Success = false, Content = lResult });
                }
                else
                {
                    return this.Json(new { Success = false, Content = lResult });
                }                
            }
            catch (Exception e)
            {
                return this.Json(new { Success = false, Message = "Error! " + e.Message });
            }
        }      
    }
}
