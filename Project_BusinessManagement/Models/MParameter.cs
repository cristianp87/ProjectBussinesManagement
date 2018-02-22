using IBusiness.Common;
using IBusiness.Management;

namespace Project_BusinessManagement.Models
{
    public class MParameter
    {
        #region Variables and constants

        public static IUtilsLib LiUtilsLib =
        FacadeProvider.Resolver<IUtilsLib>();
        #endregion
        string myLResult;
        bool myLBool;
        int myLInt;
        public MParameter()
        {
            this.myLResult = null;
            this.myLBool = false;
            this.myLInt = 0;
        }
        public bool LCreateCustomer
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("create", "moduleCustomer");
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }
        public bool LEditCustomer
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("Edit", "moduleCustomer");
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public bool LDeleteCustomer
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("Delete", "moduleCustomer");
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public bool LCreateSupplier
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("create", "moduleSupplier");
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }
        public bool LEditSupplier
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("Edit", "moduleSupplier");
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public bool LDeleteSupplier
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("Delete", "moduleSupplier");
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public bool LCreateDashBoard
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("create", "moduleDashBoard");
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }
        public bool LEditDashBoard
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("Edit", "moduleDashBoard");
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public bool LDeleteDashBoard
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("Delete", "moduleDashBoard");
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public bool LCreateInventory
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("create", "moduleInventory");
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }
        public bool LEditInventory
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("Edit", "moduleInventory");
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public bool LDeleteInventory
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("Delete", "moduleInventory");
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public bool LCreateProduct
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("create", "moduleProduct");
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }
        public bool LEditProduct
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("Edit", "moduleProduct");
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public bool LDeleteProduct
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("Delete", "moduleProduct");
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public bool LIsModuleProduct
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("moduleProduct", true);
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public bool LIsModuleRealizeOrder
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("moduleRealizeOrder", true);
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public bool LIsModuleInventory
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("moduleInventory", true);
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public bool LIsModuleDashBoard
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("moduleDashBoard", true);
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public bool LIsModuleSupplier
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("moduleSupplier", true);
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public bool LIsModuleCustomer
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("moduleCustomer", true);

                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public bool LIsModuleInvoice
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("moduleInvoice", true);
                return bool.TryParse(this.myLResult, out this.myLBool) ? this.myLBool : this.myLBool;
            }
        }

        public int LStartNumberInvoice
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("StartNumberInvoice", "moduleInvoice");
                return int.TryParse(this.myLResult, out this.myLInt) ? this.myLInt : this.myLInt;
            }
        }

        public string LPrefixInvoice
        {
            get
            {
                this.myLResult = LiUtilsLib.bll_GetValueParameter("PrefixInvoice", "moduleInvoice");
                return this.myLResult;
            }
        }
    }
}