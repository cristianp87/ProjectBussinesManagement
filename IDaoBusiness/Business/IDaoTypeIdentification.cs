using System.Collections.Generic;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoTypeIdentification
    {
        BoCustomer Dao_getTypeIdentification(int pIdTypeIdentification);

        List<BoTypeIdentification> Dao_getListAllTypeIdentification();

    }
}
