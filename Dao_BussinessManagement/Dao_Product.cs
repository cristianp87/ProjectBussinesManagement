using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using IDaoBusiness.Business;

namespace Dao_BussinessManagement
{
    public class DaoProduct : IDaoProduct
    {
        private List<SqlParameter> LListParam { get; set; }

        public Bo_Product Dao_getProductById(int pIdProduct)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                var lProduct = new Bo_Product();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetProduct",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("IdProduct", pIdProduct));

                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {                           
                            
                            
                            
                            lProduct.LIdProduct = Convert.ToInt32(lReader["IdProduct"].ToString());
                            lProduct.LNameProduct = lReader["NameProduct"].ToString();
                            lProduct.LCdProduct = lReader["CdProduct"].ToString();
                            lProduct.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            lProduct.LUnit = new Bo_Unit {LIdUnit = Convert.ToInt32(lReader["IdUnit"].ToString())};
                            lProduct.LValue = Convert.ToDecimal(lReader["Price"].ToString());
                            lProduct.LSupplier = new Bo_Supplier
                            {
                                LIdSupplier = Convert.ToInt32(lReader["IdSupplier"].ToString())
                            };
                            lProduct.LValueSupplier = Convert.ToDecimal(lReader["PriceSupplier"].ToString());
                            lProduct.LStatus = new Bo_Status
                            {
                                LIdStatus = lReader["IdStatus"].ToString(),
                                LDsEstado = lReader["DsEstado"].ToString()
                            };
                            lProduct.LObject = new Bo_Object
                            {
                                LIdObject = Convert.ToInt32(lReader["IdObject"].ToString()),
                                LNameObject = lReader["NameObject"].ToString()
                            };
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lProduct;
                }
                catch (Exception e)
                {
                    lProduct = new Bo_Product {LException = e.Message, LMessageDao = "Hubo un problema en la consulta, contacte al administrador."};
                    if (e.InnerException != null)
                        lProduct.LInnerException = e.InnerException.ToString();
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lProduct;
                }
            }
        }

        public Bo_Product Dao_getProductByCode(string pCdProduct)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                var lProduct = new Bo_Product();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetProductByCode",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("CdProduct", pCdProduct));

                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {                            
                            lProduct.LIdProduct = Convert.ToInt32(lReader["IdProduct"].ToString());
                            lProduct.LNameProduct = lReader["NameProduct"].ToString();
                            lProduct.LCdProduct = lReader["CdProduct"].ToString();
                            lProduct.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            lProduct.LUnit = new Bo_Unit {LIdUnit = Convert.ToInt32(lReader["IdUnit"].ToString())};
                            lProduct.LValue = Convert.ToDecimal(lReader["Price"].ToString());
                            lProduct.LSupplier = new Bo_Supplier
                            {
                                LIdSupplier = Convert.ToInt32(lReader["IdSupplier"].ToString())
                            };
                            lProduct.LValueSupplier = Convert.ToDecimal(lReader["PriceSupplier"].ToString());
                            lProduct.LStatus = new Bo_Status
                            {
                                LIdStatus = lReader["IdStatus"].ToString(),
                                LDsEstado = lReader["DsEstado"].ToString()
                            };
                            lProduct.LObject = new Bo_Object
                            {
                                LIdObject = Convert.ToInt32(lReader["IdObject"].ToString()),
                                LNameObject = lReader["NameObject"].ToString()
                            };
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lProduct;
                }
                catch (Exception e)
                {
                    lProduct = new Bo_Product {LException = e.Message, LMessageDao = "Hubo un problema en la consulta, contacte al administrador." };
                    if (e.InnerException != null)
                        lProduct.LInnerException = e.InnerException.ToString();
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lProduct;
                }
            }
        }

        public List<Bo_Product> Dao_getProductListAll()
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                var lListProduct = new List<Bo_Product>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListAllProduct",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var oProduct = new Bo_Product
                            {
                                LStatus = new Bo_Status
                                {
                                    LIdStatus = lReader["IdStatus"].ToString(),
                                    LDsEstado = lReader["DsEstado"].ToString()
                                },
                                LObject = new Bo_Object
                                {
                                    LIdObject = Convert.ToInt32(lReader["IdObject"].ToString()),
                                    LNameObject = lReader["NameObject"].ToString()
                                },
                                LUnit = new Bo_Unit {LIdUnit = Convert.ToInt32(lReader["IdUnit"].ToString())},
                                LSupplier =
                                    new Bo_Supplier {LIdSupplier = Convert.ToInt32(lReader["IdSupplier"].ToString())},
                                LIdProduct = Convert.ToInt32(lReader["IdProduct"].ToString()),
                                LNameProduct = lReader["NameProduct"].ToString(),
                                LCdProduct = lReader["CdProduct"].ToString(),
                                LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString()),
                                LValue = Convert.ToDecimal(lReader["Price"].ToString()),
                                LValueSupplier = Convert.ToDecimal(lReader["PriceSupplier"].ToString())
                            };
                            lListProduct.Add(oProduct);
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lListProduct;
                }
                catch (Exception e)
                {
                    lListProduct = new List<Bo_Product>();
                    var oProduct = new Bo_Product {LException = e.Message, LMessageDao = "Hubo un problema en la consulta, contacte al administrador." };
                    if (e.InnerException != null)
                        oProduct.LInnerException = e.InnerException.ToString();
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    lListProduct.Add(oProduct);
                    return lListProduct;
                }
            }
        }

        public string Dao_InsertProduct(Bo_Product pProduct)
        {
            this.LListParam = new List<SqlParameter>();
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@NameProduct", pProduct.LNameProduct);
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@CdProduct", pProduct.LCdProduct);
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdUnit", pProduct.LUnit.LIdUnit.ToString());
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@Price", pProduct.LValue.ToString());
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdSupplier", pProduct.LSupplier.LIdSupplier.ToString());
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@PriceSupplier", pProduct.LValue.ToString());
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pProduct.LStatus.LIdStatus.ToString());
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pProduct.LObject.LIdObject.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranInsertProduct", "spr_CreateProduct");
        }

        public string Dao_UpdateProduct(Bo_Product pProduct)
        {
            this.LListParam = new List<SqlParameter>();
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdProduct", pProduct.LIdProduct.ToString());
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@NameProduct", pProduct.LNameProduct);
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@CdProduct", pProduct.LCdProduct);
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdUnit", pProduct.LUnit.LIdUnit.ToString());
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@Price", pProduct.LValue.ToString(CultureInfo.InvariantCulture));
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdSupplier", pProduct.LSupplier.LIdSupplier.ToString());
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@PriceSupplier", pProduct.LValueSupplier.ToString(CultureInfo.InvariantCulture));
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pProduct.LStatus.LIdStatus);
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pProduct.LObject.LIdObject.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranUpdateProduct", "spr_UpdateProduct");
        }

        public string Dao_DeleteProduct(Bo_Product pProduct)
        {
            this.LListParam = new List<SqlParameter>();
            Dao_UtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdProduct", pProduct.LIdProduct.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranDeleteProduct", "spr_DeleteProduct");
        }
    }
}
