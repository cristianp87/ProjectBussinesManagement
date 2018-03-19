using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BO_BusinessManagement;
using IBusiness.Common;
using IBusiness.Management;
using Project_BusinessManagement.Filters;
using Project_BusinessManagement.Models;
using Project_BusinessManagement.Models.Enums;
using Project_BusinessManagement.Models.Mappers;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = EGlobalVariables.LRoleAdmin + EGlobalVariables.LQuote + EGlobalVariables.LRoleEmp1)]
    [ConfigurationApp(EGlobalVariables.LIsCustomer)]
    public class CustomerController : Controller
    {
        #region Variables and Constants
        public ICustomer LiCustomerFacade =
        FacadeProvider.Resolv<ICustomer>();

        public static ITypeIdentification LiTypeIdentification =
        FacadeProvider.Resolv<ITypeIdentification>();
        
        #endregion
        // GET: Customer
        public ActionResult Index()
        {            
            var lListCustomer = this.LiCustomerFacade.bll_GetAllCustomer();
            return this.View(lListCustomer.MListCustomer());
        }

        [HttpPost]
        public ActionResult Index(string pSearchhName)
        {
            var lListCustomer = this.LiCustomerFacade.bll_GetAllCustomer();
            if (string.IsNullOrEmpty(pSearchhName))
                return this.View(lListCustomer.MListCustomer());
            lListCustomer = lListCustomer.Where(s => s.LNameCustomer.ToUpper().Contains(pSearchhName.ToUpper())).ToList();
            return this.View(lListCustomer.MListCustomer());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var lCustomer = this.LiCustomerFacade.bll_GetCustomerById(id);
            return this.View(lCustomer.MCustomerById());
        }

        [ConfigurationApp(EGlobalVariables.LCreateCustomer)]
        // GET: Customer/Create
        public ActionResult Create()
        {
            var oBCustomer= new BoCustomer();
            return this.View(oBCustomer.MCustomerEmpty());
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(MCustomer pMCustomer)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    var lMessage = this.LiCustomerFacade.bll_InsertCustomer(pMCustomer.LNameCustomer, pMCustomer.LLastNameCustomer, pMCustomer.LNoIdentification, Convert.ToInt32(this.Request.Form[EFields.LFieldListTypeIdentification]), Convert.ToInt32(this.Request.Form[EFields.LFieldListObject]), this.Request.Form[EFields.LFieldListStatus]);
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index");
                    }
                    pMCustomer.LMessageException = lMessage;
                    ListEmptyCustomer(pMCustomer);
                    return this.View(pMCustomer);
                }
                ListEmptyCustomer(pMCustomer);
                return this.View(pMCustomer);
            }
            catch (Exception e)
            {
                pMCustomer.LMessageException = e.Message;
                ListEmptyCustomer(pMCustomer);
                return this.View(pMCustomer);
            }
        }

        [ConfigurationApp(EGlobalVariables.LEditCustomer)]
        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var oBCustomer = this.LiCustomerFacade.bll_GetCustomerById(id);
            return this.View(oBCustomer.MCustomerById());
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MCustomer pMCustomer)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    var lMessage = this.LiCustomerFacade.bll_UpdateCustomer(id, pMCustomer.LNameCustomer, pMCustomer.LLastNameCustomer, pMCustomer.LNoIdentification, Convert.ToInt32(this.Request.Form[EFields.LFieldListTypeIdentification]), Convert.ToInt32(this.Request.Form[EFields.LFieldListObject]), this.Request.Form[EFields.LFieldListStatus]);
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index");
                    }
                    pMCustomer.LMessageException = lMessage;
                    ListEmptyCustomer(pMCustomer);
                    return this.View(pMCustomer);
                }
                ListEmptyCustomer(pMCustomer);
                return this.View(pMCustomer);
            }
            catch (Exception e)
            {
                pMCustomer.LMessageException = e.Message;
                ListEmptyCustomer(pMCustomer);
                return this.View(pMCustomer);
            }
        }

        private static void ListEmptyCustomer(MCustomer pMCustomer)
        {
            pMCustomer.LListTypeIdentification = new List<SelectListItem>();
            pMCustomer.LListTypeIdentification = LiTypeIdentification.bll_getListTypeIdentification().MListAllTypeIdentification();
            pMCustomer.LListStatus = new List<SelectListItem>();
        }



        [ConfigurationApp(EGlobalVariables.LDeleteCustomer)]
        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var oBCustomer = this.LiCustomerFacade.bll_GetCustomerById(id);
            return this.View(oBCustomer.MCustomerById());
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MCustomer pMCustomer)
        {
            try
            {
                var lMessage = this.LiCustomerFacade.bll_DeleteCustomer(id);
                if (lMessage == null)
                {                   
                    return this.RedirectToAction("Index");
                }
                pMCustomer.LMessageException = lMessage;
                return this.View(pMCustomer);
            }
            catch (Exception e)
            {
                pMCustomer.LMessageException = e.Message;
                return this.View(pMCustomer);
            }
        }
    }
}
