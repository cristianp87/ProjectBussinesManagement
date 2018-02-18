using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Dao_BussinessManagement
{

    public class Dao_OrderItem
    {
        private List<SqlParameter> lListParam = new List<SqlParameter>();
        /// <summary>
        /// Trae de la base de datos los items de cada pedido
        /// </summary>
        /// <param name="pIdOrder"></param>
        /// <returns></returns>
        public List<Bo_OrderItem> Dao_getListOrderItem(int pIdOrder)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {

                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetListOrderItem";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("IdOrder", pIdOrder));
                    var lReader = lCommand.ExecuteReader();
                    List<Bo_OrderItem> lListOrderItem = new List<Bo_OrderItem>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_OrderItem lOrderItem = new Bo_OrderItem();
                            lOrderItem.LStatus = new Bo_Status();
                            lOrderItem.LObject = new Bo_Object();
                            lOrderItem.LOrder = new Bo_Order();
                            lOrderItem.LProduct = new Bo_Product();
                            lOrderItem.LOrder.LIdOrder = Convert.ToInt32(lReader["IdOrder"].ToString());
                            lOrderItem.LIdOrderItem = Convert.ToInt32(lReader["IdOrderItem"].ToString());
                            lOrderItem.LProduct.LNameProduct = lReader["NameProduct"].ToString();
                            lOrderItem.LProduct.LIdProduct = Convert.ToInt32(lReader["IdProduct"].ToString());
                            lOrderItem.LQty = Convert.ToDecimal(lReader["Qty"].ToString());
                            lOrderItem.LValueProduct= Convert.ToDecimal(lReader["ValueProduct"].ToString());
                            lOrderItem.LValueDesc = Convert.ToDecimal(lReader["ValueDescProduct"].ToString());
                            lOrderItem.LValueSupplier = Convert.ToDecimal(lReader["ValueSupplier"].ToString());
                            lOrderItem.LValueTaxes = Convert.ToDecimal(lReader["ValueTaxesProduct"].ToString());
                            lOrderItem.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            lOrderItem.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            lOrderItem.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            lListOrderItem.Add(lOrderItem);
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lListOrderItem;
                }
                catch (Exception e)
                {
                    List<Bo_OrderItem> lListOrderItem = new List<Bo_OrderItem>();
                    Bo_OrderItem lOrderItem = new Bo_OrderItem();
                    lOrderItem.LException = e.Message;
                    if (e.InnerException != null)
                        lOrderItem.LInnerException = e.InnerException.ToString();
                    lOrderItem.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
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
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@CodProduct", pOrderItem.LProduct.LCdProduct.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdOrder", pOrderItem.LOrder.LIdOrder.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@ValueProduct", pOrderItem.LValueProduct.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@Qty", pOrderItem.LQty.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@ValueSupplier", pOrderItem.LValueSupplier.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@ValueTaxesProduct", pOrderItem.LValueTaxes.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@ValueDescProduct", pOrderItem.LValueDesc.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@ValueTotalProduct", pOrderItem.LValueTotal.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pOrderItem.LStatus.LIdStatus.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdObject", pOrderItem.LObject.LIdObject.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranInsertOrder", "spr_CreateOrderItem");
        }
    }
}
