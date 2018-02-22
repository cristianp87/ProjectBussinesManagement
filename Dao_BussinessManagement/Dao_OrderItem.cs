using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using IDaoBusiness.Business;
using static Dao_BussinessManagement.Dao_UtilsLib;

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
        public List<Bo_OrderItem> Dao_getListOrderItem(int pIdOrder)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lListOrderItem = new List<Bo_OrderItem>();
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
                            var lOrderItem = new Bo_OrderItem
                            {
                                LStatus = new Bo_Status {LIdStatus = lReader["IdStatus"].ToString()},
                                LObject = new Bo_Object {LIdObject = Convert.ToInt32(lReader["IdObject"].ToString())},
                                LOrder = new Bo_Order {LIdOrder = Convert.ToInt32(lReader["IdOrder"].ToString())},
                                LProduct = new Bo_Product
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
                    lListOrderItem = new List<Bo_OrderItem>();
                    var lOrderItem = new Bo_OrderItem {LException = e.Message, LMessageDao = "Hubo un problema en la consulta, contacte al administrador."
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
        public string Dao_InsertOrderItem(Bo_OrderItem pOrderItem)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@CodProduct", pOrderItem.LProduct.LCdProduct.ToString());
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
