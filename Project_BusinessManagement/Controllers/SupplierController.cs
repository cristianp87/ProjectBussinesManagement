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
    [ConfigurationApp(EGlobalVariables.LIsSupplier)]
    public class SupplierController : BaseApiController
    {
        #region Variables and Constants
        public ISupplier LiSupplier =
        FacadeProvider.Resolv<ISupplier>();

        public static ITypeIdentification LiTypeIdentification =
        FacadeProvider.Resolv<ITypeIdentification>();

        public static IStatus LiStatus =
        FacadeProvider.Resolv<IStatus>();

        public IUtilsLib LiUtilsLib =
        FacadeProvider.Resolv<IUtilsLib>();
        #endregion

        // GET: Supplier
        public ActionResult Index()
        {
            var lBoListSupplier = this.LiSupplier.bll_GetAllSupplier();
            return this.View(lBoListSupplier.MListSupplier(false));
        }

        [HttpPost]
        public ActionResult Index(string pSearchName)
        {
            var lBoListSupplier = this.LiSupplier.bll_GetAllSupplier();
            if (string.IsNullOrEmpty(pSearchName))
                return this.View(lBoListSupplier.MListSupplier(false));
            lBoListSupplier = lBoListSupplier.Where(s => s.LNameSupplier.ToUpper().Contains(pSearchName.ToUpper())).ToList();
            return this.View(lBoListSupplier.MListSupplier(false));
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int id)
        {
            var lBoListSupplier = this.LiSupplier.bll_GetSupplierById(id);
            return this.View(lBoListSupplier.MSupplierById());
        }

        [ConfigurationApp(EGlobalVariables.LCreateSupplier)]
        // GET: Supplier/Create
        public ActionResult Create()
        {
            var lBoSupplier = new BoSupplier();
            return this.View(lBoSupplier.MSupplierEmpty());
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult Create(MSupplier pMsupplier)
        {
            try
            {
                this.ModelState.Remove(EFields.LFieldIdSupplier);
                if (this.ModelState.IsValid)
                {
                    var lMessage = this.LiSupplier.bll_InsertSupplier(pMsupplier.LNameSupplier, pMsupplier.LNoIdentification, Convert.ToInt32(this.Request.Form[EFields.LFieldListTypeIdentification]), Convert.ToInt32(this.Request.Form[EFields.LFieldListObject]), this.LiUtilsLib.bll_getStatusApproByObject(this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectSupplier).LIdObject).LIdStatus);
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index");
                    }
                    ListEmptySupplier(pMsupplier);
                    pMsupplier.LMessageException = lMessage;
                    return this.View(pMsupplier);
                }
                ListEmptySupplier(pMsupplier);
                return this.View(pMsupplier);
            }
            catch (Exception e)
            {
                ListEmptySupplier(pMsupplier);
                pMsupplier.LMessageException = e.Message;
                return this.View(pMsupplier);
            }
        }

        private static void ListEmptySupplier(MSupplier pMsupplier)
        {
            pMsupplier.LListTypeIdentification = new List<SelectListItem>();
            pMsupplier.LListTypeIdentification = LiTypeIdentification.bll_getListTypeIdentification().MListAllTypeIdentification();
            pMsupplier.LListStatus = new List<SelectListItem>();
            pMsupplier.LListStatus = LiStatus.Bll_getListStatusByIdObject(pMsupplier.LObject.LIdObject).MListAllStatus();
        }

        [ConfigurationApp(EGlobalVariables.LEditSupplier)]
        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            var lBOSupplier = this.LiSupplier.bll_GetSupplierById(id);
            return this.View(lBOSupplier.MSupplierById());
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MSupplier pMsupplier)
        {
            try
            {               
                if (this.ModelState.IsValid) { 
                    var lMessage = this.LiSupplier.bll_UpdateSupplier(id, pMsupplier.LNameSupplier, pMsupplier.LNoIdentification, Convert.ToInt32(this.Request.Form[EFields.LFieldListTypeIdentification]), Convert.ToInt32(this.Request.Form[EFields.LFieldListObject]), this.Request.Form[EFields.LFieldListStatus]);
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index");
                    }
                    ListEmptySupplier(pMsupplier);
                    pMsupplier.LMessageException = lMessage;
                    return this.View(pMsupplier);
                }
                ListEmptySupplier(pMsupplier);
                return this.View(pMsupplier);
            }
            catch(Exception e)
            {
                ListEmptySupplier(pMsupplier);
                pMsupplier.LMessageException = e.Message;
                return this.View(pMsupplier);
            }
        }

        [ConfigurationApp(EGlobalVariables.LDeleteSupplier)]
        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            var oBSupplier = this.LiSupplier.bll_GetSupplierById(id);
            return this.View(oBSupplier.MSupplierById());
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MSupplier pMsupplier)
        {
            try
            {
                var lMessage = this.LiSupplier.bll_DeleteSupplier(id);
                if (lMessage == null)
                {
                    return this.RedirectToAction("Index");
                }
                pMsupplier.LMessageException = lMessage;
                return this.View();
            }
            catch (Exception e)
            {
                pMsupplier.LMessageException = e.Message;
                return this.View();
            }
        }
    }
}
