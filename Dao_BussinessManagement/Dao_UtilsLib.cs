using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Dao_BussinessManagement
{
    public class Dao_UtilsLib
    {
        private static string lConnectionString = ConfigurationManager.ConnectionStrings["Conex_Business"].ConnectionString;

        public static SqlConnection Dao_SqlConnection(SqlConnection lConn)
        {
            lConn = new SqlConnection(lConnectionString);           
            if(lConn.State == ConnectionState.Open)
            {
                return lConn;
            }
            lConn.Open();
            return lConn;
            
        }

        public static void Dao_CloseSqlconnection(SqlConnection pConex)
        {
            pConex.Close();
        }

        public static void dao_Addparameters(List<SqlParameter> pListParam, SqlDbType pType, string pNameParameter, string pValue)
        {
            SqlParameter lParameter = new SqlParameter(pNameParameter, pType);
            lParameter.Value = pValue;
            pListParam.Add(lParameter); 
        }

        public static string Dao_executeSqlTransactionWithProcedement(List<SqlParameter> lListParameters, string pNameTransaction, string pNameProcedure)
        {
            
            string lResult = null;
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                using (SqlTransaction lTran = lConex.BeginTransaction(pNameTransaction))
                {
                    SqlCommand lCommand = lConex.CreateCommand();
                    lCommand.Connection = lConex;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Transaction = lTran;
                    try
                    {
                        lCommand.CommandType = CommandType.StoredProcedure;
                        lCommand.CommandText = pNameProcedure;                      
                        lCommand.CommandTimeout = 30;

                        if (lListParameters.Count > 0)
                        {
                            lListParameters.ForEach(x => { lCommand.Parameters.Add(x); });
                        }
                        lCommand.ExecuteNonQuery();
                        lTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        lResult = "Commit Exception Type: " + ex.GetType() + "  Message: " + ex.Message;

                        try
                        {
                            lTran.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            lResult += " Rollback Exception Type: " + ex2.GetType() + "  Message: " + ex2.Message;
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection( lConex);
                }
            }
            return lResult;
        }

        public static string Dao_executeSqlScalarWithProcedement(List<SqlParameter> lListParameters, string pNameTransaction, string pNameProcedure)
        {

            string lResult = null;
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                using (SqlTransaction lTran = lConex.BeginTransaction(pNameTransaction))
                {
                    SqlCommand lCommand = lConex.CreateCommand();
                    lCommand.Connection = lConex;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Transaction = lTran;
                    try
                    {
                        lCommand.CommandType = CommandType.StoredProcedure;
                        lCommand.CommandText = pNameProcedure;
                        lCommand.CommandTimeout = 30;

                        if (lListParameters.Count > 0)
                        {
                            lListParameters.ForEach(x => { lCommand.Parameters.Add(x); });
                        }
                        lResult = lCommand.ExecuteScalar().ToString();
                        lTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        lResult = "Commit Exception Type: " + ex.GetType() + "  Message: " + ex.Message;

                        try
                        {
                            lTran.Rollback();
                        }
                        catch (Exception ex2)
                        {
                            lResult += " Rollback Exception Type: " + ex2.GetType() + "  Message: " + ex2.Message;
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                }
            }
            return lResult;
        }

        public static Bo_Object DaoUtilsLib_getObject(string lNameObject){
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {

                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_getObjectByName";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("NameObject", lNameObject));
                    var lReader = lCommand.ExecuteReader();
                    Bo_Object oObject = new Bo_Object();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {   
                            oObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            oObject.LNameObject = lReader["NameObject"].ToString();
                            oObject.LActive = Convert.ToBoolean(lReader["flActive"].ToString());
                        }


                    }
                    Dao_CloseSqlconnection(lConex);
                    return oObject;
                }
                catch (Exception e)
                {
                    Bo_Object oObject = new Bo_Object();
                    oObject.LException = e.Message;
                    if (e.InnerException != null)
                        oObject.LInnerException = e.InnerException.ToString();
                    oObject.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_CloseSqlconnection(lConex);
                    return oObject;
                }

            }
        }

        public static Bo_Status DaoUtilsLib_getStatusAppro(int pIdObject)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {

                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetStatusApproByIdObject";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("IdObject", pIdObject));
                    var lReader = lCommand.ExecuteReader();
                    Bo_Status lStatus = new Bo_Status();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            lStatus.LIdStatus = lReader["IdStatus"].ToString();
                            lStatus.LNameStatus = lReader["NameStatus"].ToString();
                            lStatus.LDsEstado = lReader["DsEstado"].ToString();
                            lStatus.LFlActive = Convert.ToBoolean(lReader["flActive"].ToString());
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lStatus;
                }
                catch (Exception e)
                {
                    Bo_Status lStatus = new Bo_Status();
                    lStatus.LException = e.Message;
                    if (e.InnerException != null)
                        lStatus.LInnerException = e.InnerException.ToString();
                    lStatus.LMessageDao = "Hubo un problema en la Consulta del estado, contacte al administrador.";
                    Dao_CloseSqlconnection(lConex);
                    return lStatus;
                }

            }
        }

        public static List<Bo_Unit> DaoUtilsLib_getAllUnit()
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {

                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetListAllUnit";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    var lReader = lCommand.ExecuteReader();
                    List<Bo_Unit> oListUnit= new List<Bo_Unit>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_Unit oUnit = new Bo_Unit();
                            oUnit.LIdUnit = Convert.ToInt32(lReader["IdUnit"].ToString());
                            oUnit.LNameUnit = lReader["NameUnit"].ToString();
                            oUnit.LCdUnit = lReader["CdUnit"].ToString();
                            oUnit.LFlActive = Convert.ToBoolean(lReader["flActive"].ToString());
                            oListUnit.Add(oUnit);
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return oListUnit;
                }
                catch (Exception e)
                {
                    List<Bo_Unit> oListUnit = new List<Bo_Unit>();
                    Bo_Unit oUnit = new Bo_Unit();
                    oUnit.LException = e.Message;
                    if (e.InnerException != null)
                        oUnit.LInnerException = e.InnerException.ToString();
                    oUnit.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_CloseSqlconnection(lConex);
                    oListUnit.Add(oUnit);
                    return oListUnit;
                }

            }
        }

        public static string DaoUtilsLib_getParameterValueConfiguration(string pNameParameter, string pNameParameterParent)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetParameterConfigurationValue";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("NameParameter", pNameParameter));
                    lCommand.Parameters.Add(new SqlParameter("NameParentParameter", pNameParameterParent));
                    var lReader = lCommand.ExecuteReader();                 
                    Bo_ConfigurationValue lConfigurationValue = new Bo_ConfigurationValue();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            lConfigurationValue.LIdParameter = Convert.ToInt32(lReader["IdParameter"].ToString());
                            lConfigurationValue.LValueParameter = lReader["Value"].ToString();
                            lConfigurationValue.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lConfigurationValue.LValueParameter;
                }
                catch (Exception e)
                {
                    Bo_ConfigurationValue lConfigurationValue = new Bo_ConfigurationValue();
                    lConfigurationValue.LException = e.Message;
                    if (e.InnerException != null)
                        lConfigurationValue.LInnerException = e.InnerException.ToString();
                    lConfigurationValue.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_CloseSqlconnection(lConex);
                    return lConfigurationValue.LException;
                }

            }
        }

        public static string DaoUtilsLib_getParameterConfigurationActive(string pNameParameter, bool pActive)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetParameterConfigurationActive";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("NameParameter", pNameParameter));
                    lCommand.Parameters.Add(new SqlParameter("flActive", pActive));
                    var lReader = lCommand.ExecuteReader(); 
                    
                    Bo_ConfigurationValue lConfigurationValue = new Bo_ConfigurationValue();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            lConfigurationValue.LIdParameter = Convert.ToInt32(lReader["IdParameter"].ToString());
                            lConfigurationValue.LValueParameter = lReader["Value"].ToString();
                            lConfigurationValue.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lConfigurationValue.LValueParameter;
                }
                catch (Exception e)
                {
                    Bo_ConfigurationValue lConfigurationValue = new Bo_ConfigurationValue();
                    lConfigurationValue.LException = e.Message;
                    if (e.InnerException != null)
                        lConfigurationValue.LInnerException = e.InnerException.ToString();
                    lConfigurationValue.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_CloseSqlconnection(lConex);
                    return lConfigurationValue.LException;
                }

            }
        }



    }
}
