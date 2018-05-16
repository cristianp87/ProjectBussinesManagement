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
    public class DaoPayment : IDaoPayment
    {
        private List<SqlParameter> LListParam { get; set; }

        public List<BoPayment> Dao_getListPaymentByOrder(int lIdOrder)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lListPayment = new List<BoPayment>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListPaymentsByOrder",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add("IdOrder", SqlDbType.Int).Value = lIdOrder;
                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lPayment = new BoPayment
                            {
                                LStatus = new BoStatus
                                {
                                    LIdStatus = lReader["IdStatus"].ToString(),
                                    LDsEstado = lReader["DsEstado"].ToString()
                                },
                                LObject = new BoObject
                                {
                                    LIdObject = Convert.ToInt32(lReader["IdObject"].ToString()),
                                    LNameObject = lReader["NameObject"].ToString()
                                },
                                LCreationDate = Convert.ToDateTime(lReader["CreateDate"].ToString()),
                                LIdPayment = Convert.ToInt32(lReader["IdPayment"].ToString()),
                                LModificationDate = Convert.ToDateTime(lReader["ModificationDate"].ToString()),
                                LValuePayment = Convert.ToDecimal(lReader["ValuePayment"].ToString()),
                                LOrder = new BoOrder
                                {
                                    LIdOrder = Convert.ToInt32(lReader["IdOrder"].ToString()),
                                }
                            };
                            lListPayment.Add(lPayment);
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListPayment;
                }
                catch (Exception e)
                {
                    lListPayment = new List<BoPayment>();
                    var lPayment = new BoPayment
                    {
                        LException = e.Message,
                        LMessageDao = BoErrors.MsgErrorGetSql
                    };
                    if (e.InnerException != null)
                        lPayment.LInnerException = e.InnerException.ToString();
                    Dao_CloseSqlconnection(lConex);
                    lListPayment.Add(lPayment);
                    return lListPayment;
                }
            }
        }

        public BoPayment Dao_GetPayment(int pIdPayment)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lPayment = new BoPayment();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetPayment",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add("IdPayment", SqlDbType.Int).Value = pIdPayment;
                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            lPayment.LStatus = new BoStatus
                            {
                                LIdStatus = lReader["IdStatus"].ToString(),
                                LDsEstado = lReader["DsEstado"].ToString()
                            };
                            lPayment.LObject = new BoObject
                            {
                                LIdObject = Convert.ToInt32(lReader["IdObject"].ToString()),
                                LNameObject = lReader["NameObject"].ToString()
                            };
                            lPayment.LCreationDate = Convert.ToDateTime(lReader["CreateDate"].ToString());
                            lPayment.LIdPayment = Convert.ToInt32(lReader["IdPayment"].ToString());
                            lPayment.LModificationDate = Convert.ToDateTime(lReader["ModificationDate"].ToString());
                            lPayment.LValuePayment = Convert.ToDecimal(lReader["ValuePayment"].ToString());
                            lPayment.LOrder = new BoOrder
                            {
                                LIdOrder = Convert.ToInt32(lReader["IdOrder"].ToString()),
                            };
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lPayment;
                }
                catch (Exception e)
                {
                    lPayment = new BoPayment
                    {
                        LException = e.Message,
                        LMessageDao = BoErrors.MsgErrorGetSql
                    };
                    if (e.InnerException != null)
                        lPayment.LInnerException = e.InnerException.ToString();
                    Dao_CloseSqlconnection(lConex);
                    return lPayment;
                }
            }
        }


        public string Dao_InsertPayment(BoPayment pPayment)
        {
            this.LListParam = new List<SqlParameter>();
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdOrder", pPayment.LOrder.LIdOrder.ToString());
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValuePayment", pPayment.LValuePayment.ToString());
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pPayment.LStatus.LIdStatus);
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pPayment.LObject.LIdObject.ToString());
            return DaoUtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranInsertPayment", "spr_CreatePayment");
        }

        public string Dao_DeletePayment(BoPayment pPayment)
        {
            this.LListParam = new List<SqlParameter>();
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdPayment", pPayment.LIdPayment.ToString());
            return DaoUtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranDeletePayment", "spr_DeletePayment");
        }

    }
}
