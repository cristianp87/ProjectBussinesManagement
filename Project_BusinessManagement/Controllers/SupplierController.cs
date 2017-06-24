using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bll_Business;
using BO_BusinessManagement;
using System.Collections;

namespace Project_BusinessManagement.Views.Supplier
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            List<Bo_Supplier> oBListSupplier = new List<Bo_Supplier>();
            oBListSupplier = Bll_Supplier.bll_GetAllSupplier();  

            return View(Models.MSupplier.MListSupplier(oBListSupplier));
        }
        // GET: Supplier/Details/5
        public ActionResult Details(int id)
        {
            Bo_Supplier oBSupplier = new Bo_Supplier();
            oBSupplier = Bll_Supplier.bll_GetSupplierById(id);
            return View(Models.MSupplier.MSupplierById(oBSupplier));
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            Bo_Supplier oBSupplier = new Bo_Supplier();
            return View(Models.MSupplier.MSupplierEmpty(oBSupplier));
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult Create(Models.MSupplier pMsupplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string lMessage = Bll_Supplier.bll_InsertSupplier(Request.Form["LNameSupplier"].ToString(), Request.Form["LNoIdentification"].ToString(), Convert.ToInt32(Request.Form["LTypeIdentification.LIdTypeIdentification"].ToString()), Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString()), Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ListEmptySupplier(pMsupplier);
                        pMsupplier.LMessageException = lMessage;
                        return View(pMsupplier);
                    }

                }
                else
                {
                    ListEmptySupplier(pMsupplier);
                    return View(pMsupplier);
                }

            }
            catch (Exception e)
            {
                ListEmptySupplier(pMsupplier);
                pMsupplier.LMessageException = e.Message;
                return View(pMsupplier);
            }
        }

        private static void ListEmptySupplier(Models.MSupplier pMsupplier)
        {
            pMsupplier.LListTypeIdentification = new List<SelectListItem>();
            pMsupplier.LListTypeIdentification = Models.MTypeIdentification.MListAllTypeIdentification(Bll_TypeIdentification.bll_getListTypeIdentification());
            pMsupplier.LListStatus = new List<SelectListItem>();
            //pMsupplier.LListStatus = Models.MStatus.MListAllStatus(Bll_Status.Bll_getListStatusByIdObject(pMsupplier.LObject.LIdObject));
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            Bo_Supplier oBSupplier = new Bo_Supplier();
            oBSupplier = Bll_Supplier.bll_GetSupplierById(id);
            return View(Models.MSupplier.MSupplierById(oBSupplier));
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.MSupplier pMsupplier)
        {
            try
            {               
                if (ModelState.IsValid) { 
                    var lMessage = Bll_Supplier.bll_UpdateSupplier(id, Request.Form["LNameSupplier"].ToString(), Request.Form["LNoIdentification"].ToString(), Convert.ToInt32(Request.Form["LTypeIdentification.LIdTypeIdentification"].ToString()), Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString()), Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ListEmptySupplier(pMsupplier);
                        pMsupplier.LMessageException = lMessage;
                        return View(pMsupplier);
                    }
                                  
                }
                else
                {
                    ListEmptySupplier(pMsupplier);
                    return View(pMsupplier);
                }

            }
            catch(Exception e)
            {
                ListEmptySupplier(pMsupplier);
                pMsupplier.LMessageException = e.Message;
                return View(pMsupplier);
            }
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            Bo_Supplier oBSupplier = new Bo_Supplier();
            oBSupplier = Bll_Supplier.bll_GetSupplierById(id);
            return View(Models.MSupplier.MSupplierById(oBSupplier));
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Models.MSupplier pMsupplier)
        {
            try
            {
                var lMessage = Bll_Supplier.bll_DeleteSupplier(id);
                if (lMessage.Equals(null))
                {
                    pMsupplier.LMessageException = lMessage;
                    return RedirectToAction("Index");
                }else
                {
                    return View();
                }
                    

            }
            catch (Exception e)
            {
                pMsupplier.LMessageException = e.Message;
                return View();
            }
        }
    }
}
