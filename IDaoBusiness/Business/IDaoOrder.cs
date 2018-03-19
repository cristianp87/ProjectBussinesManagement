using System.Collections.Generic;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoOrder
    {
        List<BoOrder> Dao_getListOrderByCustomer(int pIdCustomer);

        string Dao_InsertOrder(BoOrder pOrder);
    }
}
