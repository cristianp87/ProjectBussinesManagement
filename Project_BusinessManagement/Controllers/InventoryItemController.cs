using Bll_Business;
using BO_BusinessManagement;
using Project_BusinessManagement.Filters;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using IBusiness.Common;
using IBusiness.Management;
using Project_BusinessManagement.Models;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = "Administrador")]
    [ConfigurationApp(pParameter: "IsInventory")]
    public class InventoryItemController : Controller
    {
        #region Variables and Constants
        public IInventory LInventory =
        FacadeProvider.Resolver<BllInventory>();

        public IInventoryItem LInventoryItem =
        FacadeProvider.Resolver<BllInventoryItem>();

        public static IProduct LiProduct =
        FacadeProvider.Resolver<BllProduct>();

        public static IStatus LStatus =
        FacadeProvider.Resolver<BllStatus>();
        #endregion
        // GET: InventoryItem
        public ActionResult Index(int id)
        {
            var lListInventoryItem = this.LInventoryItem.bll_GetInventoryItemsByIdInventory(id);
            this.ViewData["LIdInventory"] = id;
            return this.View(MInventoryItem.MListInventoryItem(lListInventoryItem));
        }

        // GET: InventoryItem/Details/5
        public ActionResult Details(int id)
        {
            Bo_InventoryItem lOInventoryItem = this.LInventoryItem.bll_GetInventoryItemById(id);
            return this.View(MInventoryItem.MInventoryItemById(lOInventoryItem));
        }

        [ConfigurationApp(pParameter: "CreateInventory")]
        // GET: InventoryItem/Create
        public ActionResult Create(int idInventory)
        {         
            return this.View(MInventoryItem.MInventoryEmpty(idInventory));
        }

        // POST: InventoryItem/Create
        [HttpPost]
        public ActionResult Create(int idInventory, MInventoryItem pMInventoryItem)
        {
            try
            {
                this.ModelState.Remove("LProduct.LNameProduct");
                this.ModelState.Remove("LProduct.LCdProduct");
                if (this.ModelState.IsValid)
                {
                    var lMessage = this.LInventoryItem.bll_InsertInventoryItem(idInventory, Convert.ToInt32(this.Request.Form["LProduct.LIdProduct"].ToString()), Convert.ToInt32(this.Request.Form["LObject.LIdObject"].ToString()), this.Request.Form["LStatus.LIdStatus"].ToString(), Convert.ToDecimal(this.Request.Form["LQtySellable"].ToString()), Convert.ToDecimal(this.Request.Form["LQtyNonSellable"].ToString()));
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index", new { id = idInventory});
                    }
                    else
                    {
                        EmptyInventoryItem(pMInventoryItem);
                        pMInventoryItem.LMessageException = lMessage;
                        return this.View(pMInventoryItem);
                    }

                }
                else
                {
                    EmptyInventoryItem(pMInventoryItem);
                    return this.View(pMInventoryItem);
                }

            }
            catch (Exception e)
            {
                EmptyInventoryItem(pMInventoryItem);
                pMInventoryItem.LMessageException = e.Message;
                return this.View(pMInventoryItem);
            }
        }


        [ConfigurationApp(pParameter: "EditInventory")]
        // GET: InventoryItem/Edit/5
        public ActionResult Edit(int id)
        {
            var lOInventoryItem = this.LInventoryItem.bll_GetInventoryItemById(id);
            return this.View(MInventoryItem.MInventoryItemById(lOInventoryItem));
        }

        // POST: InventoryItem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MInventoryItem pMInventoryItem)
        {
            try
            {
                MInventoryItem lInventoryItem = new MInventoryItem();
                this.ModelState.Remove("LProduct.LNameProduct");
                this.ModelState.Remove("LProduct.LCdProduct");
                if (this.ModelState.IsValid)
                {
                    string lMessage = this.LInventoryItem.bll_UpdateInventoryITem(id, Convert.ToInt32(this.Request.Form["LInventory.LIdInventory"].ToString()), Convert.ToInt32(this.Request.Form["LProduct.LIdProduct"].ToString()), Convert.ToDecimal(this.Request.Form["LQtySellable"].ToString()), Convert.ToDecimal(this.Request.Form["LQtyNonSellable"].ToString()), Convert.ToInt32(this.Request.Form["LObject.LIdObject"].ToString()), this.Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index", new { id = pMInventoryItem.LInventory.LIdInventory });
                    }
                    else
                    {                       
                        return this.View(this.CurrentInventoryItem(lInventoryItem, pMInventoryItem, id, lMessage, pMInventoryItem.LInventory.LIdInventory));
                    }

                }
                else
                {                   
                    return this.View(this.CurrentInventoryItem(lInventoryItem, pMInventoryItem, id, "Debe completar los campos obligatorios", pMInventoryItem.LInventory.LIdInventory));
                }

            }
            catch (Exception e)
            {
                MInventoryItem lInventoryItemExc = new MInventoryItem();              
                return this.View(this.CurrentInventoryItem(lInventoryItemExc, pMInventoryItem, id, e.Message, pMInventoryItem.LInventory.LIdInventory));
            }
        }

        [ConfigurationApp(pParameter: "DeleteInventory")]
        // GET: InventoryItem/Delete/5
        public ActionResult Delete(int id)
        {
            var lOInventoryItem = this.LInventoryItem.bll_GetInventoryItemById(id);
            return this.View(MInventoryItem.MInventoryItemById(lOInventoryItem));
        }

        // POST: InventoryItem/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MInventoryItem pMInventoryItem)
        {
            try
            {
                string lMessage = this.LInventoryItem.bll_DeleteInventoryItem(id);
                if(lMessage == null)
                {
                    return this.RedirectToAction("Index", new { id = pMInventoryItem.LInventory.LIdInventory });
                }
                else
                {
                    pMInventoryItem.LMessageException = lMessage;
                    return this.View(pMInventoryItem);
                }
                
            }
            catch(Exception e)
            {
                pMInventoryItem.LMessageException = e.Message;
                return this.View();
            }
        }

        private static MInventoryItem EmptyInventoryItem(MInventoryItem pMInventoryItem)
        {
            pMInventoryItem.LListStatus = new List<SelectListItem>();
            pMInventoryItem.LListProduct = new List<SelectListItem>();
            pMInventoryItem.LListStatus = MStatus.MListAllStatus(LStatus.Bll_getListStatusByIdObject(pMInventoryItem.LObject.LIdObject));
            pMInventoryItem.LListProduct = MProduct.MListAllProduct(LiProduct.bll_GetAllProduct());
            return pMInventoryItem;
        }

        private  MInventoryItem CurrentInventoryItem(MInventoryItem pMInventoryItem, MInventoryItem pMInventoryOldItem, int id, string pMessageException, int pIdInventory)
        {
            if (pMInventoryItem == null)
            {
                throw new ArgumentNullException(nameof(pMInventoryItem));
            }
            pMInventoryItem = pMInventoryOldItem;
            pMInventoryItem.LListStatus = new List<SelectListItem>();
            pMInventoryItem.LListProduct = new List<SelectListItem>();
            pMInventoryItem.LListStatus = MStatus.MListAllStatus(LStatus.Bll_getListStatusByIdObject(pMInventoryItem.LObject.LIdObject));
            pMInventoryItem.LListProduct = MProduct.MListAllProduct(LiProduct.bll_GetAllProduct());
            pMInventoryItem.LInventory = new MInventory();
            var lObInventory = this.LInventory.bll_GetInventoryById(pIdInventory);
            pMInventoryItem.LInventory.LIdInventory = lObInventory.LIdInventory;
            pMInventoryItem.LInventory.LNameInventory = lObInventory.LNameInventory;
            pMInventoryItem.LMessageException = pMessageException;
            return pMInventoryItem;
        }
    }
}
