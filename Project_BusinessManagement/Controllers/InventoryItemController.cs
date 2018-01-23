using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bll_Business;
using BO_BusinessManagement;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = "Administrador")]
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
            Bo_InventoryItem lOInventoryItem = new Bo_InventoryItem();
            lOInventoryItem = Bll_InventoryItem.bll_GetInventoryItemById(id);
            return View(Models.MInventoryItem.MInventoryItemById(lOInventoryItem));
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
                ModelState.Remove("LProduct.LNameProduct");
                ModelState.Remove("LProduct.LCdProduct");
                if (ModelState.IsValid)
                {
                    string lMessage = Bll_InventoryItem.bll_InsertInventoryItem(idInventory, Convert.ToInt32(Request.Form["LProduct.LIdProduct"].ToString()), Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString()), Request.Form["LStatus.LIdStatus"].ToString(), Convert.ToDecimal(Request.Form["LQtySellable"].ToString()), Convert.ToDecimal(Request.Form["LQtyNonSellable"].ToString()));
                    if (lMessage == null)
                    {
                        return RedirectToAction("Index", new { id = idInventory});
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

        

        // GET: InventoryItem/Edit/5
        public ActionResult Edit(int id)
        {
            Bo_InventoryItem lOInventoryItem = new Bo_InventoryItem();
            lOInventoryItem = Bll_InventoryItem.bll_GetInventoryItemById(id);
            return View(Models.MInventoryItem.MInventoryItemById(lOInventoryItem));
        }

        // POST: InventoryItem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.MInventoryItem pMInventoryItem)
        {
            try
            {
                Models.MInventoryItem lInventoryItem = new Models.MInventoryItem();
                ModelState.Remove("LProduct.LNameProduct");
                ModelState.Remove("LProduct.LCdProduct");
                if (ModelState.IsValid)
                {
                    string lMessage = Bll_InventoryItem.bll_UpdateInventoryITem(id, Convert.ToInt32(Request.Form["LInventory.LIdInventory"].ToString()), Convert.ToInt32(Request.Form["LProduct.LIdProduct"].ToString()), Convert.ToDecimal(Request.Form["LQtySellable"].ToString()), Convert.ToDecimal(Request.Form["LQtyNonSellable"].ToString()), Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString()), Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return RedirectToAction("Index", new { id = pMInventoryItem.LInventory.LIdInventory });
                    }
                    else
                    {                       
                        return View(CurrentInventoryItem(lInventoryItem, pMInventoryItem, id, lMessage, pMInventoryItem.LInventory.LIdInventory));
                    }

                }
                else
                {                   
                    return View(CurrentInventoryItem(lInventoryItem, pMInventoryItem, id, "Debe completar los campos obligatorios", pMInventoryItem.LInventory.LIdInventory));
                }

            }
            catch (Exception e)
            {
                Models.MInventoryItem lInventoryItemExc = new Models.MInventoryItem();              
                return View(CurrentInventoryItem(lInventoryItemExc, pMInventoryItem, id, e.Message, pMInventoryItem.LInventory.LIdInventory));
            }
        }

        // GET: InventoryItem/Delete/5
        public ActionResult Delete(int id)
        {
            Bo_InventoryItem lOInventoryItem = new Bo_InventoryItem();
            lOInventoryItem = Bll_InventoryItem.bll_GetInventoryItemById(id);
            return View(Models.MInventoryItem.MInventoryItemById(lOInventoryItem));
        }

        // POST: InventoryItem/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Models.MInventoryItem pMInventoryItem)
        {
            try
            {
                string lMessage = Bll_InventoryItem.bll_DeleteInventoryItem(id);
                if(lMessage == null)
                {
                    return RedirectToAction("Index", new { id = pMInventoryItem.LInventory.LIdInventory });
                }
                else
                {
                    pMInventoryItem.LMessageException = lMessage;
                    return View(pMInventoryItem);
                }
                
            }
            catch(Exception e)
            {
                pMInventoryItem.LMessageException = e.Message;
                return View();
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

        private static Models.MInventoryItem CurrentInventoryItem(Models.MInventoryItem pMInventoryItem, Models.MInventoryItem pMInventoryOldItem, int id, string pMessageException, int pIdInventory)
        {
            pMInventoryItem = pMInventoryOldItem;
            Bo_Inventory lObInventory = new Bo_Inventory();
            pMInventoryItem.LListStatus = new List<SelectListItem>();
            pMInventoryItem.LListProduct = new List<SelectListItem>();
            pMInventoryItem.LListStatus = Models.MStatus.MListAllStatus(Bll_Status.Bll_getListStatusByIdObject(pMInventoryItem.LObject.LIdObject));
            pMInventoryItem.LListProduct = Models.MProduct.MListAllProduct(Bll_Product.bll_GetAllProduct());
            pMInventoryItem.LInventory = new Models.MInventory();
            lObInventory = Bll_Inventory.bll_GetInventoryById(pIdInventory);
            pMInventoryItem.LInventory.LIdInventory = lObInventory.LIdInventory;
            pMInventoryItem.LInventory.LNameInventory = lObInventory.LNameInventory;
            pMInventoryItem.LMessageException = pMessageException;
            return pMInventoryItem;
        }
    }
}
