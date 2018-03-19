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

        public List<BoDashBoard> bll_GetProductSellToday()
        {
            return this.LiDashBoard.Dao_getProductSellToday();
        }
    }
}
