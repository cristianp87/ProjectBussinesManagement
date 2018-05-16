using BO_BusinessManagement;
using System;
using System.Collections.Generic;

namespace IDaoBusiness.Business
{
    public interface IDaoReports
    {
        List<BoReportSales> Dao_getSupplierListAll(DateTime pStartDate, DateTime pFinishDate);
    }
}
