using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bll_Business;
using BO_BusinessManagement;
using Project_BusinessManagement.Models;

namespace Project_BusinessManagement.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            List<Bo_Inventory> lListBoInventory = new List<Bo_Inventory>();
            lListBoInventory = Bll_Inventory.bll_GetAllInventory();
            return Json(Models.MInventory.MListInventory(lListBoInventory));
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            return View(Models.MInventory.MInventoryEmpty());
        }

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult Create(Models.MInventory pMInventory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string lMessage = Bll_Inventory.bll_InsertInventory(Request.Form["LNameInventory"].ToString(), Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString()), Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ListEmptyInventory(pMInventory);
                        pMInventory.LMessageException = lMessage;
                        return View(pMInventory);
                    }

                }
                else
                {
                    ListEmptyInventory(pMInventory);
                    return View(pMInventory);
                }

            }
            catch (Exception e)
            {
                ListEmptyInventory(pMInventory);
                pMInventory.LMessageException = e.Message;
                return View(pMInventory);
            }
        }

        private void ListEmptyInventory(MInventory pMInventory)
        {
            pMInventory.LListStatus = new List<SelectListItem>();
            pMInventory.LListStatus = Models.MStatus.MListAllStatus(Bll_Status.Bll_getListStatusByIdObject(pMInventory.LObject.LIdObject));
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            Bo_Inventory lInventory = new Bo_Inventory();
            lInventory = Bll_Inventory.bll_GetInventoryById(id);
            return View(Models.MInventory.MInventoryById(lInventory));
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.MInventory pMInventory)
        {
            try
            {
                Models.MInventory lMInventory = new Models.MInventory();
                if (ModelState.IsValid)
                {
                    string lMessage = Bll_Inventory.bll_UpdateInventory(id, Request.Form["LNameInventory"].ToString(), Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString()), Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(CurrentInventory(lMInventory, pMInventory, id, lMessage));
                    }

                }
                else
                {
                    
                    return View(CurrentInventory(lMInventory, pMInventory, id, "Hay Campos que deben ser llenados."));
                }
            }
            catch (Exception e)
            {
                Models.MInventory lMInventory = new Models.MInventory();
                return View(CurrentInventory(lMInventory, pMInventory, id, e.Message));
            }
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            Bo_Inventory lInventory = new Bo_Inventory();
            lInventory = Bll_Inventory.bll_GetInventoryById(id);
            return View(Models.MInventory.MInventoryById(lInventory));
        }

        // POST: Inventory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Models.MInventory pMInventory)
        {
            try
            {
                string lMessage = Bll_Inventory.bll_DeleteInventory(id);
                if (lMessage == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    pMInventory.LMessageException = lMessage;
                    return View(pMInventory);
                }

            }
            catch (Exception e)
            {
                pMInventory.LMessageException = e.Message;
                return View(pMInventory);
            }
        }
        private static Models.MInventory CurrentInventory(Models.MInventory pMInventory, Models.MInventory pMInventoryOld, int id, string pMessageException)
        {
            Bo_Inventory oBInventory = new Bo_Inventory();
            oBInventory = Bll_Inventory.bll_GetInventoryById(id);
            pMInventory = Models.MInventory.MInventoryById(oBInventory);
            pMInventory.LNameInventory = pMInventoryOld.LNameInventory;
            pMInventory.LStatus.LIdStatus = pMInventoryOld.LStatus.LIdStatus;
            pMInventory.LMessageException = pMessageException;
            return pMInventory;
        }

    }
}
