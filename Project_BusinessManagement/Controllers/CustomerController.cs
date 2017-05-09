using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bll_Business;
using BO_BusinessManagement;

namespace Project_BusinessManagement.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Bo_Customer> oBListCustomer = new List<Bo_Customer>();
            oBListCustomer = Bll_Customer.bll_GetAllCustomer();

            return View(Models.MCustomer.MListCustomer(oBListCustomer));
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            Bo_Customer oBCustomer = new Bo_Customer();
            oBCustomer = Bll_Customer.bll_GetCustomerById(id);
            return View(Models.MCustomer.MCustomerById(oBCustomer));
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Bo_Customer oBCustomer = new Bo_Customer();
            oBCustomer = Bll_Customer.bll_GetCustomerById(id);
            return View(Models.MCustomer.MCustomerById(oBCustomer));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.MCustomer pMCustomer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lMessage = Bll_Customer.bll_UpdateCustomer(id, Request.Form["LNameCustomer"].ToString(), Request.Form["LLastNameCustomer"].ToString(), Request.Form["LNoIdentification"].ToString(), Convert.ToInt32(Request.Form["LTypeIdentification.LIdTypeIdentification"].ToString()), Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString()), Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        pMCustomer.LListTypeIdentification = new List<SelectListItem>();
                        pMCustomer.LListTypeIdentification = Models.MTypeIdentification.MListAllTypeIdentification(Bll_TypeIdentification.bll_getListTypeIdentification());
                        pMCustomer.LListStatus = new List<SelectListItem>();
                        pMCustomer.LListStatus = Models.MStatus.MListAllStatus(Bll_Status.Bll_getListStatusByIdObject(pMCustomer.LObject.LIdObject));
                        pMCustomer.LMessageException = lMessage;
                        return View(pMCustomer);
                    }
                }
                else
                {
                    pMCustomer.LListTypeIdentification = new List<SelectListItem>();
                    pMCustomer.LListTypeIdentification = Models.MTypeIdentification.MListAllTypeIdentification(Bll_TypeIdentification.bll_getListTypeIdentification());
                    pMCustomer.LListStatus = new List<SelectListItem>();
                    pMCustomer.LListStatus = Models.MStatus.MListAllStatus(Bll_Status.Bll_getListStatusByIdObject(pMCustomer.LObject.LIdObject));
                    return View(pMCustomer);
                }

            }
            catch (Exception e)
            {
                pMCustomer.LListTypeIdentification = new List<SelectListItem>();
                pMCustomer.LListTypeIdentification = Models.MTypeIdentification.MListAllTypeIdentification(Bll_TypeIdentification.bll_getListTypeIdentification());
                pMCustomer.LListStatus = new List<SelectListItem>();
                pMCustomer.LListStatus = Models.MStatus.MListAllStatus(Bll_Status.Bll_getListStatusByIdObject(pMCustomer.LObject.LIdObject));
                pMCustomer.LMessageException = e.Message;
                return View(pMCustomer);
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
