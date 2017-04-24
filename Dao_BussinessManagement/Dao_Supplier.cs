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
    public class Dao_Supplier
    {
        List<SqlParameter> lListParam = new List<SqlParameter>();

        public Bo_Supplier Dao_getSupplierById(int pIdSupplier)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetSupplier";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("IdSupplier", pIdSupplier));

                    var lReader = lCommand.ExecuteReader();
                    Bo_Supplier oSupplier = new Bo_Supplier();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            oSupplier.LStatus = new Bo_Status();
                            oSupplier.LObject = new Bo_Object();
                            oSupplier.LTypeIdentification = new Bo_TypeIdentification();
                            oSupplier.LIdSupplier = Convert.ToInt32(lReader["IdSupplier"].ToString());
                            oSupplier.LNameSupplier = lReader["NameSupplier"].ToString();
                            oSupplier.LTypeIdentification.LIdTypeIdentification = Convert.ToInt32(lReader["IdTypeIdentification"].ToString());
                            oSupplier.LTypeIdentification.LTypeIdentification = lReader["TypeIdentification"].ToString();
                            oSupplier.LNoIdentification = lReader["NoIdentification"].ToString();
                            oSupplier.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oSupplier.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oSupplier.LStatus.LDsEstado = lReader["DsEstado"].ToString();
                            oSupplier.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            oSupplier.LObject.LNameObject = lReader["NameObject"].ToString();
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oSupplier;
                }
                catch (Exception e)
                {
                    Bo_Supplier oSupplier = new Bo_Supplier();
                    oSupplier.LException = e.Message;
                    if (e.InnerException != null)
                        oSupplier.LInnerException = e.InnerException.ToString();
                    oSupplier.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oSupplier;
                }
            }
        }

        public List<Bo_Supplier> Dao_getSupplierListAll()
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetListAllSupplier";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    var lReader = lCommand.ExecuteReader();
                    List<Bo_Supplier> oListSupplier = new List<Bo_Supplier>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_Supplier oSupplier = new Bo_Supplier();
                            oSupplier.LStatus = new Bo_Status();
                            oSupplier.LObject = new Bo_Object();
                            oSupplier.LTypeIdentification = new Bo_TypeIdentification();
                            oSupplier.LIdSupplier = Convert.ToInt32(lReader["IdSupplier"].ToString());
                            oSupplier.LNameSupplier = lReader["NameSupplier"].ToString();
                            oSupplier.LTypeIdentification.LIdTypeIdentification = Convert.ToInt32(lReader["IdTypeIdentification"].ToString());
                            oSupplier.LTypeIdentification.LTypeIdentification = lReader["TypeIdentification"].ToString();
                            oSupplier.LNoIdentification = lReader["NoIdentification"].ToString();
                            oSupplier.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oSupplier.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oSupplier.LStatus.LDsEstado = lReader["DsEstado"].ToString();
                            oSupplier.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            oSupplier.LObject.LNameObject = lReader["NameObject"].ToString();
                            oListSupplier.Add(oSupplier);
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListSupplier;
                }
                catch (Exception e)
                {
                    List<Bo_Supplier> oListSupplier = new List<Bo_Supplier>();
                    Bo_Supplier oSupplier = new Bo_Supplier();
                    oSupplier.LException = e.Message;
                    if (e.InnerException != null)
                        oSupplier.LInnerException = e.InnerException.ToString();
                    oSupplier.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    oListSupplier.Add(oSupplier);
                    return oListSupplier;
                }
            }
        }

        public string Dao_InsertSupplier(Bo_Supplier pSupplier)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@NameSupplier", pSupplier.LNameSupplier);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdTypeIdentification", pSupplier.LTypeIdentification.LIdTypeIdentification.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@NoIdentification", pSupplier.LNoIdentification.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pSupplier.LStatus.LIdStatus.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdObject", pSupplier.LObject.LIdObject.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranInsertSupplier", "spr_CreateSupplier");
        }

        public string Dao_UpdateSupplier(Bo_Supplier pSupplier)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdSupplier", pSupplier.LIdSupplier.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@NameSupplier", pSupplier.LNameSupplier);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdTypeIdentification", pSupplier.LTypeIdentification.LIdTypeIdentification.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@NoIdentification", pSupplier.LNoIdentification.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pSupplier.LStatus.LIdStatus.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdObject", pSupplier.LObject.LIdObject.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranUpdateSupplier", "spr_UpdateSupplier");
        }

        public string Dao_DeleteSupplier(Bo_Supplier pSupplier)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdSupplier", pSupplier.LIdSupplier.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranDeleteSupplier", "spr_DeleteSupplier");
        }
    }
}
