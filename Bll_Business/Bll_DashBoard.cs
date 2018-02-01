using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;

namespace Bll_Business
{
    public class Bll_DashBoard
    {
        public static List<Bo_DashBoard> bll_GetProductSellToday()
        {
            Dao_DashBoard oDaodashBoard = new Dao_DashBoard();
            return oDaodashBoard.Dao_getProductSellToday();
        }
    }
}
