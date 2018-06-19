using System.Collections.Generic;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoCustomer
    {
        BoCustomer Dao_getCustomerById(int pIdCustomer);

        BoCustomer Dao_getCustomerByDocument(string pNoIdentification, int pIdTypeIdentification);

        List<BoCustomer> Dao_getListAllCustomer();

        string Dao_InsertCustomer(BoCustomer pCustomer);

        string Dao_UpdateCustomer(BoCustomer pCustomer);

        string Dao_DeleteCustomer(BoCustomer pCustomer);


    }
}
