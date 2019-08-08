using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BO_BusinessManagement.Enums;
using IDaoBusiness.Business;

namespace Dao_BussinessManagement
{
    public class DaoInvoice : IDaoInvoice
    {
        List<SqlParameter> LListParam { get; set; }

        public BoInvoice Dao_getInvoiceById(int pIdInvoice)
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = DaoUtilsLib.Dao_SqlConnection(lConex))
            {
                var lInvoice = new BoInvoice();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetInvoice",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("IdInvoice", pIdInvoice));

                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            lInvoice.LStatus = new BoStatus();
                            lInvoice.LObject = new BoObject();
                            lInvoice.LCustomer = new BoCustomer();
                            lInvoice.LListInvoiceItem = new List<BoInvoiceItem>();
                            lInvoice.LIdInvoice = Convert.ToInt32(lReader["IdInvoice"].ToString());
                            lInvoice.LCdInvoice = lReader["CdInvoice"].ToString();
                            lInvoice.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            lInvoice.LCustomer.LIdCustomer = Convert.ToInt32(lReader["IdCustomer"].ToString());
                            lInvoice.LCustomer.LNameCustomer = lReader["NameCustomer"].ToString();
                            lInvoice.LCustomer.LLastNameCustomer = lReader["LastNameCustomer"].ToString();
                            lInvoice.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            lInvoice.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());                            
                        }
                    }
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return lInvoice;
                }
                catch (Exception e)
                {
                    lInvoice = new BoInvoice {LException = e.Message};
                    if (e.InnerException != null)
                        lInvoice.LInnerException = e.InnerException.ToString();
                    lInvoice.LMessageDao = BoErrors.MsgErrorGetSql;
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return lInvoice;
                }
            }
        }

        public List<BoInvoice> Dao_getInvoiceListAll(int pIdCustomer)
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = DaoUtilsLib.Dao_SqlConnection(lConex))
            {
                var lListInvoice = new List<BoInvoice>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListInvoiceAll",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("IdCustomer", pIdCustomer));
                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var oInvoice = new BoInvoice
                            {
                                LStatus = new BoStatus {LIdStatus = lReader["IdStatus"].ToString()},
                                LObject = new BoObject {LIdObject = Convert.ToInt32(lReader["IdObject"].ToString())},
                                LCustomer =
                                    new BoCustomer
                                    {
                                        LIdCustomer = Convert.ToInt32(lReader["IdCustomer"].ToString()),
                                        LNameCustomer = lReader["NameCustomer"].ToString(),
                                        LLastNameCustomer = lReader["LastNameCustomer"].ToString()
                                    },
                                LIdInvoice = Convert.ToInt32(lReader["IdInvoice"].ToString()),
                                LCdInvoice = lReader["CdInvoice"].ToString(),
                                LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString())
                            };
                            lListInvoice.Add(oInvoice);
                        }
                    }
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return lListInvoice;
                }
                catch (Exception e)
                {
                    lListInvoice = new List<BoInvoice>();
                    var lInvoice = new BoInvoice {LException = e.Message};
                    if (e.InnerException != null)
                        lInvoice.LInnerException = e.InnerException.ToString();
                    lInvoice.LMessageDao = BoErrors.MsgErrorGetSql;
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    lListInvoice.Add(lInvoice);
                    return lListInvoice;
                }
            }
        }

        public string Dao_getCdInvoice()
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = DaoUtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetCdInvoice",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    var lReader = lCommand.ExecuteReader();
                    var lResult = "";
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            lResult = lReader["CdInvoice"].ToString();   
                        }
                    }
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return lResult;
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }

        public string Dao_InsertInvoice(BoInvoice pInvoice)
        {
            this.LListParam = new List<SqlParameter>();
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@CdInvoice", pInvoice.LCdInvoice);
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdCustomer", pInvoice.LCustomer.LIdCustomer.ToString());
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdOrder", pInvoice.LOrder.LIdOrder.ToString());
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pInvoice.LStatus.LIdStatus);
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pInvoice.LObject.LIdObject.ToString());
            return DaoUtilsLib.Dao_executeSqlScalarWithProcedement(this.LListParam, "LTranInsertInvoice", "spr_CreateInvoice");
        }

        public string Dao_UpdateInvoice(BoInvoice pInvoice)
        {
            this.LListParam = new List<SqlParameter>();
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInvoice", pInvoice.LCustomer.LIdCustomer.ToString());
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@CdInvoice", pInvoice.LCdInvoice);
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdCustomer", pInvoice.LCustomer.LIdCustomer.ToString());
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pInvoice.LStatus.LIdStatus);
            return DaoUtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranUpdateInvoice", "spr_UpdateInvoice");
        }

        public string Dao_DeleteInvoice(BoInvoice pInvoice)
        {
            this.LListParam = new List<SqlParameter>();
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInvoice", pInvoice.LIdInvoice.ToString());
            return DaoUtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranDeleteInvoice", "spr_DeleteInvoice");
        }
    }
}
