using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;
using System.Collections.Generic;

namespace Bll_Business
{
    public class BllCustomer : ICustomer
    {
        public Bo_Customer bll_GetCustomerById(int pIdCustomer)
        {
            var oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_getCustomerById(pIdCustomer);
        }

        public Bo_Customer bll_GetCustomerByIdentification(string pNoIdentification, int pIdTypeIdentification)
        {
            var oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_getCustomerByDocument(pNoIdentification, pIdTypeIdentification);
        }

        public List<Bo_Customer> bll_GetAllCustomer()
        {
            var oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_getListAllCustomer();
        }

        public string bll_InsertCustomer(string pNameCustomer, string pLastNameCustomer, string pNoIdentification, int pIdTypeIdentification, int pIdObject, string pIdStatus)
        {
            var oCustomer = new Bo_Customer
            {
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus},
                LTypeIdentification = new Bo_TypeIdentification {LIdTypeIdentification = pIdTypeIdentification},
                LNameCustomer = pNameCustomer,
                LLastNameCustomer = pLastNameCustomer,
                LNoIdentification = pNoIdentification
            };
            var oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_InsertCustomer(oCustomer);
        }

        public string bll_UpdateCustomer(int pIdCustomer, string pNameCustomer, string pLastNameCustomer, string pNoIdentification, int pIdTypeIdentification, int pIdObject, string pIdStatus)
        {
            var oCustomer = new Bo_Customer
            {
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus},
                LTypeIdentification = new Bo_TypeIdentification {LIdTypeIdentification = pIdTypeIdentification},
                LIdCustomer = pIdCustomer,
                LNameCustomer = pNameCustomer,
                LLastNameCustomer = pLastNameCustomer,
                LNoIdentification = pNoIdentification
            };
            var oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_UpdateInventory(oCustomer);
        }

        public string bll_DeleteCustomer(int pIdCustomer)
        {
            var oCustomer = new Bo_Customer {LIdCustomer = pIdCustomer};
            var oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_DeleteInventory(oCustomer);
        }

        
    }
}
