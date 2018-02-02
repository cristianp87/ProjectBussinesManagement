using Bll_Business;
using BO_BusinessManagement;
using Project_BusinessManagement.Filters;
using Project_BusinessManagement.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = "Administrador")]
    [ConfigurationApp(pParameter: "IsRealizeOrder")]
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index(int pIdCustomer)
        {
            List<Bo_Order> lListOrder = new List<Bo_Order>();
            lListOrder = Bll_Order.bll_GetListOrderByCustomer(pIdCustomer);
            return View(MOrder.MListOrder(lListOrder));
        }

        // GET: Order
        public ActionResult DashBoardOrder()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCustomer(int pIdtypeIdentification, string pNoIdentification)
        {

            Bo_Customer lCustomer= new Bo_Customer();
            lCustomer = Bll_Customer.bll_GetCustomerByIdentification(pNoIdentification, pIdtypeIdentification);
            if (lCustomer.LException != null)
            {

                return Json(new { Success = false, Message = "ErrorDao! " + lCustomer.LMessageDao + " " + lCustomer.LException });
            }else if (lCustomer.LNameCustomer != null)
            {
                return Json(new { Success = true, Content = lCustomer });
            }
            else
            {
                return Json(new { Success = false, Message = "El cliente no existe en la base de datos." });
            }
        }

        [HttpPost]
        public JsonResult GetInventory()
        {
            List<Bo_Inventory> lListBoInventory = new List<Bo_Inventory>();
            lListBoInventory = Bll_Inventory.bll_GetAllInventory();
            return Json(Models.MInventory.MListInventory(lListBoInventory));
        }

        [HttpPost]
        public JsonResult GetTypeIdentification()
        {
            List<Bo_TypeIdentification> lListTypeIdentification = new List<Bo_TypeIdentification>();
            lListTypeIdentification = Bll_TypeIdentification.bll_getListTypeIdentification();
            return Json(Models.MTypeIdentification.MListAllTypeIdentification(lListTypeIdentification));
        }

        [HttpPost]
        public JsonResult GetOrderItem(int idProduct)
        {
            try
            {
                Bo_Product lProduct = new Bo_Product();
                lProduct = Bll_Product.bll_GetProductById(idProduct);
                if(lProduct.LException != null)
                {
                    
                    return Json(new { Success = false, Message = "ErrorDao! " + lProduct.LMessageDao + " " + lProduct.LException});
                }
                if (lProduct.LCdProduct != null)
                {
                    return Json(new { Success = true, Content = Models.MProduct.MProductById(lProduct) });
                }
                else
                {
                    return Json(new { Success = false, Message = "El Producto no existe en la base de datos." });
                }
            }catch(Exception e)
            {
                return Json(new { Success = false, Message = "Error! " + e.Message });
            }
            
            
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [ConfigurationApp(pParameter: "CreateOrder")]
        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public JsonResult Create(Bo_Order pOrder)
        {
            try
            {              
                var lResult = Bll_Order.bll_InsertOrder(pOrder.LInventory.LIdInventory, pOrder.LCustomer.LIdCustomer, Bll_UtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectOrder).LIdObject, Bll_UtilsLib.bll_getStatusApproByObject(Bll_UtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectOrder).LIdObject).LIdStatus, pOrder.LListOrderItem, Bll_UtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectOrderItem).LIdObject, Bll_UtilsLib.bll_getStatusApproByObject(Bll_UtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectOrderItem).LIdObject).LIdStatus);
                int lIdOrder = 0;
                if(int.TryParse(lResult, out lIdOrder))
                {
                    int lIdInvoice = 0;
                    List<Bo_InvoiceItem> lListInvoiceItem = Bll_InvoiceItem.bll_ChangeOrderItemToInvoiceItem(pOrder.LListOrderItem, Bll_UtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectInvoiceItem));
                    lResult = Bll_Invoice.bll_InsertInvoiceAll(pOrder.LCustomer.LIdCustomer, lIdOrder, Bll_UtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectInvoice).LIdObject, lListInvoiceItem);
                    if(int.TryParse(lResult, out lIdInvoice))
                        return Json(new { Success = true, Content = lIdInvoice });
                    else
                        return Json(new { Success = false, Content = lResult });
                }
                else
                {
                    return Json(new { Success = false, Content = lResult });
                }                
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Error! " + e.Message });
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
