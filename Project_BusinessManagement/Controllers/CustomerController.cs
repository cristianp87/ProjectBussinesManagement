using Bll_Business;
using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = "Administrador")]
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
            Bo_Customer oBCustomer= new Bo_Customer();
            return View(Models.MCustomer.MCustomerEmpty(oBCustomer));
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Models.MCustomer pMCustomer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string lMessage = Bll_Customer.bll_InsertCustomer(Request.Form["LNameCustomer"].ToString(), Request.Form["LLastNameCustomer"].ToString(), Request.Form["LNoIdentification"].ToString(), Convert.ToInt32(Request.Form["LTypeIdentification.LIdTypeIdentification"].ToString()), Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString()), Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        pMCustomer.LMessageException = lMessage;
                        ListEmptyCustomer(pMCustomer);
                        return View(pMCustomer);
                    }

                }
                else
                {
                    ListEmptyCustomer(pMCustomer);
                    return View(pMCustomer);
                }

            }
            catch (Exception e)
            {
                pMCustomer.LMessageException = e.Message;
                ListEmptyCustomer(pMCustomer);
                return View(pMCustomer);
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
                        pMCustomer.LMessageException = lMessage;
                        ListEmptyCustomer(pMCustomer);
                        return View(pMCustomer);
                    }
                }
                else
                {
                    ListEmptyCustomer(pMCustomer);
                    return View(pMCustomer);
                }

            }
            catch (Exception e)
            {
                pMCustomer.LMessageException = e.Message;
                ListEmptyCustomer(pMCustomer);
                return View(pMCustomer);
            }
        }

        private static void ListEmptyCustomer(Models.MCustomer pMCustomer)
        {
            pMCustomer.LListTypeIdentification = new List<SelectListItem>();
            pMCustomer.LListTypeIdentification = Models.MTypeIdentification.MListAllTypeIdentification(Bll_TypeIdentification.bll_getListTypeIdentification());
            pMCustomer.LListStatus = new List<SelectListItem>();
        }


        

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Bo_Customer oBCustomer = new Bo_Customer();
            oBCustomer = Bll_Customer.bll_GetCustomerById(id);
            return View(Models.MCustomer.MCustomerById(oBCustomer));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Models.MCustomer pMCustomer)
        {
            try
            {
                var lMessage = Bll_Customer.bll_DeleteCustomer(id);
                if (lMessage == null)
                {                   
                    return RedirectToAction("Index");
                }
                else
                {
                    pMCustomer.LMessageException = lMessage;
                    return View(pMCustomer);
                }

            }
            catch (Exception e)
            {
                pMCustomer.LMessageException = e.Message;
                return View(pMCustomer);
            }
        }
    }
}
