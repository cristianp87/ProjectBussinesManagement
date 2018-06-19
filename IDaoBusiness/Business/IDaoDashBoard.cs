using System.Collections.Generic;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoDashBoard
    {
        List<BoDashBoard> Dao_getProductSellToday();
    }
}
