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
        public List<BoReportSales> Dao_getSalesReport(DateTime pStartDate, DateTime pFinishDate)
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = Dao_SqlConnection(lConex))
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
                                LCdProduct = lReader["CdProduct"].ToString(),
                                LValueSupplier = Convert.ToDecimal(lReader["PriceSupplier"].ToString())
                            };
                            lReport.LQty = Convert.ToDecimal(lReader["Qty"].ToString());
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

        public List<BoInventoryItem> Dao_getInventoryReport()
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = Dao_SqlConnection(lConex))
            {
                var lListReport = new List<BoInventoryItem>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_ReportInventory",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lReport = new BoInventoryItem
                            {
                                LInventory = new BoInventory
                                {
                                    LIdInventory = Convert.ToInt32(lReader["IdInventory"].ToString()),
                                    LNameInventory = lReader["NameInventory"].ToString()
                                },
                                LProduct = new BoProduct
                                {
                                    LIdProduct = Convert.ToInt32(lReader["IdProduct"].ToString()),
                                    LCdProduct = lReader["CdProduct"].ToString(),
                                    LNameProduct = lReader["NameProduct"].ToString()
                                },
                                LQtySellable = Convert.ToDecimal(lReader["QtySellable"].ToString()),
                                LQtyNonSellable = Convert.ToDecimal(lReader["QtyNonSellable"].ToString()),
                            };                          
                            lListReport.Add(lReport);
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListReport;
                }
                catch (Exception e)
                {
                    lListReport = new List<BoInventoryItem>();
                    var lReport = new BoInventoryItem
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

        public List<BoReportAccountReceivable> Dao_getAccountReceivable()
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = Dao_SqlConnection(lConex))
            {
                var lListReport = new List<BoReportAccountReceivable>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_ReportAccountReceivable",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lReport = new BoReportAccountReceivable
                            {
                                LId = Convert.ToInt32(lReader["IdOrder"].ToString()),
                                LValueDebt = Convert.ToDecimal(lReader["ValueDebt"].ToString()),
                                LCustomer = new BoCustomer
                                {
                                    LIdCustomer = Convert.ToInt32(lReader["IdCustomer"].ToString()),
                                    LNameCustomer = lReader["NameCustomer"].ToString(),
                                    LLastNameCustomer = lReader["LastNameCustomer"].ToString()
                                }
                            };
                            lListReport.Add(lReport);
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListReport;
                }
                catch (Exception e)
                {
                    lListReport = new List<BoReportAccountReceivable>();
                    var lReport = new BoReportAccountReceivable
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
