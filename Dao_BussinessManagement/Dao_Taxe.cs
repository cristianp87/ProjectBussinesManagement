using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BO_BusinessManagement.Enums;
using IDaoBusiness.Business;
using static Dao_BussinessManagement.DaoUtilsLib;

namespace Dao_BussinessManagement
{
    public class DaoTaxe : IDaoTaxe
    {
        private List<SqlParameter> LListParam { get; set; }
        public List<BoTaxe> Dao_getLisAllTaxesXProduct(int idProduct)
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = Dao_SqlConnection(lConex))
            {
                var lListTaxe = new List<BoTaxe>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListAllTaxesXProduct",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add("idProduct", SqlDbType.Int).Value = idProduct;
                    var lReader = lCommand.ExecuteReader();                  
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lTaxe = new BoTaxe
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
                                LIdTaxe = Convert.ToInt32(lReader["IdTax"].ToString()),
                                LNameTaxe = lReader["NameTax"].ToString(),
                                LIsPercent = Convert.ToBoolean(lReader["IsPercent"].ToString()),
                                LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString()),
                                LValueTaxe = Convert.ToDecimal(lReader["ValueTax"].ToString())
                            };
                            lListTaxe.Add(lTaxe);
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListTaxe;
                }
                catch (Exception e)
                {
                    lListTaxe = new List<BoTaxe>();
                    var lTaxe = new BoTaxe
                    {
                        LException = e.Message,
                        LMessageDao = BoErrors.MsgErrorGetSql
                };
                    if (e.InnerException != null)
                        lTaxe.LInnerException = e.InnerException.ToString();                  
                    Dao_CloseSqlconnection(lConex);
                    lListTaxe.Add(lTaxe);
                    return lListTaxe;
                }
            }
        }

        public List<BoTaxe> Dao_getLisTaxes()
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = Dao_SqlConnection(lConex))
            {
                var lListTaxe = new List<BoTaxe>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListTaxes",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    var lReader = lCommand.ExecuteReader();
                    
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lTaxe = new BoTaxe
                            {
                                LStatus = new BoStatus
                                {
                                    LIdStatus = lReader["IdStatus"].ToString(),
                                    LNameStatus = lReader["NameStatus"].ToString()
                                },
                                LObject = new BoObject
                                {
                                    LIdObject = Convert.ToInt32(lReader["IdObject"].ToString()),
                                    LNameObject = lReader["NameObject"].ToString()
                                },
                                LIdTaxe = Convert.ToInt32(lReader["IdTax"].ToString()),
                                LNameTaxe = lReader["NameTax"].ToString(),
                                LIsPercent = Convert.ToBoolean(lReader["IsPercent"].ToString()),
                                LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString()),
                                LValueTaxe = Convert.ToDecimal(lReader["ValueTax"].ToString())
                            };
                            lListTaxe.Add(lTaxe);
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListTaxe;
                }
                catch (Exception e)
                {
                    lListTaxe = new List<BoTaxe>();
                    var lTaxe = new BoTaxe
                    {
                        LException = e.Message,
                        LMessageDao = BoErrors.MsgErrorGetSql
                };
                    if (e.InnerException != null)
                        lTaxe.LInnerException = e.InnerException.ToString();                    
                    Dao_CloseSqlconnection(lConex);
                    lListTaxe.Add(lTaxe);
                    return lListTaxe;
                }
            }
        }

        public List<BoTaxe> Dao_getLisAllTaxesWithOutProduct(int pIdProduct)
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = Dao_SqlConnection(lConex))
            {
                var lListTaxe = new List<BoTaxe>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListTaxesWithOutProduct",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add("IdProduct", SqlDbType.Int).Value = pIdProduct;
                    var lReader = lCommand.ExecuteReader();                   
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lTaxe = new BoTaxe
                            {
                                LStatus = new BoStatus
                                {
                                    LIdStatus = lReader["IdStatus"].ToString(),
                                    LDsEstado = lReader["NameStatus"].ToString()
                                },
                                LObject = new BoObject
                                {
                                    LIdObject = Convert.ToInt32(lReader["IdObject"].ToString()),
                                    LNameObject = lReader["NameObject"].ToString()
                                },
                                LIdTaxe = Convert.ToInt32(lReader["IdTax"].ToString()),
                                LNameTaxe = lReader["NameTax"].ToString(),
                                LIsPercent = Convert.ToBoolean(lReader["IsPercent"].ToString()),
                                LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString()),
                                LValueTaxe = Convert.ToDecimal(lReader["ValueTax"].ToString())
                            };
                            lListTaxe.Add(lTaxe);
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListTaxe;
                }
                catch (Exception e)
                {
                    lListTaxe = new List<BoTaxe>();
                    var lTaxe = new BoTaxe
                    {
                        LException = e.Message,
                        LMessageDao = BoErrors.MsgErrorGetSql
                };
                    if (e.InnerException != null)
                        lTaxe.LInnerException = e.InnerException.ToString();                   
                    Dao_CloseSqlconnection(lConex);
                    lListTaxe.Add(lTaxe);
                    return lListTaxe;
                }
            }
        }

        public BoTaxe Dao_getTaxeById(int pIdTaxe)
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = Dao_SqlConnection(lConex))
            {
                var lTaxe = new BoTaxe();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetTaxeById",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("IdTaxe", pIdTaxe));
                    var lReader = lCommand.ExecuteReader();
                    
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {                            
                            lTaxe.LIdTaxe = Convert.ToInt32(lReader["IdTax"].ToString());
                            lTaxe.LNameTaxe = lReader["NameTax"].ToString();
                            lTaxe.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            lTaxe.LValueTaxe = Convert.ToDecimal(lReader["ValueTax"].ToString());
                            lTaxe.LIsPercent = Convert.ToBoolean(lReader["IsPercent"].ToString());
                            lTaxe.LStatus = new BoStatus {LIdStatus = lReader["IdStatus"].ToString()};
                            lTaxe.LObject = new BoObject {LIdObject = Convert.ToInt32(lReader["IdObject"].ToString())};
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lTaxe;
                }
                catch (Exception e)
                {
                    lTaxe = new BoTaxe
                    {
                        LException = e.Message,
                        LMessageDao = BoErrors.MsgErrorGetSql
                };
                    if (e.InnerException != null)
                        lTaxe.LInnerException = e.InnerException.ToString();
                    
                    Dao_CloseSqlconnection(lConex);
                    return lTaxe;
                }
            }
        }

        public string Dao_InsertTaxeXProduct(int pIdProduct, int pIdTaxe)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdProduct", pIdProduct.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdTaxe", pIdTaxe.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranInsertTaxeXProduct", "spr_CreateTaxeXProduct");
        }

        public string Dao_DeleteTaxeXProduct(int pIdProduct, int pIdTaxe)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdProduct", pIdProduct.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdTaxe", pIdTaxe.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranDeleteTaxeXProduct", "spr_DeleteTaxeXProduct");
        }


    }
}
