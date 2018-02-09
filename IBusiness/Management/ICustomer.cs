using BO_BusinessManagement;
using IBusiness.Common;
using System.Collections.Generic;

namespace IBusiness.Management
{
    public interface ICustomer: IFacade
    {
        #region Methods

        Bo_Customer bll_GetCustomerById(int pIdCustomer);

        Bo_Customer bll_GetCustomerByIdentification(string pNoIdentification, int pIdTypeIdentification);

        List<Bo_Customer> bll_GetAllCustomer();

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
