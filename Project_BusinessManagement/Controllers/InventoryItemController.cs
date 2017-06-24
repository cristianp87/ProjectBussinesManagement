using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bll_Business;
using BO_BusinessManagement;

namespace Project_BusinessManagement.Controllers
{
    public class InventoryItemController : Controller
    {
        // GET: InventoryItem
        public ActionResult Index(int id)
        {
            List<Bo_InventoryItem> lListInventoryItem = new List<Bo_InventoryItem>();
            lListInventoryItem = Bll_InventoryItem.bll_GetInventoryItemsByIdInventory(id);
            ViewData["LIdInventory"] = id;
            return View(Models.MInventoryItem.MListInventoryItem(lListInventoryItem));
        }

        // GET: InventoryItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InventoryItem/Create
        public ActionResult Create(int idInventory)
        {         
            return View(Models.MInventoryItem.MInventoryEmpty(idInventory));
        }

        // POST: InventoryItem/Create
        [HttpPost]
        public ActionResult Create(int idInventory, Models.MInventoryItem pMInventoryItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string lMessage = Bll_InventoryItem.bll_InsertInventoryItem(idInventory, Convert.ToInt32(Request.Form["LProduct.LIdProduct"].ToString()), Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString()), Request.Form["LStatus.LIdStatus"].ToString(), Convert.ToDecimal(Request.Form["QtySellable"].ToString()), Convert.ToDecimal(Request.Form["QtyNonSellable"].ToString()));
                    if (lMessage == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        EmptyInventoryItem(pMInventoryItem);
                        pMInventoryItem.LMessageException = lMessage;
                        return View(pMInventoryItem);
                    }

                }
                else
                {
                    EmptyInventoryItem(pMInventoryItem);
                    return View(pMInventoryItem);
                }

            }
            catch (Exception e)
            {
                EmptyInventoryItem(pMInventoryItem);
                pMInventoryItem.LMessageException = e.Message;
                return View(pMInventoryItem);
            }
        }

        private static Models.MInventoryItem EmptyInventoryItem(Models.MInventoryItem pMInventoryItem)
        {
            pMInventoryItem.LListStatus = new List<SelectListItem>();
            pMInventoryItem.LListProduct = new List<SelectListItem>();
            pMInventoryItem.LListStatus = Models.MStatus.MListAllStatus(Bll_Status.Bll_getListStatusByIdObject(pMInventoryItem.LObject.LIdObject));
            pMInventoryItem.LListProduct = Models.MProduct.MListAllProduct(Bll_Product.bll_GetAllProduct());
            return pMInventoryItem;
        }

        // GET: InventoryItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventoryItem/Edit/5
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

        // GET: InventoryItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventoryItem/Delete/5
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
