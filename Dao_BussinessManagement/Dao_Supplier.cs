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
    public class DaoSupplier : IDaoSupplier
    {
        private List<SqlParameter> LListParam { get; set; }

        public BoSupplier Dao_getSupplierById(int pIdSupplier)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lSupplier = new BoSupplier();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetSupplier",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("IdSupplier", pIdSupplier));

                    var lReader = lCommand.ExecuteReader();
                    
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {                           
                            lSupplier.LTypeIdentification = new BoTypeIdentification();
                            lSupplier.LIdSupplier = Convert.ToInt32(lReader["IdSupplier"].ToString());
                            lSupplier.LNameSupplier = lReader["NameSupplier"].ToString();
                            lSupplier.LTypeIdentification.LIdTypeIdentification = Convert.ToInt32(lReader["IdTypeIdentification"].ToString());
                            lSupplier.LTypeIdentification.LTypeIdentification = lReader["TypeIdentification"].ToString();
                            lSupplier.LNoIdentification = lReader["NoIdentification"].ToString();
                            lSupplier.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            lSupplier.LStatus = new BoStatus
                            {
                                LIdStatus = lReader["IdStatus"].ToString(),
                                LDsEstado = lReader["DsEstado"].ToString()
                            };
                            lSupplier.LObject = new BoObject
                            {
                                LIdObject = Convert.ToInt32(lReader["IdObject"].ToString()),
                                LNameObject = lReader["NameObject"].ToString()
                            };
                            lSupplier.LModificationDate = Convert.ToDateTime(lReader["ModificationDate"]);
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lSupplier;
                }
                catch (Exception e)
                {
                    lSupplier = new BoSupplier
                    {
                        LException = e.Message,
                        LMessageDao = BoErrors.MsgErrorGetSql
                };
                    if (e.InnerException != null)
                        lSupplier.LInnerException = e.InnerException.ToString();                  
                    Dao_CloseSqlconnection(lConex);
                    return lSupplier;
                }
            }
        }

        public List<BoSupplier> Dao_getSupplierListAll()
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lListSupplier = new List<BoSupplier>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListAllSupplier",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    var lReader = lCommand.ExecuteReader();
                    
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var oSupplier = new BoSupplier
                            {
                                LTypeIdentification =
                                    new BoTypeIdentification
                                    {
                                        LIdTypeIdentification =
                                            Convert.ToInt32(lReader["IdTypeIdentification"].ToString()),
                                        LTypeIdentification = lReader["TypeIdentification"].ToString()
                                    },
                                LIdSupplier = Convert.ToInt32(lReader["IdSupplier"].ToString()),
                                LNameSupplier = lReader["NameSupplier"].ToString(),
                                LNoIdentification = lReader["NoIdentification"].ToString(),
                                LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString()),
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
                                LModificationDate = Convert.ToDateTime(lReader["ModificationDate"])
                            };
                            lListSupplier.Add(oSupplier);
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListSupplier;
                }
                catch (Exception e)
                {
                    lListSupplier = new List<BoSupplier>();
                    var oSupplier = new BoSupplier
                    {
                        LException = e.Message,
                        LMessageDao = BoErrors.MsgErrorGetSql
                };
                    if (e.InnerException != null)
                        oSupplier.LInnerException = e.InnerException.ToString();                   
                    Dao_CloseSqlconnection(lConex);
                    lListSupplier.Add(oSupplier);
                    return lListSupplier;
                }
            }
        }

        public string Dao_InsertSupplier(BoSupplier pSupplier)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@NameSupplier", pSupplier.LNameSupplier);
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdTypeIdentification", pSupplier.LTypeIdentification.LIdTypeIdentification.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@NoIdentification", pSupplier.LNoIdentification);
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pSupplier.LStatus.LIdStatus);
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pSupplier.LObject.LIdObject.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranInsertSupplier", "spr_CreateSupplier");
        }

        public string Dao_UpdateSupplier(BoSupplier pSupplier)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdSupplier", pSupplier.LIdSupplier.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@NameSupplier", pSupplier.LNameSupplier);
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdTypeIdentification", pSupplier.LTypeIdentification.LIdTypeIdentification.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@NoIdentification", pSupplier.LNoIdentification);
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pSupplier.LStatus.LIdStatus);
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pSupplier.LObject.LIdObject.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranUpdateSupplier", "spr_UpdateSupplier");
        }

        public string Dao_DeleteSupplier(BoSupplier pSupplier)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdSupplier", pSupplier.LIdSupplier.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranDeleteSupplier", "spr_DeleteSupplier");
        }
    }
}
