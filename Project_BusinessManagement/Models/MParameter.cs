﻿using Bll_Business;
using IBusiness.Common;
using IBusiness.Management;

namespace Project_BusinessManagement.Models
{
    public class MParameter
    {
        #region Variables and constants

        public static IUtilsLib LiUtilsLib =
        FacadeProvider.Resolver<BllUtilsLib>();
        #endregion
        string lResult;
        bool lBool;
        int lInt;
        public MParameter()
        {
            lResult = null;
            lBool = false;
            lInt = 0;
        }
        public bool lCreateCustomer
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("create", "moduleCustomer");
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }
        public bool lEditCustomer
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("Edit", "moduleCustomer");
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public bool lDeleteCustomer
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("Delete", "moduleCustomer");
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public bool lCreateSupplier
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("create", "moduleSupplier");
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }
        public bool lEditSupplier
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("Edit", "moduleSupplier");
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public bool lDeleteSupplier
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("Delete", "moduleSupplier");
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public bool lCreateDashBoard
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("create", "moduleDashBoard");
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }
        public bool lEditDashBoard
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("Edit", "moduleDashBoard");
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public bool lDeleteDashBoard
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("Delete", "moduleDashBoard");
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public bool lCreateInventory
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("create", "moduleInventory");
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }
        public bool lEditInventory
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("Edit", "moduleInventory");
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public bool lDeleteInventory
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("Delete", "moduleInventory");
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public bool lCreateProduct
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("create", "moduleProduct");
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }
        public bool lEditProduct
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("Edit", "moduleProduct");
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public bool lDeleteProduct
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("Delete", "moduleProduct");
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public bool lIsModuleProduct
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("moduleProduct", true);
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public bool lIsModuleRealizeOrder
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("moduleRealizeOrder", true);
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public bool lIsModuleInventory
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("moduleInventory", true);
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public bool lIsModuleDashBoard
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("moduleDashBoard", true);
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public bool lIsModuleSupplier
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("moduleSupplier", true);
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public bool lIsModuleCustomer
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("moduleCustomer", true);

                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public bool lIsModuleInvoice
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("moduleInvoice", true);
                if (bool.TryParse(lResult, out lBool))
                    return lBool;
                else
                    return lBool;
            }
        }

        public int lStartNumberInvoice
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("StartNumberInvoice", "moduleInvoice");
                if (int.TryParse(lResult, out lInt))
                    return lInt;
                else
                    return lInt;
            }
        }

        public string lPrefixInvoice
        {
            get
            {
                lResult = LiUtilsLib.bll_GetValueParameter("PrefixInvoice", "moduleInvoice");
                return lResult;
            }
        }
    }
}