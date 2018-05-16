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
    public class DaoInvoiceItem : IDaoInvoiceItem
    {
        List<SqlParameter> LListParam { get; set; }

        public List<BoInvoiceItem> Dao_getInvoiceItemByIdInvoice(int pIdInvoice)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lListInvoiceItem = new List<BoInvoiceItem>();
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
                            var lInvoiceItem = new BoInvoiceItem
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
                    lListInvoiceItem = new List<BoInvoiceItem>();
                    var lInvoiceItem = new BoInvoiceItem {LException = e.Message, LMessageDao = BoErrors.MsgErrorGetSql
                };
                    if (e.InnerException != null)
                        lInvoiceItem.LInnerException = e.InnerException.ToString();
                    Dao_CloseSqlconnection(lConex);
                    lListInvoiceItem.Add(lInvoiceItem);
                    return lListInvoiceItem;
                }
            }
        }

        public string Dao_InsertInvoiceItem(BoInvoiceItem pInvoiceItem)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInvoice", pInvoiceItem.LIdInvoice.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdProduct", pInvoiceItem.LProduct.LIdProduct.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@Qty", pInvoiceItem.LQuantity.ToString(CultureInfo.CurrentCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueProduct", pInvoiceItem.LValueProd.ToString(CultureInfo.CurrentCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueDesc", pInvoiceItem.LValueDesc.ToString(CultureInfo.CurrentCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueSupplier", pInvoiceItem.LValueSupplier.ToString(CultureInfo.CurrentCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueTaxes", pInvoiceItem.LValueTaxes.ToString(CultureInfo.CurrentCulture));
            dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValueTotal", pInvoiceItem.LValueTotal.ToString(CultureInfo.CurrentCulture));
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pInvoiceItem.LStatus.LIdStatus);
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pInvoiceItem.LObject.LIdObject.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranInsertInvoiceItem", "spr_CreateInvoiceItem");
        }

        public string Dao_UpdateInvoiceIem(BoInvoiceItem pInvoiceItem)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInvoiceItem", pInvoiceItem.LIdInvoiceItem.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdProduct", pInvoiceItem.LProduct.LIdProduct.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pInvoiceItem.LStatus.LIdStatus);
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranUpdateInvoiceItem", "spr_UpdateInvoiceItem");
        }

        public string Dao_DeleteInvoiceItem(BoInvoiceItem pInvoiceItem)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInvoiceItem", pInvoiceItem.LIdInvoiceItem.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranDeleteInvoiceItem", "spr_DeleteInvoiceItem");
        }
    }
}
