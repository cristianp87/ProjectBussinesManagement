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
        public JsonResult GetInventory()
        {
            List<Bo_Inventory> lListBoInventory = new List<Bo_Inventory>();
            lListBoInventory = Bll_Inventory.bll_GetAllInventory();
            return Json(Models.MInventory.MListInventory(lListBoInventory));
        }

        [HttpPost]
        public JsonResult GetOrderItem(int idProduct)
        {
            Bo_Product lProduct= new Bo_Product();
            lProduct = Bll_Product.bll_GetProductById(idProduct);
            return Json(Models.MProduct.MProductById(lProduct));
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
