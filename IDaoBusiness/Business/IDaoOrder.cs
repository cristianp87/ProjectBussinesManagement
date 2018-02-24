using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoOrder
    {
        List<Bo_Order> Dao_getListOrderByCustomer(int pIdCustomer);

        string Dao_InsertOrder(Bo_Order pOrder);
    }
}
