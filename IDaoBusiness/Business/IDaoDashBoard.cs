using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoDashBoard
    {
        List<Bo_DashBoard> Dao_getProductSellToday();
    }
}
