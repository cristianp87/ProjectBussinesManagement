using BO_BusinessManagement;
using IBusiness.Common;
using System;
using System.Collections.Generic;

namespace IBusiness.Management
{
    public interface IReports : IFacade
    {
        List<BoReportSales> bll_SalesReport(DateTime pStarDate, DateTime pFinDate);
    }
}
