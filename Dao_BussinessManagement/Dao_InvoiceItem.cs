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
    public class DaoInvoiceItem : IDaoInvoiceItem
    {
        List<SqlParameter> LListParam { get; set; }

        public List<Bo_InvoiceItem> Dao_getInvoiceItemByIdInvoice(int pIdInvoice)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lListInvoiceItem = new List<Bo_InvoiceItem>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListInvoiceItem",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("IdInvoice", pIdInvoice));

                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lInvoiceItem = new Bo_InvoiceItem
                            {
                                LStatus = new Bo_Status {LIdStatus = lReader["IdStatus"].ToString()},
                                LObject = new Bo_Object {LIdObject = Convert.ToInt32(lReader["IdObject"].ToString())},
                                LProduct =
                                    new Bo_Product
                                    {
                                        LIdProduct = Convert.ToInt32(lReader["IdProduct"].ToString()),
                                        LNameProduct = lReader["NameProduct"].ToString()
                                    },
                                LIdInvoiceItem = Convert.ToInt32(lReader["IdInvoiceItem"].ToString()),
                                LIdInvoice = Convert.ToInt32(lReader["IdInvoice"].ToString()),
                                LQuantity = Convert.ToDecimal(lReader["Qty"].ToString()),
                                LValueProd = Convert.ToDecimal(lReader["ValueProduct"].ToString()),
                                LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString())
                            };
                            lListInvoiceItem.Add(lInvoiceItem);
                        }


                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListInvoiceItem;
                }
                catch (Exception e)
                {
                    lListInvoiceItem = new List<Bo_InvoiceItem>();
                    var lInvoiceItem = new Bo_InvoiceItem {LException = e.Message, LMessageDao = "Hubo un problema en la consulta, contacte al administrador."
                };
                    if (e.InnerException != null)
                        lInvoiceItem.LInnerException = e.InnerException.ToString();
                    Dao_CloseSqlconnection(lConex);
                    lListInvoiceItem.Add(lInvoiceItem);
                    return lListInvoiceItem;
                }
            }
        }

        public string Dao_InsertInvoiceItem(Bo_InvoiceItem pInvoiceItem)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInvoice", pInvoiceItem.LIdInvoice.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdProduct", pInvoiceItem.LProduct.LIdProduct.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@Qty", pInvoiceItem.LQuantity.ToString(CultureInfo.InvariantCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueProduct", pInvoiceItem.LValueProd.ToString(CultureInfo.InvariantCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueDesc", pInvoiceItem.LValueDesc.ToString(CultureInfo.InvariantCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueSupplier", pInvoiceItem.LValueSupplier.ToString(CultureInfo.InvariantCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueTaxes", pInvoiceItem.LValueTaxes.ToString(CultureInfo.InvariantCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueTotal", pInvoiceItem.LValueTotal.ToString(CultureInfo.InvariantCulture));
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pInvoiceItem.LStatus.LIdStatus);
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pInvoiceItem.LObject.LIdObject.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranInsertInvoiceItem", "spr_CreateInvoiceItem");
        }

        public string Dao_UpdateInvoiceIem(Bo_InvoiceItem pInvoiceItem)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInvoiceItem", pInvoiceItem.LIdInvoiceItem.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdProduct", pInvoiceItem.LProduct.LIdProduct.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pInvoiceItem.LStatus.LIdStatus);
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranUpdateInvoiceItem", "spr_UpdateInvoiceItem");
        }

        public string Dao_DeleteInvoiceItem(Bo_InvoiceItem pInvoiceItem)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInvoiceItem", pInvoiceItem.LIdInvoiceItem.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranDeleteInvoiceItem", "spr_DeleteInvoiceItem");
        }
    }
}
