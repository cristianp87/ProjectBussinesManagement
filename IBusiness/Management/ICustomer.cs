using BO_BusinessManagement;
using IBusiness.Common;
using System.Collections.Generic;

namespace IBusiness.Management
{
    public interface ICustomer: IFacade
    {
        #region Methods

        BoCustomer bll_GetCustomerById(int pIdCustomer);

        BoCustomer bll_GetCustomerByIdentification(string pNoIdentification, int pIdTypeIdentification);

        List<BoCustomer> bll_GetAllCustomer();

        string bll_InsertCustomer(string pNameCustomer,
            string pLastNameCustomer,
            string pNoIdentification,
            int pIdTypeIdentification,
            int pIdObject,
            string pIdStatus);

        string bll_UpdateCustomer(int pIdCustomer,
            string pNameCustomer,
            string pLastNameCustomer,
            string pNoIdentification,
            int pIdTypeIdentification,
            int pIdObject,
            string pIdStatus);

        string bll_DeleteCustomer(int pIdCustomer);

        #endregion
    }
}
