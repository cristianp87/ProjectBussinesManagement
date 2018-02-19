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
                lResult = lParam.LIsModuleCustomer;
            };
            if (lParameterStr.Equals("IsInvoice"))
            {
                lResult = lParam.LIsModuleInvoice;
            };
            if (lParameterStr.Equals("IsProduct"))
            {
                lResult = lParam.LIsModuleProduct;
            };
            if (lParameterStr.Equals("IsRealizeOrder"))
            {
                lResult = lParam.LIsModuleRealizeOrder;
            };
            if (lParameterStr.Equals("IsDashBoard"))
            {
                lResult = lParam.LIsModuleDashBoard;
            };
            if (lParameterStr.Equals("IsInventory"))
            {
                lResult = lParam.LIsModuleInventory;
            };
            if (lParameterStr.Equals("IsSupplier"))
            {
                lResult = lParam.LIsModuleSupplier;
            };
            if (lParameterStr.Equals("CreateCustomer")) {
                lResult = lParam.LCreateCustomer;
            };
            if (lParameterStr.Equals("EditCustomer"))
            {
                lResult = lParam.LEditCustomer;
            };
            if (lParameterStr.Equals("DeleteCustomer"))
            {
                lResult = lParam.LDeleteCustomer;
            };
            if (lParameterStr.Equals("CreateSupplier"))
            {
                lResult = lParam.LCreateSupplier;
            };
            if (lParameterStr.Equals("EditSupplier"))
            {
                lResult = lParam.LEditSupplier;
            };
            if (lParameterStr.Equals("DeleteSupplier"))
            {
                lResult = lParam.LDeleteSupplier;
            };
            if (lParameterStr.Equals("CreateDashBoard"))
            {
                lResult = lParam.LCreateDashBoard;
            };
            if (lParameterStr.Equals("EditDashBoard"))
            {
                lResult = lParam.LEditDashBoard;
            };
            if (lParameterStr.Equals("DeleteDashBoard"))
            {
                lResult = lParam.LDeleteDashBoard;
            };
            if (lParameterStr.Equals("CreateInventory"))
            {
                lResult = lParam.LCreateInventory;
            };
            if (lParameterStr.Equals("EditInventory"))
            {
                lResult = lParam.LEditInventory;
            };
            if (lParameterStr.Equals("DeleteInventory"))
            {
                lResult = lParam.LDeleteInventory;
            };
            if (lParameterStr.Equals("CreateProduct"))
            {
                lResult = lParam.LCreateProduct;
            };
            if (lParameterStr.Equals("EditProduct"))
            {
                lResult = lParam.LEditProduct;
            };
            if (lParameterStr.Equals("DeleteProduct"))
            {
                lResult = lParam.LDeleteProduct;
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