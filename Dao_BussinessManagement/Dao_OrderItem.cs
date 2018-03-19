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

    public class DaoOrderItem : IDaoOrderItem
    {
        private List<SqlParameter> LListParam { get; set; }

        /// <summary>
        /// Trae de la base de datos los items de cada pedido
        /// </summary>
        /// <param name="pIdOrder"></param>
        /// <returns></returns>
        public List<BoOrderItem> Dao_getListOrderItem(int pIdOrder)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lListOrderItem = new List<BoOrderItem>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListOrderItem",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("IdOrder", pIdOrder));
                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lOrderItem = new BoOrderItem
                            {
                                LStatus = new BoStatus {LIdStatus = lReader["IdStatus"].ToString()},
                                LObject = new BoObject {LIdObject = Convert.ToInt32(lReader["IdObject"].ToString())},
                                LOrder = new BoOrder {LIdOrder = Convert.ToInt32(lReader["IdOrder"].ToString())},
                                LProduct = new BoProduct
                                {
                                    LNameProduct = lReader["NameProduct"].ToString(),
                                    LIdProduct = Convert.ToInt32(lReader["IdProduct"].ToString())
                                },
                                LIdOrderItem = Convert.ToInt32(lReader["IdOrderItem"].ToString()),
                                LQty = Convert.ToDecimal(lReader["Qty"].ToString()),
                                LValueProduct = Convert.ToDecimal(lReader["ValueProduct"].ToString()),
                                LValueDesc = Convert.ToDecimal(lReader["ValueDescProduct"].ToString()),
                                LValueSupplier = Convert.ToDecimal(lReader["ValueSupplier"].ToString()),
                                LValueTaxes = Convert.ToDecimal(lReader["ValueTaxesProduct"].ToString()),
                                LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString())
                            };
                            lListOrderItem.Add(lOrderItem);
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListOrderItem;
                }
                catch (Exception e)
                {
                    lListOrderItem = new List<BoOrderItem>();
                    var lOrderItem = new BoOrderItem {LException = e.Message, LMessageDao = BoErrors.MsgErrorGetSql
                };
                    if (e.InnerException != null)
                        lOrderItem.LInnerException = e.InnerException.ToString();
                    Dao_CloseSqlconnection(lConex);
                    lListOrderItem.Add(lOrderItem);
                    return lListOrderItem;
                }
            }
        }
        /// <summary>
        /// Insertar items de pedido.
        /// </summary>
        /// <param name="pOrderItem"></param>
        /// <returns></returns>
        public string Dao_InsertOrderItem(BoOrderItem pOrderItem)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@CodProduct", pOrderItem.LProduct.LCdProduct);
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdOrder", pOrderItem.LOrder.LIdOrder.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueProduct", pOrderItem.LValueProduct.ToString(CultureInfo.CurrentCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@Qty", pOrderItem.LQty.ToString(CultureInfo.CurrentCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueSupplier", pOrderItem.LValueSupplier.ToString(CultureInfo.CurrentCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueTaxesProduct", pOrderItem.LValueTaxes.ToString(CultureInfo.CurrentCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueDescProduct", pOrderItem.LValueDesc.ToString(CultureInfo.CurrentCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueTotalProduct", pOrderItem.LValueTotal.ToString(CultureInfo.CurrentCulture));
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pOrderItem.LStatus.LIdStatus);
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pOrderItem.LObject.LIdObject.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranInsertOrder", "spr_CreateOrderItem");
        }
    }
}
