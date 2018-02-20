using System.Collections.Generic;
using System.Data.SqlClient;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoCustomer
    {
        Bo_Customer Dao_getCustomerById(int pIdCustomer);

        Bo_Customer Dao_getCustomerByDocument(string pNoIdentification, int pIdTypeIdentification);

        List<Bo_Customer> Dao_getListAllCustomer();

        string Dao_InsertCustomer(Bo_Customer pCustomer);

        string Dao_UpdateCustomer(Bo_Customer pCustomer);

        string Dao_DeleteCustomer(Bo_Customer pCustomer);


    }
}
