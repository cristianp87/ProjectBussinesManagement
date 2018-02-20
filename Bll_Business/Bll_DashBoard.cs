using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;
using IBusiness.Management;
using IDaoBusiness.Business;

namespace Bll_Business
{
    public class BllDashBoard : IDashBoard
    {
        public IDaoDashBoard LiDashBoard { get; set; }

        public BllDashBoard()
        {
            this.LiDashBoard = new DaoDashBoard();
        }

        public List<Bo_DashBoard> bll_GetProductSellToday()
        {
            return this.LiDashBoard.Dao_getProductSellToday();
        }
    }
}
