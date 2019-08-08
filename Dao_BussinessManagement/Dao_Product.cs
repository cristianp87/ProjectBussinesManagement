using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using BO_BusinessManagement.Enums;
using IDaoBusiness.Business;

namespace Dao_BussinessManagement
{
    public class DaoProduct : IDaoProduct
    {
        private List<SqlParameter> LListParam { get; set; }

        public BoProduct Dao_getProductById(int pIdProduct)
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = DaoUtilsLib.Dao_SqlConnection(lConex))
            {
                var lProduct = new BoProduct();
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
                            lProduct.LUnit = new BoUnit {LIdUnit = Convert.ToInt32(lReader["IdUnit"].ToString())};
                            lProduct.LValue = Convert.ToDecimal(lReader["Price"].ToString());
                            lProduct.LSupplier = new BoSupplier
                            {
                                LIdSupplier = Convert.ToInt32(lReader["IdSupplier"].ToString())
                            };
                            lProduct.LValueSupplier = Convert.ToDecimal(lReader["PriceSupplier"].ToString());
                            lProduct.LStatus = new BoStatus
                            {
                                LIdStatus = lReader["IdStatus"].ToString(),
                                LDsEstado = lReader["DsEstado"].ToString()
                            };
                            lProduct.LObject = new BoObject
                            {
                                LIdObject = Convert.ToInt32(lReader["IdObject"].ToString()),
                                LNameObject = lReader["NameObject"].ToString()
                            };
                        }
                    }
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return lProduct;
                }
                catch (Exception e)
                {
                    lProduct = new BoProduct {LException = e.Message, LMessageDao = BoErrors.MsgErrorGetSql};
                    if (e.InnerException != null)
                        lProduct.LInnerException = e.InnerException.ToString();
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return lProduct;
                }
            }
        }

        public BoProduct Dao_getProductByCode(string pCdProduct)
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = DaoUtilsLib.Dao_SqlConnection(lConex))
            {
                var lProduct = new BoProduct();
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
                            lProduct.LUnit = new BoUnit {LIdUnit = Convert.ToInt32(lReader["IdUnit"].ToString())};
                            lProduct.LValue = Convert.ToDecimal(lReader["Price"].ToString());
                            lProduct.LSupplier = new BoSupplier
                            {
                                LIdSupplier = Convert.ToInt32(lReader["IdSupplier"].ToString())
                            };
                            lProduct.LValueSupplier = Convert.ToDecimal(lReader["PriceSupplier"].ToString());
                            lProduct.LStatus = new BoStatus
                            {
                                LIdStatus = lReader["IdStatus"].ToString(),
                                LDsEstado = lReader["DsEstado"].ToString()
                            };
                            lProduct.LObject = new BoObject
                            {
                                LIdObject = Convert.ToInt32(lReader["IdObject"].ToString()),
                                LNameObject = lReader["NameObject"].ToString()
                            };
                        }
                    }
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return lProduct;
                }
                catch (Exception e)
                {
                    lProduct = new BoProduct {LException = e.Message, LMessageDao = BoErrors.MsgErrorGetSql};
                    if (e.InnerException != null)
                        lProduct.LInnerException = e.InnerException.ToString();
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return lProduct;
                }
            }
        }

        public List<BoProduct> Dao_getProductListAll()
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = DaoUtilsLib.Dao_SqlConnection(lConex))
            {
                var lListProduct = new List<BoProduct>();
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
                            var oProduct = new BoProduct
                            {
                                LStatus = new BoStatus
                                {
                                    LIdStatus = lReader["IdStatus"].ToString(),
                                    LDsEstado = lReader["DsEstado"].ToString()
                                },
                                LObject = new BoObject
                                {
                                    LIdObject = Convert.ToInt32(lReader["IdObject"].ToString()),
                                    LNameObject = lReader["NameObject"].ToString()
                                },
                                LUnit = new BoUnit {LIdUnit = Convert.ToInt32(lReader["IdUnit"].ToString())},
                                LSupplier =
                                    new BoSupplier {LIdSupplier = Convert.ToInt32(lReader["IdSupplier"].ToString())},
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
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return lListProduct;
                }
                catch (Exception e)
                {
                    lListProduct = new List<BoProduct>();
                    var oProduct = new BoProduct {LException = e.Message, LMessageDao = BoErrors.MsgErrorGetSql};
                    if (e.InnerException != null)
                        oProduct.LInnerException = e.InnerException.ToString();
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    lListProduct.Add(oProduct);
                    return lListProduct;
                }
            }
        }

        public string Dao_InsertProduct(BoProduct pProduct)
        {
            this.LListParam = new List<SqlParameter>();
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@NameProduct", pProduct.LNameProduct);
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@CdProduct", pProduct.LCdProduct);
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdUnit", pProduct.LUnit.LIdUnit.ToString());
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@Price", pProduct.LValue.ToString(CultureInfo.CurrentCulture));
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdSupplier", pProduct.LSupplier.LIdSupplier.ToString());
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@PriceSupplier", pProduct.LValueSupplier.ToString(CultureInfo.CurrentCulture));
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pProduct.LStatus.LIdStatus);
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pProduct.LObject.LIdObject.ToString());
            return DaoUtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranInsertProduct", "spr_CreateProduct");
        }

        public string Dao_UpdateProduct(BoProduct pProduct)
        {
            this.LListParam = new List<SqlParameter>();
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdProduct", pProduct.LIdProduct.ToString());
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@NameProduct", pProduct.LNameProduct);
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@CdProduct", pProduct.LCdProduct);
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdUnit", pProduct.LUnit.LIdUnit.ToString());
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@Price", pProduct.LValue.ToString(CultureInfo.InvariantCulture));
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdSupplier", pProduct.LSupplier.LIdSupplier.ToString());
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@PriceSupplier", pProduct.LValueSupplier.ToString(CultureInfo.InvariantCulture));
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pProduct.LStatus.LIdStatus);
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pProduct.LObject.LIdObject.ToString());
            return DaoUtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranUpdateProduct", "spr_UpdateProduct");
        }

        public string Dao_DeleteProduct(BoProduct pProduct)
        {
            this.LListParam = new List<SqlParameter>();
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdProduct", pProduct.LIdProduct.ToString());
            return DaoUtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranDeleteProduct", "spr_DeleteProduct");
        }
    }
}
