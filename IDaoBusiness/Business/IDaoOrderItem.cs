using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoOrderItem
    {
        List<Bo_OrderItem> Dao_getListOrderItem(int pIdOrder);

        string Dao_InsertOrderItem(Bo_OrderItem pOrderItem);
    }
}
