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
    public class DaoInventory : IDaoInventory
    {

        private List<SqlParameter> LListParam { get; set; }

        public List<BoInventory> Dao_getAllInventory()
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = Dao_SqlConnection(lConex))
            {
                var lListInventory = new List<BoInventory>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListAllInventory",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };

                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lInventory = new BoInventory
                            {
                                LStatus = new BoStatus {LIdStatus = lReader["IdStatus"].ToString()},
                                LObject = new BoObject {LIdObject = Convert.ToInt32(lReader["IdObject"].ToString())},
                                LIdInventory = Convert.ToInt32(lReader["IdInventory"].ToString()),
                                LNameInventory = lReader["NameInventory"].ToString(),
                                LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString())
                            };
                            lListInventory.Add(lInventory);
                        }


                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListInventory;
                }
                catch (Exception e)
                {
                    var lInventory = new BoInventory {LException = e.Message};
                    if (e.InnerException != null)
                        lInventory.LInnerException = e.InnerException.ToString();
                    lInventory.LMessageDao = BoErrors.MsgErrorGetSql;
                    Dao_CloseSqlconnection(lConex);
                    lListInventory.Add(lInventory);
                    return lListInventory;
                }
            }
        }

        public BoInventory Dao_getInventoryById(int pIdInventory)
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = Dao_SqlConnection(lConex))
            {
                var lInventory = new BoInventory();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetInventory",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("IdInventory", pIdInventory));

                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read()) {
                            lInventory.LStatus = new BoStatus();
                            lInventory.LObject = new BoObject();
                            lInventory.LIdInventory = Convert.ToInt32(lReader["IdInventory"].ToString());
                            lInventory.LNameInventory = lReader["NameInventory"].ToString();
                            lInventory.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            lInventory.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            lInventory.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                        }
                        

                    }
                    Dao_CloseSqlconnection( lConex);
                    return lInventory;
                }
                catch (Exception e)
                {
                    lInventory = new BoInventory {LException = e.Message};
                    if(e.InnerException != null)
                        lInventory.LInnerException = e.InnerException.ToString();
                    lInventory.LMessageDao = BoErrors.MsgErrorGetSql;
                    Dao_CloseSqlconnection( lConex);
                    return lInventory;
                }
            }
        }

        public string Dao_InsertInventory(BoInventory pInventory)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@NameInventory", pInventory.LNameInventory);
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pInventory.LStatus.LIdStatus);
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pInventory.LObject.LIdObject.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranInsertInventory", "spr_CreateInventory");
        }

        public string Dao_UpdateInventory(BoInventory pInventory)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInventory", pInventory.LIdInventory.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@NameInventory", pInventory.LNameInventory);
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pInventory.LStatus.LIdStatus);
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranUpdateInventory", "spr_UpdateInventory");
        }

        public string Dao_DeleteInventory(BoInventory pInventory)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInventory", pInventory.LIdInventory.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranDeleteInventory", "spr_DeleteInventory");
        }
    }
}
