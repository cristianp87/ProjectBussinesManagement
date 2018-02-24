using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using IDaoBusiness.Business;

namespace Dao_BussinessManagement
{
    public class DaoInvoice : IDaoInvoice
    {
        List<SqlParameter> LListParam { get; set; }

        public Bo_Invoice Dao_getInvoiceById(int pIdInvoice)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                var lInvoice = new Bo_Invoice();
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
                            lInvoice.LStatus = new Bo_Status();
                            lInvoice.LObject = new Bo_Object();
                            lInvoice.LCustomer = new Bo_Customer();
                            lInvoice.LListInvoiceItem = new List<Bo_InvoiceItem>();
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
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lInvoice;
                }
                catch (Exception e)
                {
                    lInvoice = new Bo_Invoice {LException = e.Message};
                    if (e.InnerException != null)
                        lInvoice.LInnerException = e.InnerException.ToString();
                    lInvoice.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lInvoice;
                }
            }
        }

        public List<Bo_Invoice> Dao_getInvoiceListAll(int pIdCustomer)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                var lListInvoice = new List<Bo_Invoice>();
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
                            var oInvoice = new Bo_Invoice
                            {
                                LStatus = new Bo_Status {LIdStatus = lReader["IdStatus"].ToString()},
                                LObject = new Bo_Object {LIdObject = Convert.ToInt32(lReader["IdObject"].ToString())},
                                LCustomer =
                                    new Bo_Customer
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
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lListInvoice;
                }
                catch (Exception e)
                {
                    lListInvoice = new List<Bo_Invoice>();
                    var lInvoice = new Bo_Invoice {LException = e.Message};
                    if (e.InnerException != null)
                        lInvoice.LInnerException = e.InnerException.ToString();
                    lInvoice.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    lListInvoice.Add(lInvoice);
                    return lListInvoice;
                }
            }
        }

        public string Dao_getCdInvoice()
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
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
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lResult;
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }

        public string Dao_InsertInvoice(Bo_Invoice pInvoice)
        {
            this.LListParam = new List<SqlParameter>();
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@CdInvoice", pInvoice.LCdInvoice);
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdCustomer", pInvoice.LCustomer.LIdCustomer.ToString());
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdOrder", pInvoice.LOrder.LIdOrder.ToString());
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pInvoice.LStatus.LIdStatus.ToString());
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pInvoice.LObject.LIdObject.ToString());
            return Dao_UtilsLib.Dao_executeSqlScalarWithProcedement(this.LListParam, "LTranInsertInvoice", "spr_CreateInvoice");
        }

        public string Dao_UpdateInvoice(Bo_Invoice pInvoice)
        {
            this.LListParam = new List<SqlParameter>();
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInvoice", pInvoice.LCustomer.LIdCustomer.ToString());
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@CdInvoice", pInvoice.LCdInvoice);
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdCustomer", pInvoice.LCustomer.LIdCustomer.ToString());
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pInvoice.LStatus.LIdStatus.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranUpdateInvoice", "spr_UpdateInvoice");
        }

        public string Dao_DeleteInvoice(Bo_Invoice pInvoice)
        {
            this.LListParam = new List<SqlParameter>();
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInvoice", pInvoice.LIdInvoice.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranDeleteInvoice", "spr_DeleteInvoice");
        }
    }
}
