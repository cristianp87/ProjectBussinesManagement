using System;
using System.Web.Mvc;
using BO_BusinessManagement;
using IBusiness.Common;
using IBusiness.Management;
using Project_BusinessManagement.Filters;
using Project_BusinessManagement.Models;
using Project_BusinessManagement.Models.Mappers;
using Project_BusinessManagement.Models.Enums;
using System.Linq;
using Project_BusinessManagement.Extensibles;

namespace Project_BusinessManagement.Controllers
{
    public class IndirectOrderController : Controller
    {
        // GET: IndirectOrder
        #region Variables and Constants

        public ICustomer LCustomerFacade =
        FacadeProvider.Resolv<ICustomer>();

        public IInventory LInventory =
        FacadeProvider.Resolv<IInventory>();

        public readonly MParameter LParameter = new MParameter();

        public IOrder LOrder =
        FacadeProvider.Resolv<IOrder>();

        public IInvoiceItem LInvoiceItem =
        FacadeProvider.Resolv<IInvoiceItem>();

        public IInvoice LInvoice =
        FacadeProvider.Resolv<IInvoice>();

        public IProduct LiProduct =
        FacadeProvider.Resolv<IProduct>();

        public ITypeIdentification LiTypeIdentification =
        FacadeProvider.Resolv<ITypeIdentification>();

        public IUtilsLib LiUtilsLib =
        FacadeProvider.Resolv<IUtilsLib>();
        #endregion

        // GET: Order
        public ActionResult Index(int pIdCustomer)
        {
            var lListOrder = this.LOrder.bll_GetListOrderByCustomer(pIdCustomer);
            return this.View(lListOrder.MListOrder());
        }

        [HttpPost]
        public ActionResult Index(int pIdCustomer, string pSearchName)
        {
            var lListOrder = this.LOrder.bll_GetListOrderByCustomer(pIdCustomer);
            if (string.IsNullOrEmpty(pSearchName))
                return this.View(lListOrder.MListOrder());
            lListOrder = lListOrder.Where(s => s.LInventory.LNameInventory.ToUpper().Contains(pSearchName.ToUpper())).ToList();
            return this.View(lListOrder.MListOrder());
        }

        // GET: Order
        public ActionResult DashBoardIndirectOrder()
        {
            return this.View();
        }

        [HttpPost]
        public JsonResult GetCustomer(int pIdtypeIdentification, string pNoIdentification)
        {
            var lCustomer = this.LCustomerFacade.bll_GetCustomerByIdentification(pNoIdentification, pIdtypeIdentification);
            if (lCustomer.LException != null)
            {

                return this.Json(new { Success = false, Message = CodesError.LMsgErroDao + lCustomer.LMessageDao + EMessages.LSpace + lCustomer.LException });
            }
            if (lCustomer.LNameCustomer != null && lCustomer.LStatus.LIdStatus.ValidateStatus())
            {
                return this.Json(new { Success = true, Content = lCustomer });
            }
            return this.Json(new { Success = false, Message = CodesError.LMsgClientDontExists });
        }

        [HttpPost]
        public JsonResult GetInventory()
        {
            var lListInventory = this.LInventory.bll_GetAllInventory().Where(x => x.LStatus.LIdStatus.ValidateStatus()).ToList();
            return this.Json(lListInventory.MListInventory());
        }

        [HttpPost]
        public JsonResult GetTypeIdentification()
        {
            var lListTypeIdentification = this.LiTypeIdentification.bll_getListTypeIdentification();
            return this.Json(lListTypeIdentification.MListAllTypeIdentification());
        }

        [HttpPost]
        public JsonResult GetOrderItem(int idProduct)
        {
            try
            {
                var lProduct = this.LiProduct.bll_GetProductById(idProduct);
                if (!lProduct.LStatus.LIdStatus.ValidateStatus())
                    lProduct = new BoProduct();
                if (lProduct.LException != null)
                    return this.Json(new { Success = false, Message = CodesError.LMsgErroDao + lProduct.LMessageDao + EMessages.LSpace + lProduct.LException });
                return lProduct.LCdProduct != null ? this.Json(new { Success = true, Content = lProduct.MProductById() }) : this.Json(new { Success = false, Message = CodesError.LMsgProductDontExists });
            }
            catch (Exception e)
            {
                return this.Json(new { Success = false, Message = CodesError.LMsgError + e.Message });
            }


        }


        // POST: Order/Create
        [HttpPost]
        public JsonResult Create(BoOrder pOrder)
        {
            try
            {
                var lResult = this.LOrder.bll_InsertOrder(pOrder.LInventory.LIdInventory, pOrder.LCustomer.LIdCustomer, this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectOrder).LIdObject, this.LiUtilsLib.bll_getStatusInProByObject(this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectOrder).LIdObject).LIdStatus, pOrder.LListOrderItem, this.LParameter.LIsModuleInventory, this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectOrderItem).LIdObject, this.LiUtilsLib.bll_getStatusApproByObject(this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectOrderItem).LIdObject).LIdStatus);
                int lIdOrder;
                //if (int.TryParse(lResult, out lIdOrder))
                //{
                    //int lIdInvoice;
                    //var lListInvoiceItem = this.LInvoiceItem.bll_ChangeOrderItemToInvoiceItem(pOrder.LListOrderItem, this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectInvoiceItem));
                    //lResult = this.LInvoice.bll_InsertInvoiceAll(pOrder.LCustomer.LIdCustomer, lIdOrder, this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectInvoice).LIdObject, lListInvoiceItem);
                    return int.TryParse(lResult, out lIdOrder) ? this.Json(new { Success = true, Content = lIdOrder }) : this.Json(new { Success = false, Content = lResult });
                //}
                //return this.Json(new { Success = false, Content = lResult });
            }
            catch (Exception e)
            {
                return this.Json(new { Success = false, Message = CodesError.LMsgError + e.Message });
            }
        }
    }
}