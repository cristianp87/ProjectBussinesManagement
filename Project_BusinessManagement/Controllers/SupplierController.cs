using Bll_Business;
using BO_BusinessManagement;
using Project_BusinessManagement.Filters;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using IBusiness.Management;
using IBusiness.Common;

namespace Project_BusinessManagement.Views.Supplier
{
    [Authorize(Roles = "Administrador")]
    [ConfigurationApp(pParameter: "IsSupplier")]
    public class SupplierController : Controller
    {
        #region Variables and Constants
        public ISupplier LiSupplier =
        FacadeProvider.Resolver<ISupplier>();
        #endregion

        // GET: Supplier
        public ActionResult Index()
        {
            var oBListSupplier = this.LiSupplier.bll_GetAllSupplier();
            return this.View(Models.MSupplier.MListSupplier(oBListSupplier));
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int id)
        {
            var oBSupplier = this.LiSupplier.bll_GetSupplierById(id);
            return this.View(Models.MSupplier.MSupplierById(oBSupplier));
        }

        [ConfigurationApp(pParameter: "CreateSupplier")]
        // GET: Supplier/Create
        public ActionResult Create()
        {
            var oBSupplier = new Bo_Supplier();
            return this.View(Models.MSupplier.MSupplierEmpty(oBSupplier));
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult Create(Models.MSupplier pMsupplier)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    var lMessage = this.LiSupplier.bll_InsertSupplier(this.Request.Form["LNameSupplier"].ToString(), this.Request.Form["LNoIdentification"].ToString(), Convert.ToInt32(this.Request.Form["LTypeIdentification.LIdTypeIdentification"].ToString()), Convert.ToInt32(this.Request.Form["LObject.LIdObject"].ToString()), this.Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index");
                    }
                    else
                    {
                        ListEmptySupplier(pMsupplier);
                        pMsupplier.LMessageException = lMessage;
                        return this.View(pMsupplier);
                    }

                }
                else
                {
                    ListEmptySupplier(pMsupplier);
                    return this.View(pMsupplier);
                }

            }
            catch (Exception e)
            {
                ListEmptySupplier(pMsupplier);
                pMsupplier.LMessageException = e.Message;
                return this.View(pMsupplier);
            }
        }

        private static void ListEmptySupplier(Models.MSupplier pMsupplier)
        {
            pMsupplier.LListTypeIdentification = new List<SelectListItem>();
            pMsupplier.LListTypeIdentification = Models.MTypeIdentification.MListAllTypeIdentification(Bll_TypeIdentification.bll_getListTypeIdentification());
            pMsupplier.LListStatus = new List<SelectListItem>();
            //pMsupplier.LListStatus = Models.MStatus.MListAllStatus(Bll_Status.Bll_getListStatusByIdObject(pMsupplier.LObject.LIdObject));
        }

        [ConfigurationApp(pParameter: "EditSupplier")]
        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            var oBSupplier = this.LiSupplier.bll_GetSupplierById(id);
            return this.View(Models.MSupplier.MSupplierById(oBSupplier));
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.MSupplier pMsupplier)
        {
            try
            {               
                if (this.ModelState.IsValid) { 
                    var lMessage = this.LiSupplier.bll_UpdateSupplier(id, this.Request.Form["LNameSupplier"].ToString(), this.Request.Form["LNoIdentification"].ToString(), Convert.ToInt32(this.Request.Form["LTypeIdentification.LIdTypeIdentification"].ToString()), Convert.ToInt32(this.Request.Form["LObject.LIdObject"].ToString()), this.Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index");
                    }
                    else
                    {
                        ListEmptySupplier(pMsupplier);
                        pMsupplier.LMessageException = lMessage;
                        return this.View(pMsupplier);
                    }
                                  
                }
                else
                {
                    ListEmptySupplier(pMsupplier);
                    return this.View(pMsupplier);
                }

            }
            catch(Exception e)
            {
                ListEmptySupplier(pMsupplier);
                pMsupplier.LMessageException = e.Message;
                return this.View(pMsupplier);
            }
        }

        [ConfigurationApp(pParameter: "DeleteSupplier")]
        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            var oBSupplier = this.LiSupplier.bll_GetSupplierById(id);
            return this.View(Models.MSupplier.MSupplierById(oBSupplier));
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Models.MSupplier pMsupplier)
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
