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
            oBSupplier.LObject = new Bo_Object();
            oBSupplier.LObject.LIdObject = 2;
            oBSupplier.LObject.LNameObject = "SUPP";

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
                    Bo_Supplier oBSupplier = new Bo_Supplier();
                    oBSupplier.LTypeIdentification = new Bo_TypeIdentification();
                    oBSupplier.LStatus = new Bo_Status();
                    oBSupplier.LObject = new Bo_Object();
                    oBSupplier.LNameSupplier = Request.Form["LNameSupplier"].ToString();
                    oBSupplier.LNoIdentification = Request.Form["LNoIdentification"].ToString();
                    oBSupplier.LTypeIdentification.LIdTypeIdentification = Convert.ToInt32(Request.Form["LTypeIdentification.LIdTypeIdentification"].ToString());
                    oBSupplier.LCreationDate = Convert.ToDateTime(Request.Form["LCreationDate"].ToString());
                    oBSupplier.LStatus.LIdStatus = Request.Form["LStatus.LIdStatus"].ToString();
                    oBSupplier.LObject.LIdObject = Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString());
                    Bll_Supplier.bll_InsertSupplier(oBSupplier.LNameSupplier, oBSupplier.LNoIdentification, oBSupplier.LTypeIdentification.LIdTypeIdentification, oBSupplier.LObject.LIdObject, oBSupplier.LStatus.LIdStatus);
                    return RedirectToAction("Index");
                }
                else
                {
                    pMsupplier.LListTypeIdentification = new List<SelectListItem>();
                    pMsupplier.LListTypeIdentification = Models.MTypeIdentification.MListAllTypeIdentification(Bll_TypeIdentification.bll_getListTypeIdentification());
                    pMsupplier.LListStatus = new List<SelectListItem>();
                    pMsupplier.LListStatus = Models.MStatus.MListAllStatus(Bll_Status.Bll_getListStatusByIdObject(pMsupplier.LObject.LIdObject));
                    return View(pMsupplier);
                }

            }
            catch (Exception e)
            {
                pMsupplier.LListTypeIdentification = new List<SelectListItem>();
                pMsupplier.LListTypeIdentification = Models.MTypeIdentification.MListAllTypeIdentification(Bll_TypeIdentification.bll_getListTypeIdentification());
                pMsupplier.LListStatus = new List<SelectListItem>();
                pMsupplier.LListStatus = Models.MStatus.MListAllStatus(Bll_Status.Bll_getListStatusByIdObject(pMsupplier.LObject.LIdObject));
                return View(pMsupplier);
            }
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
                    Bo_Supplier oBSupplier = new Bo_Supplier();
                    oBSupplier.LTypeIdentification = new Bo_TypeIdentification();
                    oBSupplier.LStatus = new Bo_Status();
                    oBSupplier.LObject = new Bo_Object();
                    oBSupplier.LIdSupplier = id;
                    oBSupplier.LNameSupplier = Request.Form["LNameSupplier"].ToString();
                    oBSupplier.LNoIdentification = Request.Form["LNoIdentification"].ToString();
                    oBSupplier.LTypeIdentification.LIdTypeIdentification = Convert.ToInt32(Request.Form["LTypeIdentification.LIdTypeIdentification"].ToString());
                    oBSupplier.LCreationDate = Convert.ToDateTime(Request.Form["LCreationDate"].ToString());
                    oBSupplier.LStatus.LIdStatus = Request.Form["LStatus.LIdStatus"].ToString();
                    oBSupplier.LObject.LIdObject = Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString());
                    Bll_Supplier.bll_UpdateSupplier(oBSupplier.LIdSupplier, oBSupplier.LNameSupplier, oBSupplier.LNoIdentification, oBSupplier.LTypeIdentification.LIdTypeIdentification, oBSupplier.LObject.LIdObject, oBSupplier.LStatus.LIdStatus);
                    return RedirectToAction("Index");
                }
                else
                {
                    pMsupplier.LListTypeIdentification = new List<SelectListItem>();
                    pMsupplier.LListTypeIdentification = Models.MTypeIdentification.MListAllTypeIdentification(Bll_TypeIdentification.bll_getListTypeIdentification());
                    pMsupplier.LListStatus = new List<SelectListItem>();
                    pMsupplier.LListStatus = Models.MStatus.MListAllStatus(Bll_Status.Bll_getListStatusByIdObject(pMsupplier.LObject.LIdObject));
                    return View(pMsupplier);
                }

            }
            catch(Exception e)
            {
                pMsupplier.LListTypeIdentification = new List<SelectListItem>();
                pMsupplier.LListTypeIdentification = Models.MTypeIdentification.MListAllTypeIdentification(Bll_TypeIdentification.bll_getListTypeIdentification());
                pMsupplier.LListStatus = new List<SelectListItem>();
                pMsupplier.LListStatus = Models.MStatus.MListAllStatus(Bll_Status.Bll_getListStatusByIdObject(pMsupplier.LObject.LIdObject));
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
                    Bll_Supplier.bll_DeleteSupplier(id);
                    return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
