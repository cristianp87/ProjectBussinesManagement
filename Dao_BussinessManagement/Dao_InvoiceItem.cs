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
    public class Dao_InvoiceItem
    {
        List<SqlParameter> lListParam = new List<SqlParameter>();

        public List<Bo_InvoiceItem> Dao_getInvoiceItemByIdInvoice(int pIdInvoice)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {

                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetListInvoiceItem";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("IdInvoice", pIdInvoice));

                    var lReader = lCommand.ExecuteReader();
                    List<Bo_InvoiceItem> oListInvoiceItem = new List<Bo_InvoiceItem>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_InvoiceItem oInvoiceItem = new Bo_InvoiceItem();
                            oInvoiceItem.LStatus = new Bo_Status();
                            oInvoiceItem.LObject = new Bo_Object();
                            oInvoiceItem.LProduct = new Bo_Product();
                            oInvoiceItem.LIdInvoiceItem = Convert.ToInt32(lReader["IdInvoiceItem"].ToString());
                            oInvoiceItem.LIdInvoice = Convert.ToInt32(lReader["IdInvoice"].ToString());
                            oInvoiceItem.LProduct.LIdProduct = Convert.ToInt32(lReader["IdProduct"].ToString());
                            oInvoiceItem.LProduct.LNameProduct = lReader["NameProduct"].ToString();
                            oInvoiceItem.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oInvoiceItem.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oInvoiceItem.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            oListInvoiceItem.Add(oInvoiceItem);
                        }


                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListInvoiceItem;
                }
                catch (Exception e)
                {
                    List<Bo_InvoiceItem> oListInvoiceItem = new List<Bo_InvoiceItem>();
                    Bo_InvoiceItem oInvoiceItem = new Bo_InvoiceItem();
                    oInvoiceItem.LException = e.Message;
                    if (e.InnerException != null)
                        oInvoiceItem.LInnerException = e.InnerException.ToString();
                    oInvoiceItem.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    oListInvoiceItem.Add(oInvoiceItem);
                    return oListInvoiceItem;
                }
            }
        }

        public string Dao_InsertInvoiceItem(Bo_InvoiceItem pInvoiceItem)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdInvoice", pInvoiceItem.LIdInvoice.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdProduct", pInvoiceItem.LProduct.LIdProduct.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@Qty", pInvoiceItem.LQuantity.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@ValueProduct", pInvoiceItem.LValueProd.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@ValueDesc", pInvoiceItem.LValueDesc.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@ValueSupplier", pInvoiceItem.LValueSupplier.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@ValueTaxes", pInvoiceItem.LValueTaxes.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@ValueTotal", pInvoiceItem.LValueTotal.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pInvoiceItem.LStatus.LIdStatus);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdObject", pInvoiceItem.LObject.LIdObject.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranInsertInvoiceItem", "spr_CreateInvoiceItem");
        }

        public string Dao_UpdateInvoiceIem(Bo_InvoiceItem pInvoiceItem)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdInvoiceItem", pInvoiceItem.LIdInvoiceItem.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdProduct", pInvoiceItem.LProduct.LIdProduct.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pInvoiceItem.LStatus.LIdStatus.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranUpdateInvoiceItem", "spr_UpdateInvoiceItem");
        }

        public string Dao_DeleteInvoiceItem(Bo_InvoiceItem pInvoiceItem)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdInvoiceItem", pInvoiceItem.LIdInvoiceItem.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranDeleteInvoiceItem", "spr_DeleteInvoiceItem");
        }
    }
}
