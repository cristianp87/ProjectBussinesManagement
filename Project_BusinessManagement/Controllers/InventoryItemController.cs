using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BO_BusinessManagement;
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
    public class InventoryItemController : BaseApiController
    {
        #region Variables and Constants
        public IInventory LInventory =
        FacadeProvider.Resolv<IInventory>();

        public IInventoryItem LInventoryItem =
        FacadeProvider.Resolv<IInventoryItem>();

        public static IProduct LiProduct =
        FacadeProvider.Resolv<IProduct>();

        public static IStatus LStatus =
        FacadeProvider.Resolv<IStatus>();
        #endregion

        #region Methods
        
        #region Action
        // GET: InventoryItem
        public ActionResult Index(int id)
        {
            var lListInventoryItem = this.LInventoryItem.bll_GetInventoryItemsByIdInventory(id);
            this.ViewData["LIdInventory"] = id;
            return this.View(lListInventoryItem.MListInventoryItem());
        }

        [HttpPost]
        public ActionResult Index(int id, string pSearchhName)
        {
            var lListInventoryItem = this.LInventoryItem.bll_GetInventoryItemsByIdInventory(id);
            if (string.IsNullOrEmpty(pSearchhName))
                return this.View(lListInventoryItem.MListInventoryItem());
            lListInventoryItem = lListInventoryItem.Where(s => s.LInventory.LNameInventory.ToUpper().Contains(pSearchhName.ToUpper())).ToList();
            return this.View(lListInventoryItem.MListInventoryItem());
        }

        // GET: InventoryItem/Details/5
        public ActionResult Details(int id)
        {
            BoInventoryItem lOInventoryItem = this.LInventoryItem.bll_GetInventoryItemById(id);
            return this.View(lOInventoryItem.MInventoryItemById());
        }

        //[ConfigurationApp(EGlobalVariables.LCreateInventory)]
        // GET: InventoryItem/Create
        public ActionResult Create(int idInventory)
        {
            return this.View(idInventory.MInventoryEmpty());
        }

        // POST: InventoryItem/Create
        [HttpPost]
        public ActionResult Create(int idInventory, MInventoryItem pMInventoryItem)
        {
            try
            {
                this.ModelState.Remove(EFields.LFieldNameProduct);
                this.ModelState.Remove(EFields.LFieldCodeProduct);
                if (this.ModelState.IsValid)
                {
                    var lMessage = this.LInventoryItem.bll_InsertInventoryItem(idInventory, Convert.ToInt32(pMInventoryItem.LProduct.LIdProduct), Convert.ToInt32(this.Request.Form[EFields.LFieldListObject]), this.Request.Form[EFields.LFieldListStatus], Convert.ToDecimal(pMInventoryItem.LQtySellable), Convert.ToDecimal(pMInventoryItem.LQtyNonSellable));
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index", new { id = idInventory });
                    }
                    EmptyInventoryItem(pMInventoryItem);
                    pMInventoryItem.LMessageException = lMessage;
                    return this.View(pMInventoryItem);
                }
                EmptyInventoryItem(pMInventoryItem);
                return this.View(pMInventoryItem);
            }
            catch (Exception e)
            {
                EmptyInventoryItem(pMInventoryItem);
                pMInventoryItem.LMessageException = e.Message;
                return this.View(pMInventoryItem);
            }
        }


        [ConfigurationApp(EGlobalVariables.LEditInventory)]
        // GET: InventoryItem/Edit/5
        public ActionResult Edit(int id)
        {
            var lOInventoryItem = this.LInventoryItem.bll_GetInventoryItemById(id);
            return this.View(lOInventoryItem.MInventoryItemById());
        }

        // POST: InventoryItem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MInventoryItem pMInventoryItem)
        {
            try
            {
                MInventoryItem lInventoryItem = new MInventoryItem();
                this.ModelState.Remove(EFields.LFieldNameProduct);
                this.ModelState.Remove(EFields.LFieldCodeProduct);
                if (this.ModelState.IsValid)
                {
                    string lMessage = this.LInventoryItem.bll_UpdateInventoryITem(id, Convert.ToInt32(pMInventoryItem.LInventory.LIdInventory), Convert.ToInt32(pMInventoryItem.LProduct.LIdProduct), Convert.ToDecimal(pMInventoryItem.LQtySellable), Convert.ToDecimal(pMInventoryItem.LQtyNonSellable), Convert.ToInt32(this.Request.Form[EFields.LFieldListObject]), this.Request.Form[EFields.LFieldListStatus]);
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index", new { id = pMInventoryItem.LInventory.LIdInventory });
                    }
                    return this.View(this.CurrentInventoryItem(lInventoryItem, pMInventoryItem, lMessage, pMInventoryItem.LInventory.LIdInventory));
                }
                return this.View(this.CurrentInventoryItem(lInventoryItem, pMInventoryItem, "Debe completar los campos obligatorios", pMInventoryItem.LInventory.LIdInventory));
            }
            catch (Exception e)
            {
                MInventoryItem lInventoryItemExc = new MInventoryItem();
                return this.View(this.CurrentInventoryItem(lInventoryItemExc, pMInventoryItem, e.Message, pMInventoryItem.LInventory.LIdInventory));
            }
        }

        [ConfigurationApp(EGlobalVariables.LDeleteInventory)]
        // GET: InventoryItem/Delete/5
        public ActionResult Delete(int id)
        {
            var lOInventoryItem = this.LInventoryItem.bll_GetInventoryItemById(id);
            return this.View(lOInventoryItem.MInventoryItemById());
        }

        // POST: InventoryItem/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MInventoryItem pMInventoryItem)
        {
            try
            {
                string lMessage = this.LInventoryItem.bll_DeleteInventoryItem(id);
                if (lMessage == null)
                {
                    return this.RedirectToAction("Index", new { id = pMInventoryItem.LInventory.LIdInventory });
                }
                pMInventoryItem.LMessageException = lMessage;
                return this.View(pMInventoryItem);
            }
            catch (Exception e)
            {
                pMInventoryItem.LMessageException = e.Message;
                return this.View();
            }
        }
        #endregion

        #region Privates
        private static void EmptyInventoryItem(MInventoryItem pMInventoryItem)
        {
            pMInventoryItem.LListStatus = new List<SelectListItem>();
            pMInventoryItem.LListProduct = new List<SelectListItem>();
            pMInventoryItem.LListStatus = LStatus.Bll_getListStatusByIdObject(pMInventoryItem.LObject.LIdObject).MListAllStatus();
            pMInventoryItem.LListProduct = LiProduct.bll_GetAllProduct().MListAllProduct(true);
        }

        private MInventoryItem CurrentInventoryItem(MInventoryItem pMInventoryItem, MInventoryItem pMInventoryOldItem, string pMessageException, int pIdInventory)
        {
            if (pMInventoryItem == null)
            {
                throw new ArgumentNullException(nameof(pMInventoryItem));
            }
            pMInventoryItem = pMInventoryOldItem;
            pMInventoryItem.LListStatus = new List<SelectListItem>();
            pMInventoryItem.LListProduct = new List<SelectListItem>();
            pMInventoryItem.LListStatus = LStatus.Bll_getListStatusByIdObject(pMInventoryItem.LObject.LIdObject).MListAllStatus();
            pMInventoryItem.LListProduct = LiProduct.bll_GetAllProduct().MListAllProduct(true);
            pMInventoryItem.LInventory = new MInventory();
            var lObInventory = this.LInventory.bll_GetInventoryById(pIdInventory);
            pMInventoryItem.LInventory.LIdInventory = lObInventory.LIdInventory;
            pMInventoryItem.LInventory.LNameInventory = lObInventory.LNameInventory;
            pMInventoryItem.LMessageException = pMessageException;
            return pMInventoryItem;
        }
        #endregion

        #endregion

    }
}
