using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bll_Business;
using BO_BusinessManagement;

namespace Project_BusinessManagement.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
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
            return Json(Models.MCustomer.MCustomerById(lCustomer));
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

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public JsonResult Create(List<Models.MOrderItem> pListItems, Models.MOrder pOrder)
        {
            try
            {
                var o = 1;

                return Json("Index");
            }
            catch
            {
                return Json("d");
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
