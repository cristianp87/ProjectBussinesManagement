using System.Collections.Generic;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoOrderItem
    {
        List<BoOrderItem> Dao_getListOrderItem(int pIdOrder);

        string Dao_InsertOrderItem(BoOrderItem pOrderItem);
    }
}
