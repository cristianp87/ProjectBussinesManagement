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
    public class Dao_InventoryItem
    {
        List<SqlParameter> lListParam = new List<SqlParameter>();

        public List<Bo_InventoryItem> Dao_getInventoryItemByIdInventory(int pIdInventory)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {

                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetListInventoryItem";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("IdInventory", pIdInventory));

                    var lReader = lCommand.ExecuteReader();
                    List<Bo_InventoryItem> oListInventoryItem = new List<Bo_InventoryItem>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_InventoryItem oInventoryItem = new Bo_InventoryItem();
                            oInventoryItem.LStatus = new Bo_Status();
                            oInventoryItem.LObject = new Bo_Object();
                            oInventoryItem.LProduct = new Bo_Product();
                            oInventoryItem.LIdInventoryItem = Convert.ToInt32(lReader["IdInventoryItem"].ToString());
                            oInventoryItem.LProduct.LIdProduct = Convert.ToInt32(lReader["IdProduct"].ToString());
                            oInventoryItem.LProduct.LNameProduct = lReader["NameProduct"].ToString();
                            oInventoryItem.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oInventoryItem.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oInventoryItem.LQtySellable = Convert.ToInt32(lReader["QtySellable"].ToString());
                            oInventoryItem.LQtyNonSellable = Convert.ToInt32(lReader["QtyNonSellable"].ToString());
                            oInventoryItem.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            oListInventoryItem.Add(oInventoryItem);
                        }


                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListInventoryItem;
                }
                catch (Exception e)
                {
                    List<Bo_InventoryItem> oListInventoryItem = new List<Bo_InventoryItem>();
                    Bo_InventoryItem oInventoryItem = new Bo_InventoryItem();
                    oInventoryItem.LException = e.Message;
                    if (e.InnerException != null)
                        oInventoryItem.LInnerException = e.InnerException.ToString();
                    oInventoryItem.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    oListInventoryItem.Add(oInventoryItem);
                    return oListInventoryItem;
                }
            }
        }

        public string Dao_InsertInventoryItem(Bo_InventoryItem pInventoryItem)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdProduct", pInventoryItem.LProduct.LIdProduct.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdInventory", pInventoryItem.LIdInventory.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pInventoryItem.LStatus.LIdStatus.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdObject", pInventoryItem.LObject.LIdObject.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@QtySellable", pInventoryItem.LQtySellable.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@QtyNonSellable", pInventoryItem.LQtyNonSellable.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranInsertInventoryItem", "spr_CreateInventoryItem");
        }

        public string Dao_UpdateInventoryItem(Bo_InventoryItem pInventoryItem)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdInventoryItem", pInventoryItem.LIdInventoryItem.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdProduct", pInventoryItem.LProduct.LIdProduct.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdInventory", pInventoryItem.LIdInventory.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pInventoryItem.LStatus.LIdStatus.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdObject", pInventoryItem.LObject.LIdObject.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@QtySellable", pInventoryItem.LQtySellable.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@QtyNonSellable", pInventoryItem.LQtyNonSellable.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranUpdateInventoryItem", "spr_UpdateInventoryItem");
        }

        public string Dao_DeleteInventoryItem(Bo_InventoryItem pInventoryItem)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdInventoryItem", pInventoryItem.LIdInventoryItem.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranDeleteInventoryItem", "spr_DeleteInventoryItem");
        }
    }
}
