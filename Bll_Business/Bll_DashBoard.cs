using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;
using IBusiness.Management;

namespace Bll_Business
{
    public class BllDashBoard : IDashBoard
    {
        public List<Bo_DashBoard> bll_GetProductSellToday()
        {
            var oDaodashBoard = new Dao_DashBoard();
            return oDaodashBoard.Dao_getProductSellToday();
        }
    }
}
