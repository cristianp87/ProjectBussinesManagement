using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_BusinessManagement.Models;
namespace Project_BusinessManagement.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class ConfigurationAppAttribute : AuthorizeAttribute
    {
        private string lParameterStr { get; set; }
        public ConfigurationAppAttribute(string pParameter)
        {
            this.lParameterStr = pParameter;
        }
        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var lSkipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
            if(!lSkipAuthorization)
                base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            MParameter lParam = new MParameter();
            var lResult = false;
            if (lParameterStr.Equals("IsCustomer"))
            {
                lResult = lParam.lIsModuleCustomer;
            };
            if (lParameterStr.Equals("IsInvoice"))
            {
                lResult = lParam.lIsModuleInvoice;
            };
            if (lParameterStr.Equals("IsProduct"))
            {
                lResult = lParam.lIsModuleProduct;
            };
            if (lParameterStr.Equals("IsRealizeOrder"))
            {
                lResult = lParam.lIsModuleRealizeOrder;
            };
            if (lParameterStr.Equals("IsDashBoard"))
            {
                lResult = lParam.lIsModuleDashBoard;
            };
            if (lParameterStr.Equals("IsInventory"))
            {
                lResult = lParam.lIsModuleInventory;
            };
            if (lParameterStr.Equals("IsSupplier"))
            {
                lResult = lParam.lIsModuleSupplier;
            };
            if (lParameterStr.Equals("CreateCustomer")) {
                lResult = lParam.lCreateCustomer;
            };
            if (lParameterStr.Equals("EditCustomer"))
            {
                lResult = lParam.lEditCustomer;
            };
            if (lParameterStr.Equals("DeleteCustomer"))
            {
                lResult = lParam.lDeleteCustomer;
            };
            if (lParameterStr.Equals("CreateSupplier"))
            {
                lResult = lParam.lCreateSupplier;
            };
            if (lParameterStr.Equals("EditSupplier"))
            {
                lResult = lParam.lEditSupplier;
            };
            if (lParameterStr.Equals("DeleteSupplier"))
            {
                lResult = lParam.lDeleteSupplier;
            };
            if (lParameterStr.Equals("CreateDashBoard"))
            {
                lResult = lParam.lCreateDashBoard;
            };
            if (lParameterStr.Equals("EditDashBoard"))
            {
                lResult = lParam.lEditDashBoard;
            };
            if (lParameterStr.Equals("DeleteDashBoard"))
            {
                lResult = lParam.lDeleteDashBoard;
            };
            if (lParameterStr.Equals("CreateInventory"))
            {
                lResult = lParam.lCreateInventory;
            };
            if (lParameterStr.Equals("EditInventory"))
            {
                lResult = lParam.lEditInventory;
            };
            if (lParameterStr.Equals("DeleteInventory"))
            {
                lResult = lParam.lDeleteInventory;
            };
            if (lParameterStr.Equals("CreateProduct"))
            {
                lResult = lParam.lCreateProduct;
            };
            if (lParameterStr.Equals("EditProduct"))
            {
                lResult = lParam.lEditProduct;
            };
            if (lParameterStr.Equals("DeleteProduct"))
            {
                lResult = lParam.lDeleteProduct;
            };
            return lResult;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("~/Home/Index");
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}