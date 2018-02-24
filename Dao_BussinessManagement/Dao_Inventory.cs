using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using IDaoBusiness.Business;
using static Dao_BussinessManagement.Dao_UtilsLib;

namespace Dao_BussinessManagement
{
    public class DaoInventory : IDaoInventory
    {

        private List<SqlParameter> LListParam { get; set; }

        public List<Bo_Inventory> Dao_getAllInventory()
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lListInventory = new List<Bo_Inventory>();
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
                            var lInventory = new Bo_Inventory
                            {
                                LStatus = new Bo_Status {LIdStatus = lReader["IdStatus"].ToString()},
                                LObject = new Bo_Object {LIdObject = Convert.ToInt32(lReader["IdObject"].ToString())},
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
                    var lInventory = new Bo_Inventory {LException = e.Message};
                    if (e.InnerException != null)
                        lInventory.LInnerException = e.InnerException.ToString();
                    lInventory.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_CloseSqlconnection(lConex);
                    lListInventory.Add(lInventory);
                    return lListInventory;
                }
            }
        }

        public Bo_Inventory Dao_getInventoryById(int pIdInventory)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lInventory = new Bo_Inventory();
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
                            lInventory.LStatus = new Bo_Status();
                            lInventory.LObject = new Bo_Object();
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
                    lInventory = new Bo_Inventory {LException = e.Message};
                    if(e.InnerException != null)
                        lInventory.LInnerException = e.InnerException.ToString();
                    lInventory.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_CloseSqlconnection( lConex);
                    return lInventory;
                }
            }
        }

        public string Dao_InsertInventory(Bo_Inventory pInventory)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@NameInventory", pInventory.LNameInventory);
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pInventory.LStatus.LIdStatus.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pInventory.LObject.LIdObject.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranInsertInventory", "spr_CreateInventory");
        }

        public string Dao_UpdateInventory(Bo_Inventory pInventory)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInventory", pInventory.LIdInventory.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@NameInventory", pInventory.LNameInventory);
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pInventory.LStatus.LIdStatus.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranUpdateInventory", "spr_UpdateInventory");
        }

        public string Dao_DeleteInventory(Bo_Inventory pInventory)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInventory", pInventory.LIdInventory.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranDeleteInventory", "spr_DeleteInventory");
        }
    }
}
