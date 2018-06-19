using BO_BusinessManagement;
using System;
using System.Collections.Generic;

namespace IDaoBusiness.Business
{
    public interface IDaoReports
    {
        List<BoReportSales> Dao_getSalesReport(DateTime pStartDate, DateTime pFinishDate);

        List<BoInventoryItem> Dao_getInventoryReport();

        List<BoReportAccountReceivable> Dao_getAccountReceivable();
    }
}
