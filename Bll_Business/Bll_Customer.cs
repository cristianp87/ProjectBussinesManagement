using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;
using System.Collections.Generic;
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
        public BoCustomer bll_GetCustomerById(int pIdCustomer)
        {
            return this.LiCustomer.Dao_getCustomerById(pIdCustomer);
        }

        public BoCustomer bll_GetCustomerByIdentification(string pNoIdentification, int pIdTypeIdentification)
        {
            return this.LiCustomer.Dao_getCustomerByDocument(pNoIdentification, pIdTypeIdentification);
        }

        public List<BoCustomer> bll_GetAllCustomer()
        {
            return this.LiCustomer.Dao_getListAllCustomer();
        }

        public string bll_InsertCustomer(string pNameCustomer, string pLastNameCustomer, string pNoIdentification, int pIdTypeIdentification, int pIdObject, string pIdStatus)
        {
            var oCustomer = new BoCustomer
            {
                LObject = new BoObject {LIdObject = pIdObject},
                LStatus = new BoStatus {LIdStatus = pIdStatus},
                LTypeIdentification = new BoTypeIdentification {LIdTypeIdentification = pIdTypeIdentification},
                LNameCustomer = pNameCustomer,
                LLastNameCustomer = pLastNameCustomer,
                LNoIdentification = pNoIdentification
            };
            return this.LiCustomer.Dao_InsertCustomer(oCustomer);
        }

        public string bll_UpdateCustomer(int pIdCustomer, string pNameCustomer, string pLastNameCustomer, string pNoIdentification, int pIdTypeIdentification, int pIdObject, string pIdStatus)
        {
            var oCustomer = new BoCustomer
            {
                LObject = new BoObject {LIdObject = pIdObject},
                LStatus = new BoStatus {LIdStatus = pIdStatus},
                LTypeIdentification = new BoTypeIdentification {LIdTypeIdentification = pIdTypeIdentification},
                LIdCustomer = pIdCustomer,
                LNameCustomer = pNameCustomer,
                LLastNameCustomer = pLastNameCustomer,
                LNoIdentification = pNoIdentification
            };
            return this.LiCustomer.Dao_UpdateCustomer(oCustomer);
        }

        public string bll_DeleteCustomer(int pIdCustomer)
        {
            var oCustomer = new BoCustomer {LIdCustomer = pIdCustomer};
            return this.LiCustomer.Dao_DeleteCustomer(oCustomer);
        }      
    }
}
