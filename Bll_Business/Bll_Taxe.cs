using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using Dao_BussinessManagement;

namespace Bll_Business
{
    public class Bll_Taxe
    {
        public static List<Bo_Taxe>  bll_GetListallTaxesXProduct(int pIdProduct)
        {
            Dao_Taxe oDaoTaxe = new Dao_Taxe();
            return oDaoTaxe.Dao_getLisAllTaxesXProduct(pIdProduct);
        }
    }
}
