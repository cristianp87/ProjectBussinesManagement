using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;
using System.Collections.Generic;
using System.Data.SqlClient;
using IDaoBusiness.Business;

namespace Bll_Business
{
    public class BllCustomer : ICustomer
    {
        public IDaoCustomer LiCustomer { get; set; }

        public BllCustomer()
        {
            this.LiCustomer = new DaoCustomer();
        }
        public Bo_Customer bll_GetCustomerById(int pIdCustomer)
        {
            return this.LiCustomer.Dao_getCustomerById(pIdCustomer);
        }

        public Bo_Customer bll_GetCustomerByIdentification(string pNoIdentification, int pIdTypeIdentification)
        {
            return this.LiCustomer.Dao_getCustomerByDocument(pNoIdentification, pIdTypeIdentification);
        }

        public List<Bo_Customer> bll_GetAllCustomer()
        {
            return this.LiCustomer.Dao_getListAllCustomer();
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
            return this.LiCustomer.Dao_InsertCustomer(oCustomer);
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
            return this.LiCustomer.Dao_UpdateCustomer(oCustomer);
        }

        public string bll_DeleteCustomer(int pIdCustomer)
        {
            var oCustomer = new Bo_Customer {LIdCustomer = pIdCustomer};
            return this.LiCustomer.Dao_DeleteCustomer(oCustomer);
        }

        
    }
}
