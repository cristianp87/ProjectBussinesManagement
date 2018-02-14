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
            Dao_Customer oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_getCustomerById(pIdCustomer);
        }

        public Bo_Customer bll_GetCustomerByIdentification(string pNoIdentification, int pIdTypeIdentification)
        {
            Dao_Customer oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_getCustomerByDocument(pNoIdentification, pIdTypeIdentification);
        }

        public List<Bo_Customer> bll_GetAllCustomer()
        {
            Dao_Customer oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_getListAllCustomer();
        }

        public string bll_InsertCustomer(string pNameCustomer, string pLastNameCustomer, string pNoIdentification, int pIdTypeIdentification, int pIdObject, string pIdStatus)
        {
            Bo_Customer oCustomer = new Bo_Customer();
            oCustomer.LObject = new Bo_Object();
            oCustomer.LStatus = new Bo_Status();
            oCustomer.LTypeIdentification = new Bo_TypeIdentification();
            oCustomer.LNameCustomer = pNameCustomer;
            oCustomer.LLastNameCustomer = pLastNameCustomer;
            oCustomer.LNoIdentification = pNoIdentification;
            oCustomer.LTypeIdentification.LIdTypeIdentification = pIdTypeIdentification;
            oCustomer.LObject.LIdObject = pIdObject;
            oCustomer.LStatus.LIdStatus = pIdStatus;
            Dao_Customer oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_InsertCustomer(oCustomer);
        }

        public string bll_UpdateCustomer(int pIdCustomer, string pNameCustomer, string pLastNameCustomer, string pNoIdentification, int pIdTypeIdentification, int pIdObject, string pIdStatus)
        {
            Bo_Customer oCustomer = new Bo_Customer();
            oCustomer.LObject = new Bo_Object();
            oCustomer.LStatus = new Bo_Status();
            oCustomer.LTypeIdentification = new Bo_TypeIdentification();
            oCustomer.LIdCustomer = pIdCustomer;
            oCustomer.LNameCustomer = pNameCustomer;
            oCustomer.LLastNameCustomer = pLastNameCustomer;
            oCustomer.LNoIdentification = pNoIdentification;
            oCustomer.LTypeIdentification.LIdTypeIdentification = pIdTypeIdentification;
            oCustomer.LObject.LIdObject = pIdObject;
            oCustomer.LStatus.LIdStatus = pIdStatus;
            Dao_Customer oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_UpdateInventory(oCustomer);
        }

        public string bll_DeleteCustomer(int pIdCustomer)
        {
            Bo_Customer oCustomer = new Bo_Customer();
            oCustomer.LIdCustomer = pIdCustomer;
            Dao_Customer oDaoCustomer = new Dao_Customer();
            return oDaoCustomer.Dao_DeleteInventory(oCustomer);
        }

        
    }
}
