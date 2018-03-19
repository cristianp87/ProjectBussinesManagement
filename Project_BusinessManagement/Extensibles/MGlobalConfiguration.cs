using Project_BusinessManagement.Models;

namespace Project_BusinessManagement.Extensibles
{
    public static class MGlobalConfiguration
    {
        public static bool ToCompareconfiguration(this string pConfigurationApp)
        {
            var lParam = new MParameter();
            var lResult = false;
            if (pConfigurationApp.Equals("IsCustomer"))
                lResult = lParam.LIsModuleCustomer;
            if (pConfigurationApp.Equals("IsInvoice"))
                lResult = lParam.LIsModuleInvoice;
            if (pConfigurationApp.Equals("IsProduct"))
                lResult = lParam.LIsModuleProduct;
            if (pConfigurationApp.Equals("IsRealizeOrder"))
                lResult = lParam.LIsModuleRealizeOrder;
            if (pConfigurationApp.Equals("IsDashBoard"))
                lResult = lParam.LIsModuleDashBoard;
            if (pConfigurationApp.Equals("IsInventory"))
                lResult = lParam.LIsModuleInventory;
            if (pConfigurationApp.Equals("IsSupplier"))
                lResult = lParam.LIsModuleSupplier;
            if (pConfigurationApp.Equals("IsOrder"))
                lResult = lParam.LIsModuleOrder;
            if (pConfigurationApp.Equals("CreateCustomer"))
                lResult = lParam.LCreateCustomer;
            if (pConfigurationApp.Equals("EditCustomer"))
                lResult = lParam.LEditCustomer;
            if (pConfigurationApp.Equals("DeleteCustomer"))
                lResult = lParam.LDeleteCustomer;
            if (pConfigurationApp.Equals("CreateSupplier"))
                lResult = lParam.LCreateSupplier;
            if (pConfigurationApp.Equals("EditSupplier"))
                lResult = lParam.LEditSupplier;
            if (pConfigurationApp.Equals("DeleteSupplier"))
                lResult = lParam.LDeleteSupplier;
            if (pConfigurationApp.Equals("CreateDashBoard"))
                lResult = lParam.LCreateDashBoard;
            if (pConfigurationApp.Equals("EditDashBoard"))
                lResult = lParam.LEditDashBoard;
            if (pConfigurationApp.Equals("DeleteDashBoard"))
                lResult = lParam.LDeleteDashBoard;
            if (pConfigurationApp.Equals("CreateInventory"))
                lResult = lParam.LCreateInventory;
            if (pConfigurationApp.Equals("EditInventory"))
                lResult = lParam.LEditInventory;
            if (pConfigurationApp.Equals("DeleteInventory"))
                lResult = lParam.LDeleteInventory;
            if (pConfigurationApp.Equals("CreateProduct"))
                lResult = lParam.LCreateProduct;
            if (pConfigurationApp.Equals("EditProduct"))
                lResult = lParam.LEditProduct;
            if (pConfigurationApp.Equals("DeleteProduct"))
                lResult = lParam.LDeleteProduct;
            return lResult;
        }

        public static bool ValidateStatus(this string pIdStatus)
        {
            return pIdStatus.Equals("APPRO") || pIdStatus.Equals("INPRO");
        }


    }
}