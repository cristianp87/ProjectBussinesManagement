using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;
using IDaoBusiness.Business;
using System;
using System.Collections.Generic;

namespace Bll_Business
{
    public class BllReports : IReports
    {
        public IDaoReports LiDaoReports { get; set; }

        public IDaoCashRegister LiCashRegister { get; set; }

        public BllReports()
        {
            this.LiDaoReports = new DaoReports();
            this.LiCashRegister = new DaoCashRegister();
        }

        public List<BoReportSales> bll_SalesReport(DateTime pStarDate, DateTime pFinDate)
        {
            return LiDaoReports.Dao_getSalesReport(pStarDate, pFinDate);
        }

        public List<BoInventoryItem> bll_InventoryReport()
        {
            return LiDaoReports.Dao_getInventoryReport();
        }

        public List<BoReportAccountReceivable> bll_AccountReceivableReport()
        {
            return LiDaoReports.Dao_getAccountReceivable();
        }

        public List<BoCashRegister> bll_CashRegisterReport()
        {
            return this.LiCashRegister.Dao_getListLastCashRegister();
        }
    }
}
