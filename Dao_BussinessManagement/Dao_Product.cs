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
    public class Dao_Product
    {
        List<SqlParameter> lListParam = new List<SqlParameter>();

        public Bo_Product Dao_getProductById(int pIdProduct)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetProduct";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("IdProduct", pIdProduct));

                    var lReader = lCommand.ExecuteReader();
                    Bo_Product oProduct = new Bo_Product();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            oProduct.LStatus = new Bo_Status();
                            oProduct.LObject = new Bo_Object();
                            oProduct.LUnit = new Bo_Unit();
                            oProduct.LSupplier = new Bo_Supplier();
                            oProduct.LIdProduct = Convert.ToInt32(lReader["IdProduct"].ToString());
                            oProduct.LNameProduct = lReader["NameProduct"].ToString();
                            oProduct.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oProduct.LUnit.LIdUnit = Convert.ToInt32(lReader["IdUnit"].ToString());
                            oProduct.LValue = Convert.ToDecimal(lReader["Price"].ToString());
                            oProduct.LSupplier.LIdSupplier = Convert.ToInt32(lReader["IdSupplier"].ToString());
                            oProduct.LValueSupplier = Convert.ToDecimal(lReader["PriceSupplier"].ToString());
                            oProduct.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oProduct.LStatus.LDsEstado = lReader["DsEstado"].ToString();
                            oProduct.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            oProduct.LObject.LNameObject = lReader["NameObject"].ToString();
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oProduct;
                }
                catch (Exception e)
                {
                    Bo_Product oProduct = new Bo_Product();
                    oProduct.LException = e.Message;
                    if (e.InnerException != null)
                        oProduct.LInnerException = e.InnerException.ToString();
                    oProduct.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oProduct;
                }
            }
        }

        public List<Bo_Product> Dao_getProductListAll()
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetListAllProduct";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    var lReader = lCommand.ExecuteReader();
                    List<Bo_Product> oListProduct = new List<Bo_Product>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_Product oProduct = new Bo_Product();
                            oProduct.LStatus = new Bo_Status();
                            oProduct.LObject = new Bo_Object();
                            oProduct.LUnit = new Bo_Unit();
                            oProduct.LIdProduct = Convert.ToInt32(lReader["IdProduct"].ToString());
                            oProduct.LNameProduct = lReader["NameProduct"].ToString();
                            oProduct.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oProduct.LUnit.LIdUnit = Convert.ToInt32(lReader["IdUnit"].ToString());
                            oProduct.LValue = Convert.ToDecimal(lReader["Price"].ToString());
                            oProduct.LSupplier.LIdSupplier = Convert.ToInt32(lReader["IdSupplier"].ToString());
                            oProduct.LValueSupplier = Convert.ToDecimal(lReader["PriceSupplier"].ToString());
                            oProduct.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oProduct.LStatus.LDsEstado = lReader["DsEstado"].ToString();
                            oProduct.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            oProduct.LObject.LNameObject = lReader["NameObject"].ToString();
                            oListProduct.Add(oProduct);
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListProduct;
                }
                catch (Exception e)
                {
                    List<Bo_Product> oListProduct = new List<Bo_Product>();
                    Bo_Product oProduct = new Bo_Product();
                    oProduct.LException = e.Message;
                    if (e.InnerException != null)
                        oProduct.LInnerException = e.InnerException.ToString();
                    oProduct.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    oListProduct.Add(oProduct);
                    return oListProduct;
                }
            }
        }

        public string Dao_InsertProduct(Bo_Product pProduct)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@NameProduct", pProduct.LNameProduct);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdUnit", pProduct.LUnit.LIdUnit.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@Price", pProduct.LValue.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdSupplier", pProduct.LSupplier.LIdSupplier.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@PriceSupplier", pProduct.LValue.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pProduct.LStatus.LIdStatus.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdObject", pProduct.LObject.LIdObject.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranInsertProduct", "spr_CreateProduct");
        }

        public string Dao_UpdateInvoice(Bo_Product pProduct)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdProduct", pProduct.LIdProduct.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@NameProduct", pProduct.LNameProduct);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdUnit", pProduct.LUnit.LIdUnit.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@Price", pProduct.LValue.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdSupplier", pProduct.LSupplier.LIdSupplier.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@PriceSupplier", pProduct.LValue.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pProduct.LStatus.LIdStatus.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdObject", pProduct.LObject.LIdObject.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranUpdateProduct", "spr_UpdateProduct");
        }

        public string Dao_DeleteProduct(Bo_Product pProduct)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdProduct", pProduct.LIdProduct.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranDeleteProduct", "spr_DeleteProduct");
        }
    }
}
