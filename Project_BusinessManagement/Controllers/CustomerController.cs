using BO_BusinessManagement;
using IBusiness.Management;
using Project_BusinessManagement.Filters;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using IBusiness.Common;
using static Project_BusinessManagement.Models.MCustomer;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = "Administrador, Cajero")]
    [ConfigurationApp( "IsCustomer")]
    public class CustomerController : Controller
    {
        #region Variables and Constants
        public ICustomer LCustomerFacade =
        FacadeProvider.Resolver<ICustomer>();

        public static ITypeIdentification LiTypeIdentification =
        FacadeProvider.Resolver<ITypeIdentification>();
        
        #endregion
        // GET: Customer
        public ActionResult Index()
        {
            var lBoListCustomer = this.LCustomerFacade.bll_GetAllCustomer();
            return this.View(MListCustomer(lBoListCustomer));
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var lBoCustomer = this.LCustomerFacade.bll_GetCustomerById(id);
            return this.View(MCustomerById(lBoCustomer));
        }

        [ConfigurationApp(pParameter: "CreateCustomer")]
        // GET: Customer/Create
        public ActionResult Create()
        {
            var oBCustomer= new Bo_Customer();
            return this.View(MCustomerEmpty(oBCustomer));
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Models.MCustomer pMCustomer)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    var lMessage = this.LCustomerFacade.bll_InsertCustomer(this.Request.Form["LNameCustomer"], this.Request.Form["LLastNameCustomer"], this.Request.Form["LNoIdentification"], Convert.ToInt32(this.Request.Form["LTypeIdentification.LIdTypeIdentification"]), Convert.ToInt32(this.Request.Form["LObject.LIdObject"]), this.Request.Form["LStatus.LIdStatus"]);
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index");
                    }
                    else
                    {
                        pMCustomer.LMessageException = lMessage;
                        ListEmptyCustomer(pMCustomer);
                        return this.View(pMCustomer);
                    }

                }
                else
                {
                    ListEmptyCustomer(pMCustomer);
                    return this.View(pMCustomer);
                }

            }
            catch (Exception e)
            {
                pMCustomer.LMessageException = e.Message;
                ListEmptyCustomer(pMCustomer);
                return this.View(pMCustomer);
            }
        }

        [ConfigurationApp("EditCustomer")]
        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var oBCustomer = this.LCustomerFacade.bll_GetCustomerById(id);
            return this.View(MCustomerById(oBCustomer));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.MCustomer pMCustomer)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    var lMessage = this.LCustomerFacade.bll_UpdateCustomer(id, this.Request.Form["LNameCustomer"].ToString(), this.Request.Form["LLastNameCustomer"].ToString(), this.Request.Form["LNoIdentification"].ToString(), Convert.ToInt32(this.Request.Form["LTypeIdentification.LIdTypeIdentification"].ToString()), Convert.ToInt32(this.Request.Form["LObject.LIdObject"].ToString()), this.Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index");
                    }
                    else
                    {
                        pMCustomer.LMessageException = lMessage;
                        ListEmptyCustomer(pMCustomer);
                        return this.View(pMCustomer);
                    }
                }
                else
                {
                    ListEmptyCustomer(pMCustomer);
                    return this.View(pMCustomer);
                }

            }
            catch (Exception e)
            {
                pMCustomer.LMessageException = e.Message;
                ListEmptyCustomer(pMCustomer);
                return this.View(pMCustomer);
            }
        }

        private static void ListEmptyCustomer(Models.MCustomer pMCustomer)
        {
            pMCustomer.LListTypeIdentification = new List<SelectListItem>();
            pMCustomer.LListTypeIdentification = Models.MTypeIdentification.MListAllTypeIdentification(LiTypeIdentification.bll_getListTypeIdentification());
            pMCustomer.LListStatus = new List<SelectListItem>();
        }



        [ConfigurationApp("DeleteCustomer")]
        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var oBCustomer = this.LCustomerFacade.bll_GetCustomerById(id);
            return this.View(MCustomerById(oBCustomer));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Models.MCustomer pMCustomer)
        {
            try
            {
                var lMessage = this.LCustomerFacade.bll_DeleteCustomer(id);
                if (lMessage == null)
                {                   
                    return this.RedirectToAction("Index");
                }
                else
                {
                    pMCustomer.LMessageException = lMessage;
                    return this.View(pMCustomer);
                }

            }
            catch (Exception e)
            {
                pMCustomer.LMessageException = e.Message;
                return this.View(pMCustomer);
            }
        }
    }
}
