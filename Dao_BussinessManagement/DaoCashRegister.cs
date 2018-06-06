using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BO_BusinessManagement;
using System.Data;
using IDaoBusiness.Business;
using BO_BusinessManagement.Enums;
using static Dao_BussinessManagement.DaoUtilsLib;

namespace Dao_BussinessManagement
{
    public class DaoCashRegister : IDaoCashRegister
    {
        private List<SqlParameter> LListParam { get; set; }

        public List<BoCashRegister> Dao_getListLastCashRegister()
        {
            using (SqlConnection lConex = DaoUtilsLib.Dao_SqlConnection(lConex))
            {
                var lListCashRegister = new List<BoCashRegister>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetAllItemsCashRegister",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lCashRegister = new BoCashRegister
                            {
                                LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString()),
                                LModificationDate = Convert.ToDateTime(lReader["ModificationDate"].ToString()),
                                LValue = Convert.ToDecimal(lReader["Value"].ToString()),
                                LDescription = lReader["Description"].ToString(),
                                LIdCash = Convert.ToInt32(lReader["IdCash"].ToString()),
                                LIdCashRegister = Convert.ToInt32(lReader["IdCashRegister"].ToString()),
                                LIsInput = Convert.ToBoolean(lReader["IsInput"].ToString())
                            };
                            lListCashRegister.Add(lCashRegister);
                        }
                    }
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return lListCashRegister;
                }
                catch (Exception e)
                {
                    lListCashRegister = new List<BoCashRegister>();
                    var lCash = new BoCashRegister { LException = e.Message, LMessageDao = BoErrors.MsgErrorGetSql };
                    if (e.InnerException != null)
                        lCash.LInnerException = e.InnerException.ToString();
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    lListCashRegister.Add(lCash);
                    return lListCashRegister;
                }
            }
        }

        public int Dao_getFirstIdCashRegister()
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lIdCashRegister = 0; 
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetFirstCashRegister",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    var lReader = lCommand.ExecuteReader();

                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            lIdCashRegister = Convert.ToInt32(lReader["IdCashRegister"].ToString());
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lIdCashRegister;
                }
                catch (Exception)
                {
                    Dao_CloseSqlconnection(lConex);
                    return lIdCashRegister;
                }
            }
        }

        public List<BoCashRegister> Dao_getListCashInput()
        {
            using (SqlConnection lConex = DaoUtilsLib.Dao_SqlConnection(lConex))
            {
                var lListCashRegister = new List<BoCashRegister>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListCashInputs",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lCashRegister = new BoCashRegister
                            {
                                LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString()),
                                LModificationDate = Convert.ToDateTime(lReader["ModificationDate"].ToString()),
                                LValue = Convert.ToDecimal(lReader["Value"].ToString()),
                                LDescription = lReader["Description"].ToString(),
                                LIdCash = Convert.ToInt32(lReader["IdCash"].ToString()),
                                LIsInput = true
                            };
                            lListCashRegister.Add(lCashRegister);
                        }
                    }
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return lListCashRegister;
                }
                catch (Exception e)
                {
                    lListCashRegister = new List<BoCashRegister>();
                    var lCash = new BoCashRegister { LException = e.Message, LMessageDao = BoErrors.MsgErrorGetSql };
                    if (e.InnerException != null)
                        lCash.LInnerException = e.InnerException.ToString();
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    lListCashRegister.Add(lCash);
                    return lListCashRegister;
                }
            }
        }

        public List<BoCashRegister> Dao_getListCashOutputs()
        {
            using (SqlConnection lConex = DaoUtilsLib.Dao_SqlConnection(lConex))
            {
                var lListCashRegister = new List<BoCashRegister>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListCashOutPuts",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lCashRegister = new BoCashRegister
                            {
                                LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString()),
                                LModificationDate = Convert.ToDateTime(lReader["ModificationDate"].ToString()),
                                LValue = Convert.ToDecimal(lReader["Value"].ToString()),
                                LDescription = lReader["Description"].ToString(),
                                LIdCash = Convert.ToInt32(lReader["IdCash"].ToString()),
                                LIsInput = false
                            };
                            lListCashRegister.Add(lCashRegister);
                        }
                    }
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return lListCashRegister;
                }
                catch (Exception e)
                {
                    lListCashRegister = new List<BoCashRegister>();
                    var lCash = new BoCashRegister { LException = e.Message, LMessageDao = BoErrors.MsgErrorGetSql };
                    if (e.InnerException != null)
                        lCash.LInnerException = e.InnerException.ToString();
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    lListCashRegister.Add(lCash);
                    return lListCashRegister;
                }
            }
        }

        public string Dao_InsertCashRegisterInput(BoCashRegister pCashRegister)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdCashRegister", pCashRegister.LIdCashRegister.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueInput", pCashRegister.LValue.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@Description", pCashRegister.LDescription);
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranInsertCashInput", "spr_CreateCashInput");
        }

        public string Dao_InsertCashRegisterOutPut(BoCashRegister pCashRegister)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdCashRegister", pCashRegister.LIdCashRegister.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueInput", pCashRegister.LValue.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@Description", pCashRegister.LDescription);
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranInsertCashOutPut", "spr_CreateCashOutPut");
        }
    }
}
