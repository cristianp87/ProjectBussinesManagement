using System;
using System.Collections.Generic;
using System.Web.Mvc;
using IBusiness.Common;
using IBusiness.Management;
using Project_BusinessManagement.Filters;
using Project_BusinessManagement.Models;
using Project_BusinessManagement.Models.Enums;
using Project_BusinessManagement.Models.Mappers;
using System.Linq;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = EGlobalVariables.LRoleAdmin)]
    [ConfigurationApp(EGlobalVariables.LIsInventory)]
    public class InventoryController : BaseApiController
    {
        #region Variables and Constants
        public IInventory LInventory =
        FacadeProvider.Resolv<IInventory>();

        public IStatus LStatus =
        FacadeProvider.Resolv<IStatus>();
        #endregion
        // GET: Inventory
        public ActionResult Index()
        {
            var lListBoInventory = this.LInventory.bll_GetAllInventory();
            return this.View(lListBoInventory.MListInventory());
        }

        [HttpPost]
        public ActionResult Index(string pSearchhName)
        {
            var lBoListInventory = this.LInventory.bll_GetAllInventory();
            if (string.IsNullOrEmpty(pSearchhName))
                return this.View(lBoListInventory.MListInventory());
            lBoListInventory = lBoListInventory.Where(s => s.LNameInventory.ToUpper().Contains(pSearchhName.ToUpper())).ToList();
            return this.View(lBoListInventory.MListInventory());
        }

        [ConfigurationApp(EGlobalVariables.LCreateInventory)]
        // GET: Inventory/Create
        public ActionResult Create()
        {
            return this.View(MapperInventory.MInventoryEmpty());
        }

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult Create(MInventory pMInventory)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    var lMessage = this.LInventory.bll_InsertInventory(pMInventory.LNameInventory, Convert.ToInt32(this.Request.Form[EFields.LFieldListObject]), this.Request.Form[EFields.LFieldListStatus]);
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index");
                    }
                    this.ListEmptyInventory(pMInventory);
                    pMInventory.LMessageException = lMessage;
                    return this.View(pMInventory);
                }
                this.ListEmptyInventory(pMInventory);
                return this.View(pMInventory);
            }
            catch (Exception e)
            {
                this.ListEmptyInventory(pMInventory);
                pMInventory.LMessageException = e.Message;
                return this.View(pMInventory);
            }
        }

        private void ListEmptyInventory(MInventory pMInventory)
        {
            pMInventory.LListStatus = new List<SelectListItem>();
            pMInventory.LListStatus = this.LStatus.Bll_getListStatusByIdObject(pMInventory.LObject.LIdObject).MListAllStatus();
        }

        [ConfigurationApp(EGlobalVariables.LEditInventory)]
        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            var lInventory = this.LInventory.bll_GetInventoryById(id);
            return this.View(lInventory.MInventoryById());
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MInventory pMInventory)
        {
            try
            {
                var lMInventory = new MInventory();
                if (this.ModelState.IsValid)
                {
                    var lMessage = this.LInventory.bll_UpdateInventory(id, pMInventory.LNameInventory, Convert.ToInt32(this.Request.Form[EFields.LFieldListObject]), this.Request.Form[EFields.LFieldListStatus]);
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index");
                    }
                    return this.View(this.CurrentInventory(lMInventory, pMInventory, id, lMessage));
                }
                return this.View(this.CurrentInventory(lMInventory, pMInventory, id, EMessages.LMsgEditfieldsemtpy));
            }
            catch (Exception e)
            {
                var lMInventory = new MInventory();
                return this.View(this.CurrentInventory(lMInventory, pMInventory, id, e.Message));
            }
        }

        [ConfigurationApp(EGlobalVariables.LDeleteInventory)]
        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            var lInventory = this.LInventory.bll_GetInventoryById(id);
            return this.View(lInventory.MInventoryById());
        }

        // POST: Inventory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MInventory pMInventory)
        {
            try
            {
                var lMessage = this.LInventory.bll_DeleteInventory(id);
                if (lMessage == null)
                {
                    return this.RedirectToAction("Index");
                }
                pMInventory.LMessageException = lMessage;
                return this.View(pMInventory);
            }
            catch (Exception e)
            {
                pMInventory.LMessageException = e.Message;
                return this.View(pMInventory);
            }
        }
        private MInventory CurrentInventory(MInventory pMInventory, MInventory pMInventoryOld, int id, string pMessageException)
        {
            var oBInventory = this.LInventory.bll_GetInventoryById(id);
            if (pMInventory != null)
            {
                pMInventory = oBInventory.MInventoryById();
                pMInventory.LNameInventory = pMInventoryOld.LNameInventory;
                pMInventory.LStatus.LIdStatus = pMInventoryOld.LStatus.LIdStatus;
                pMInventory.LMessageException = pMessageException;
            }
            pMInventory = oBInventory.MInventoryById();
            pMInventory.LNameInventory = pMInventoryOld.LNameInventory;
            pMInventory.LStatus.LIdStatus = pMInventoryOld.LStatus.LIdStatus;
            pMInventory.LMessageException = pMessageException;
            return pMInventory;
        }

    }
}
