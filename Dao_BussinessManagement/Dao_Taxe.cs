using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Dao_BussinessManagement
{
    public class Dao_Taxe
    {
        List<SqlParameter> lListParam = new List<SqlParameter>();
        public List<Bo_Taxe> Dao_getLisAllTaxesXProduct(int idProduct)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetListAllTaxesXProduct";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add("idProduct", SqlDbType.Int).Value = idProduct;
                    var lReader = lCommand.ExecuteReader();
                    List<Bo_Taxe> oListTaxe = new List<Bo_Taxe>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_Taxe oTaxe = new Bo_Taxe();
                            oTaxe.LStatus = new Bo_Status();
                            oTaxe.LObject = new Bo_Object();
                            oTaxe.LIdTaxe = Convert.ToInt32(lReader["IdTax"].ToString());
                            oTaxe.LNameTaxe = lReader["NameTax"].ToString();
                            oTaxe.LIsPercent = Convert.ToBoolean(lReader["IsPercent"].ToString());
                            oTaxe.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oTaxe.LValueTaxe = Convert.ToDecimal(lReader["ValueTax"].ToString());
                            oTaxe.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oTaxe.LStatus.LDsEstado = lReader["DsEstado"].ToString();
                            oTaxe.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            oTaxe.LObject.LNameObject = lReader["NameObject"].ToString();
                            oListTaxe.Add(oTaxe);
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListTaxe;
                }
                catch (Exception e)
                {
                    List<Bo_Taxe> oListTaxe = new List<Bo_Taxe>();
                    Bo_Taxe oTaxe = new Bo_Taxe();
                    oTaxe.LException = e.Message;
                    if (e.InnerException != null)
                        oTaxe.LInnerException = e.InnerException.ToString();
                    oTaxe.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    oListTaxe.Add(oTaxe);
                    return oListTaxe;
                }
            }
        }

        public List<Bo_Taxe> Dao_getLisTaxes()
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetListTaxes";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    var lReader = lCommand.ExecuteReader();
                    List<Bo_Taxe> oListTaxe = new List<Bo_Taxe>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_Taxe oTaxe = new Bo_Taxe();
                            oTaxe.LStatus = new Bo_Status();
                            oTaxe.LObject = new Bo_Object();
                            oTaxe.LIdTaxe = Convert.ToInt32(lReader["IdTax"].ToString());
                            oTaxe.LNameTaxe = lReader["NameTax"].ToString();
                            oTaxe.LIsPercent = Convert.ToBoolean(lReader["IsPercent"].ToString());
                            oTaxe.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oTaxe.LValueTaxe = Convert.ToDecimal(lReader["ValueTax"].ToString());
                            oTaxe.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oTaxe.LStatus.LNameStatus = lReader["NameStatus"].ToString();
                            oTaxe.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            oTaxe.LObject.LNameObject = lReader["NameObject"].ToString();
                            oListTaxe.Add(oTaxe);
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListTaxe;
                }
                catch (Exception e)
                {
                    List<Bo_Taxe> oListTaxe = new List<Bo_Taxe>();
                    Bo_Taxe oTaxe = new Bo_Taxe();
                    oTaxe.LException = e.Message;
                    if (e.InnerException != null)
                        oTaxe.LInnerException = e.InnerException.ToString();
                    oTaxe.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    oListTaxe.Add(oTaxe);
                    return oListTaxe;
                }
            }
        }

        public List<Bo_Taxe> Dao_getLisAllTaxesWithOutProduct(int pIdProduct)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetListTaxesWithOutProduct";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add("IdProduct", SqlDbType.Int).Value = pIdProduct;
                    var lReader = lCommand.ExecuteReader();
                    List<Bo_Taxe> oListTaxe = new List<Bo_Taxe>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_Taxe oTaxe = new Bo_Taxe();
                            oTaxe.LStatus = new Bo_Status();
                            oTaxe.LObject = new Bo_Object();
                            oTaxe.LIdTaxe = Convert.ToInt32(lReader["IdTax"].ToString());
                            oTaxe.LNameTaxe = lReader["NameTax"].ToString();
                            oTaxe.LIsPercent = Convert.ToBoolean(lReader["IsPercent"].ToString());
                            oTaxe.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oTaxe.LValueTaxe = Convert.ToDecimal(lReader["ValueTax"].ToString());
                            oTaxe.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oTaxe.LStatus.LDsEstado = lReader["NameStatus"].ToString();
                            oTaxe.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            oTaxe.LObject.LNameObject = lReader["NameObject"].ToString();
                            oListTaxe.Add(oTaxe);
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListTaxe;
                }
                catch (Exception e)
                {
                    List<Bo_Taxe> oListTaxe = new List<Bo_Taxe>();
                    Bo_Taxe oTaxe = new Bo_Taxe();
                    oTaxe.LException = e.Message;
                    if (e.InnerException != null)
                        oTaxe.LInnerException = e.InnerException.ToString();
                    oTaxe.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    oListTaxe.Add(oTaxe);
                    return oListTaxe;
                }
            }
        }

        public Bo_Taxe Dao_getTaxeById(int pIdTaxe)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetTaxeById";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("IdTaxe", pIdTaxe));

                    var lReader = lCommand.ExecuteReader();
                    Bo_Taxe lTaxe = new Bo_Taxe();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            lTaxe.LStatus = new Bo_Status();
                            lTaxe.LObject = new Bo_Object();
                            lTaxe.LIdTaxe = Convert.ToInt32(lReader["IdTax"].ToString());
                            lTaxe.LNameTaxe = lReader["NameTax"].ToString();
                            lTaxe.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            lTaxe.LValueTaxe = Convert.ToDecimal(lReader["ValueTax"].ToString());
                            lTaxe.LIsPercent = Convert.ToBoolean(lReader["IsPercent"].ToString());
                            lTaxe.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            lTaxe.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lTaxe;
                }
                catch (Exception e)
                {
                    Bo_Taxe lTaxe = new Bo_Taxe();
                    lTaxe.LException = e.Message;
                    if (e.InnerException != null)
                        lTaxe.LInnerException = e.InnerException.ToString();
                    lTaxe.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lTaxe;
                }
            }
        }

        public string Dao_InsertTaxeXProduct(int pIdProduct, int pIdTaxe)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdProduct", pIdProduct.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdTaxe", pIdTaxe.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranInsertTaxeXProduct", "spr_CreateTaxeXProduct");
        }

        public string Dao_DeleteTaxeXProduct(int pIdProduct, int pIdTaxe)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdProduct", pIdProduct.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdTaxe", pIdTaxe.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranDeleteTaxeXProduct", "spr_DeleteTaxeXProduct");
        }


    }
}
