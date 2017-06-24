using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using System.Data.SqlClient;
using System.Data;

namespace Dao_BussinessManagement
{
    public class Dao_Inventory
    {

        List<SqlParameter> lListParam = new List<SqlParameter>();

        public List<Bo_Inventory> Dao_getAllInventory()
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {

                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetListAllInventory";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;

                    var lReader = lCommand.ExecuteReader();
                    List<Bo_Inventory> oListInventory = new List<Bo_Inventory>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_Inventory oInventory = new Bo_Inventory();
                            oInventory.LStatus = new Bo_Status();
                            oInventory.LObject = new Bo_Object();
                            oInventory.LIdInventory = Convert.ToInt32(lReader["IdInventory"].ToString());
                            oInventory.LNameInventory = lReader["NameInventory"].ToString();
                            oInventory.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oInventory.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oInventory.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            oListInventory.Add(oInventory);
                        }


                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListInventory;
                }
                catch (Exception e)
                {
                    List<Bo_Inventory> oListInventory = new List<Bo_Inventory>();
                    Bo_Inventory oInventory = new Bo_Inventory();
                    oInventory.LException = e.Message;
                    if (e.InnerException != null)
                        oInventory.LInnerException = e.InnerException.ToString();
                    oInventory.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    oListInventory.Add(oInventory);
                    return oListInventory;
                }

            }
        }

        public Bo_Inventory Dao_getInventoryById(int pIdInventory)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetInventory";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("IdInventory", pIdInventory));

                    var lReader = lCommand.ExecuteReader();
                    Bo_Inventory oInventory = new Bo_Inventory();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read()) {
                            oInventory.LStatus = new Bo_Status();
                            oInventory.LObject = new Bo_Object();
                            oInventory.LIdInventory = Convert.ToInt32(lReader["IdInventory"].ToString());
                            oInventory.LNameInventory = lReader["NameInventory"].ToString();
                            oInventory.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oInventory.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oInventory.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                        }
                        

                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection( lConex);
                    return oInventory;
                }
                catch (Exception e)
                {
                    Bo_Inventory oInventory = new Bo_Inventory();
                    oInventory.LException = e.Message;
                    if(e.InnerException != null)
                    oInventory.LInnerException = e.InnerException.ToString();
                    oInventory.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection( lConex);
                    return oInventory;
                }
                
            }
        }

        public string Dao_InsertInventory(Bo_Inventory pInventory)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam,SqlDbType.VarChar, "@NameInventory", pInventory.LNameInventory);
            Dao_UtilsLib.dao_Addparameters(lListParam,SqlDbType.VarChar, "@IdStatus", pInventory.LStatus.LIdStatus.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam,SqlDbType.Int, "@IdObject", pInventory.LObject.LIdObject.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranInsertInventory", "spr_CreateInventory");
        }

        public string Dao_UpdateInventory(Bo_Inventory pInventory)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdInventory", pInventory.LIdInventory.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@NameInventory", pInventory.LNameInventory);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pInventory.LStatus.LIdStatus.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranUpdateInventory", "spr_UpdateInventory");
        }

        public string Dao_DeleteInventory(Bo_Inventory pInventory)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdInventory", pInventory.LIdInventory.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranDeleteInventory", "spr_DeleteInventory");
        }
    }
}
