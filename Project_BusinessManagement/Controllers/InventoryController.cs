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
    [Authorize(Roles = "Administrador")]
    [ConfigurationApp(pParameter: "IsInventory")]
    public class InventoryController : Controller
    {
        #region Variables and Constants
        public IInventory LInventory =
        FacadeProvider.Resolver<IInventory>();

        public IStatus LStatus =
        FacadeProvider.Resolver<BllStatus>();
        #endregion
        // GET: Inventory
        public ActionResult Index()
        {
            List<Bo_Inventory> lListBoInventory = new List<Bo_Inventory>();
            lListBoInventory = this.LInventory.bll_GetAllInventory();
            return View(Models.MInventory.MListInventory(lListBoInventory));
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [ConfigurationApp(pParameter: "CreateInventory")]
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
                    string lMessage = this.LInventory.bll_InsertInventory(Request.Form["LNameInventory"].ToString(), Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString()), Request.Form["LStatus.LIdStatus"].ToString());
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
            pMInventory.LListStatus = Models.MStatus.MListAllStatus(this.LStatus.Bll_getListStatusByIdObject(pMInventory.LObject.LIdObject));
        }

        [ConfigurationApp(pParameter: "EditInventory")]
        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            Bo_Inventory lInventory = new Bo_Inventory();
            lInventory = this.LInventory.bll_GetInventoryById(id);
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
                    string lMessage = this.LInventory.bll_UpdateInventory(id, Request.Form["LNameInventory"].ToString(), Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString()), Request.Form["LStatus.LIdStatus"].ToString());
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

        [ConfigurationApp(pParameter: "DeleteInventory")]
        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            Bo_Inventory lInventory = new Bo_Inventory();
            lInventory = this.LInventory.bll_GetInventoryById(id);
            return View(Models.MInventory.MInventoryById(lInventory));
        }

        // POST: Inventory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Models.MInventory pMInventory)
        {
            try
            {
                string lMessage = this.LInventory.bll_DeleteInventory(id);
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
        private MInventory CurrentInventory(Models.MInventory pMInventory, Models.MInventory pMInventoryOld, int id, string pMessageException)
        {
            Bo_Inventory oBInventory = new Bo_Inventory();
            oBInventory = this.LInventory.bll_GetInventoryById(id);
            pMInventory = Models.MInventory.MInventoryById(oBInventory);
            pMInventory.LNameInventory = pMInventoryOld.LNameInventory;
            pMInventory.LStatus.LIdStatus = pMInventoryOld.LStatus.LIdStatus;
            pMInventory.LMessageException = pMessageException;
            return pMInventory;
        }

    }
}
