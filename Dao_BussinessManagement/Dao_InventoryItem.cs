using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using BO_BusinessManagement.Enums;
using IDaoBusiness.Business;
using static Dao_BussinessManagement.DaoUtilsLib;

namespace Dao_BussinessManagement
{
    public class DaoInventoryItem : IDaoInventoryItem
    {
        private List<SqlParameter> LListParam { get; set; }

        public List<BoInventoryItem> Dao_getListInventoryItemByIdInventory(int pIdInventory)
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = Dao_SqlConnection(lConex))
            {
                var lListInventoryItem = new List<BoInventoryItem>();
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
                            var oInventoryItem = new BoInventoryItem
                            {
                                LStatus = new BoStatus {LIdStatus = lReader["IdStatus"].ToString()},
                                LObject = new BoObject {LIdObject = Convert.ToInt32(lReader["IdObject"].ToString())},
                                LProduct =
                                    new BoProduct
                                    {
                                        LIdProduct = Convert.ToInt32(lReader["IdProduct"].ToString()),
                                        LNameProduct = lReader["NameProduct"].ToString(),
                                        LCdProduct = lReader["CdProduct"].ToString()
                                    },
                                LInventory =
                                    new BoInventory
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
                    var oInventoryItem = new BoInventoryItem {LException = e.Message};
                    if (e.InnerException != null)
                        oInventoryItem.LInnerException = e.InnerException.ToString();
                    oInventoryItem.LMessageDao = BoErrors.MsgErrorGetSql;
                    Dao_CloseSqlconnection(lConex);
                    lListInventoryItem.Add(oInventoryItem);
                    return lListInventoryItem;
                }
            }
        }

        public BoInventoryItem Dao_getInventoryItemById(int pIdInventoryItem)
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = Dao_SqlConnection(lConex))
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
                    var oInventoryItem = new BoInventoryItem();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {                           
                            oInventoryItem.LStatus = new BoStatus();
                            oInventoryItem.LObject = new BoObject();
                            oInventoryItem.LProduct = new BoProduct();
                            oInventoryItem.LInventory = new BoInventory();
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
                    var lInventoryItem = new BoInventoryItem
                    {
                        LException = e.Message,
                        LMessageDao = BoErrors.MsgErrorGetSql
                };
                    if (e.InnerException != null)
                        lInventoryItem.LInnerException = e.InnerException.ToString();
                    
                    Dao_CloseSqlconnection(lConex);
                    return lInventoryItem;
                }
            }
        }

        public string Dao_InsertInventoryItem(BoInventoryItem pInventoryItem)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdProduct", pInventoryItem.LProduct.LIdProduct.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInventory", pInventoryItem.LInventory.LIdInventory.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pInventoryItem.LStatus.LIdStatus);
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pInventoryItem.LObject.LIdObject.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@QtySellable", pInventoryItem.LQtySellable.ToString(CultureInfo.CurrentCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@QtyNonSellable", pInventoryItem.LQtyNonSellable.ToString(CultureInfo.CurrentCulture));
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranInsertInventoryItem", "spr_CreateInventoryItem");
        }

        public string Dao_UpdateInventoryItem(BoInventoryItem pInventoryItem)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInventoryItem", pInventoryItem.LIdInventoryItem.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdProduct", pInventoryItem.LProduct.LIdProduct.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInventory", pInventoryItem.LInventory.LIdInventory.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pInventoryItem.LStatus.LIdStatus);
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pInventoryItem.LObject.LIdObject.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@QtySellable", pInventoryItem.LQtySellable.ToString(CultureInfo.CurrentCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@QtyNonSellable", pInventoryItem.LQtyNonSellable.ToString(CultureInfo.CurrentCulture));
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranUpdateInventoryItem", "spr_UpdateInventoryItem");
        }

        public string Dao_DeleteInventoryItem(BoInventoryItem pInventoryItem)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInventoryItem", pInventoryItem.LIdInventoryItem.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranDeleteInventoryItem", "spr_DeleteInventoryItem");
        }

        public string Dao_SubstractInventoryItem(BoInventoryItem pInventoryItem)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInventory", pInventoryItem.LInventory.LIdInventory.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@CdProduct", pInventoryItem.LProduct.LCdProduct);
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@QtySellable", pInventoryItem.LQtySellable.ToString(CultureInfo.CurrentCulture));
            return Dao_executeSqlScalarWithProcedement(this.LListParam, "LTranSubstractInventoryItem", "spr_substractinventory");
        }
    }
}
