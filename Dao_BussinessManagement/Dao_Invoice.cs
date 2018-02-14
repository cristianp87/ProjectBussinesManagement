using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Dao_BussinessManagement
{
    public class Dao_Invoice
    {
        List<SqlParameter> lListParam = new List<SqlParameter>();

        public Bo_Invoice Dao_getInvoiceById(int pIdInvoice)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetInvoice";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("IdInvoice", pIdInvoice));

                    var lReader = lCommand.ExecuteReader();
                    Bo_Invoice oInvoice = new Bo_Invoice();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            oInvoice.LStatus = new Bo_Status();
                            oInvoice.LObject = new Bo_Object();
                            oInvoice.LCustomer = new Bo_Customer();
                            oInvoice.LListInvoiceItem = new List<Bo_InvoiceItem>();
                            oInvoice.LIdInvoice = Convert.ToInt32(lReader["IdInvoice"].ToString());
                            oInvoice.LCdInvoice = lReader["CdInvoice"].ToString();
                            oInvoice.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oInvoice.LCustomer.LIdCustomer = Convert.ToInt32(lReader["IdCustomer"].ToString());
                            oInvoice.LCustomer.LNameCustomer = lReader["NameCustomer"].ToString();
                            oInvoice.LCustomer.LLastNameCustomer = lReader["LastNameCustomer"].ToString();
                            oInvoice.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oInvoice.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            Dao_InvoiceItem oLInvoiceItem = new Dao_InvoiceItem();
                            oInvoice.LListInvoiceItem = oLInvoiceItem.Dao_getInvoiceItemByIdInvoice(oInvoice.LIdInvoice);
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oInvoice;
                }
                catch (Exception e)
                {
                    Bo_Invoice oInvoice = new Bo_Invoice();
                    oInvoice.LException = e.Message;
                    if (e.InnerException != null)
                        oInvoice.LInnerException = e.InnerException.ToString();
                    oInvoice.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oInvoice;
                }
            }
        }

        public List<Bo_Invoice> Dao_getInvoiceListAll(int pIdCustomer)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetListInvoiceAll";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("IdCustomer", pIdCustomer));
                    var lReader = lCommand.ExecuteReader();
                    List<Bo_Invoice> oListInvoice = new List<Bo_Invoice>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_Invoice oInvoice = new Bo_Invoice();
                            oInvoice.LStatus = new Bo_Status();
                            oInvoice.LObject = new Bo_Object();
                            oInvoice.LCustomer = new Bo_Customer();
                            oInvoice.LIdInvoice = Convert.ToInt32(lReader["IdInvoice"].ToString());
                            oInvoice.LCdInvoice = lReader["CdInvoice"].ToString();
                            oInvoice.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oInvoice.LCustomer.LIdCustomer = Convert.ToInt32(lReader["IdCustomer"].ToString());
                            oInvoice.LCustomer.LNameCustomer = lReader["NameCustomer"].ToString();
                            oInvoice.LCustomer.LLastNameCustomer = lReader["LastNameCustomer"].ToString();
                            oInvoice.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oInvoice.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            oListInvoice.Add(oInvoice);
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListInvoice;
                }
                catch (Exception e)
                {
                    List<Bo_Invoice> oListInvoice = new List<Bo_Invoice>();
                    Bo_Invoice oInvoice = new Bo_Invoice();
                    oInvoice.LException = e.Message;
                    if (e.InnerException != null)
                        oInvoice.LInnerException = e.InnerException.ToString();
                    oInvoice.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    oListInvoice.Add(oInvoice);
                    return oListInvoice;
                }
            }
        }

        public string Dao_getCdInvoice()
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetCdInvoice";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    var lReader = lCommand.ExecuteReader();
                    string lResult = "";
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
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@CdInvoice", pInvoice.LCdInvoice);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdCustomer", pInvoice.LCustomer.LIdCustomer.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdOrder", pInvoice.LOrder.LIdOrder.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pInvoice.LStatus.LIdStatus.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdObject", pInvoice.LObject.LIdObject.ToString());
            return Dao_UtilsLib.Dao_executeSqlScalarWithProcedement(lListParam, "LTranInsertInvoice", "spr_CreateInvoice");
        }

        public string Dao_UpdateInvoice(Bo_Invoice pInvoice)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdInvoice", pInvoice.LCustomer.LIdCustomer.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@CdInvoice", pInvoice.LCdInvoice);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdCustomer", pInvoice.LCustomer.LIdCustomer.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pInvoice.LStatus.LIdStatus.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranUpdateInvoice", "spr_UpdateInvoice");
        }

        public string Dao_DeleteInvoice(Bo_Invoice pInvoice)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdInvoice", pInvoice.LIdInvoice.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranDeleteInvoice", "spr_DeleteInvoice");
        }
    }
}
