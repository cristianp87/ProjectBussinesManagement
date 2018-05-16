using BO_BusinessManagement;
using BO_BusinessManagement.Enums;
using IDaoBusiness.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static Dao_BussinessManagement.DaoUtilsLib;

namespace Dao_BussinessManagement
{
    public class DaoReports : IDaoReports
    {
        public List<BoReportSales> Dao_getSupplierListAll(DateTime pStartDate, DateTime pFinishDate)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lListReport = new List<BoReportSales>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_ReportSales",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("startDate", pStartDate));
                    lCommand.Parameters.Add(new SqlParameter("finDate", pFinishDate));
                    var lReader = lCommand.ExecuteReader();                  
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lReport = new BoReportSales();
                            lReport.LCode = lReader["Codes"].ToString();
                            lReport.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            lReport.LId = Convert.ToInt32(lReader["Id"].ToString());
                            lReport.LProduct = new BoProduct()
                            {
                                LIdProduct = Convert.ToInt32(lReader["IdProduct"].ToString()),
                                LNameProduct = lReader["NameProduct"].ToString(),
                                LCdProduct = lReader["CdProduct"].ToString()
                            };
                            lReport.LValuetotal = Convert.ToDecimal(lReader["valuetotal"].ToString());
                            lListReport.Add(lReport);
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListReport;
                }
                catch (Exception e)
                {
                    lListReport = new List<BoReportSales>();
                    var lReport = new BoReportSales
                    {
                        LException = e.Message,
                        LMessageDao = BoErrors.MsgErrorGetSql
                    };
                    
                    if (e.InnerException != null)
                        lReport.LInnerException = e.InnerException.ToString();
                    Dao_CloseSqlconnection(lConex);
                    lListReport.Add(lReport);
                    return lListReport;
                }
            }
        }
    }
}
