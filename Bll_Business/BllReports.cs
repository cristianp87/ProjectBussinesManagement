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

        public BllReports()
        {
            this.LiDaoReports = new DaoReports();
        }

        public List<BoReportSales> bll_SalesReport(DateTime pStarDate, DateTime pFinDate)
        {
            return LiDaoReports.Dao_getSupplierListAll(pStarDate, pFinDate);
        }

    }
}
