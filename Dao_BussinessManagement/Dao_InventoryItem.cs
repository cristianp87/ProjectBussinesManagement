using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using IDaoBusiness.Business;
using static Dao_BussinessManagement.Dao_UtilsLib;

namespace Dao_BussinessManagement
{
    public class DaoInventoryItem : IDaoInventoryItem
    {
        private List<SqlParameter> LListParam { get; set; }

        public List<Bo_InventoryItem> Dao_getListInventoryItemByIdInventory(int pIdInventory)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lListInventoryItem = new List<Bo_InventoryItem>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListInventoryItem",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("IdInventory", pIdInventory));
                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var oInventoryItem = new Bo_InventoryItem
                            {
                                LStatus = new Bo_Status {LIdStatus = lReader["IdStatus"].ToString()},
                                LObject = new Bo_Object {LIdObject = Convert.ToInt32(lReader["IdObject"].ToString())},
                                LProduct =
                                    new Bo_Product
                                    {
                                        LIdProduct = Convert.ToInt32(lReader["IdProduct"].ToString()),
                                        LNameProduct = lReader["NameProduct"].ToString()
                                    },
                                LInventory =
                                    new Bo_Inventory
                                    {
                                        LIdInventory = Convert.ToInt32(lReader["IdInventory"].ToString()),
                                        LNameInventory = lReader["NameInventory"].ToString()
                                    },
                                LIdInventoryItem = Convert.ToInt32(lReader["IdInventoryItem"].ToString()),
                                LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString()),
                                LQtySellable = Convert.ToDecimal(lReader["QtySellable"].ToString()),
                                LQtyNonSellable = Convert.ToDecimal(lReader["QtyNonSellable"].ToString())
                            };
                            lListInventoryItem.Add(oInventoryItem);
                        }


                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListInventoryItem;
                }
                catch (Exception e)
                {
                    var oInventoryItem = new Bo_InventoryItem {LException = e.Message};
                    if (e.InnerException != null)
                        oInventoryItem.LInnerException = e.InnerException.ToString();
                    oInventoryItem.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_CloseSqlconnection(lConex);
                    lListInventoryItem.Add(oInventoryItem);
                    return lListInventoryItem;
                }
            }
        }

        public Bo_InventoryItem Dao_getInventoryItemById(int pIdInventoryItem)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {

                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetInventoryItem",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("IdInventoryItem", pIdInventoryItem));

                    var lReader = lCommand.ExecuteReader();
                    var oInventoryItem = new Bo_InventoryItem();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {                           
                            oInventoryItem.LStatus = new Bo_Status();
                            oInventoryItem.LObject = new Bo_Object();
                            oInventoryItem.LProduct = new Bo_Product();
                            oInventoryItem.LInventory = new Bo_Inventory();
                            oInventoryItem.LIdInventoryItem = Convert.ToInt32(lReader["IdInventoryItem"].ToString());
                            oInventoryItem.LInventory.LIdInventory = Convert.ToInt32(lReader["IdInventory"].ToString());
                            oInventoryItem.LInventory.LNameInventory = lReader["NameInventory"].ToString();
                            oInventoryItem.LProduct.LIdProduct = Convert.ToInt32(lReader["IdProduct"].ToString());
                            oInventoryItem.LProduct.LNameProduct = lReader["NameProduct"].ToString();
                            oInventoryItem.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oInventoryItem.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oInventoryItem.LQtySellable = Convert.ToDecimal(lReader["QtySellable"].ToString());
                            oInventoryItem.LQtyNonSellable = Convert.ToDecimal(lReader["QtyNonSellable"].ToString());
                            oInventoryItem.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                        }


                    }
                    Dao_CloseSqlconnection(lConex);
                    return  oInventoryItem;
                }
                catch (Exception e)
                {
                    var oInventoryItem = new Bo_InventoryItem();
                    oInventoryItem.LException = e.Message;
                    if (e.InnerException != null)
                        oInventoryItem.LInnerException = e.InnerException.ToString();
                    oInventoryItem.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_CloseSqlconnection(lConex);
                    return oInventoryItem;
                }
            }
        }

        public string Dao_InsertInventoryItem(Bo_InventoryItem pInventoryItem)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdProduct", pInventoryItem.LProduct.LIdProduct.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInventory", pInventoryItem.LInventory.LIdInventory.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pInventoryItem.LStatus.LIdStatus.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pInventoryItem.LObject.LIdObject.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@QtySellable", pInventoryItem.LQtySellable.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@QtyNonSellable", pInventoryItem.LQtyNonSellable.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranInsertInventoryItem", "spr_CreateInventoryItem");
        }

        public string Dao_UpdateInventoryItem(Bo_InventoryItem pInventoryItem)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInventoryItem", pInventoryItem.LIdInventoryItem.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdProduct", pInventoryItem.LProduct.LIdProduct.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInventory", pInventoryItem.LInventory.LIdInventory.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pInventoryItem.LStatus.LIdStatus.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pInventoryItem.LObject.LIdObject.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@QtySellable", pInventoryItem.LQtySellable.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@QtyNonSellable", pInventoryItem.LQtyNonSellable.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranUpdateInventoryItem", "spr_UpdateInventoryItem");
        }

        public string Dao_DeleteInventoryItem(Bo_InventoryItem pInventoryItem)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInventoryItem", pInventoryItem.LIdInventoryItem.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranDeleteInventoryItem", "spr_DeleteInventoryItem");
        }

        public string Dao_SubstractInventoryItem(Bo_InventoryItem pInventoryItem)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInventory", pInventoryItem.LInventory.LIdInventory.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@CdProduct", pInventoryItem.LProduct.LCdProduct.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@QtySellable", pInventoryItem.LQtySellable.ToString());
            return Dao_executeSqlScalarWithProcedement(this.LListParam, "LTranSubstractInventoryItem", "spr_substractinventory");
        }
    }
}
