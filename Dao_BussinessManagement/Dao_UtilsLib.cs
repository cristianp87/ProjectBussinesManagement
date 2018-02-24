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
                    var lCommand = lConex.CreateCommand();
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
                    Dao_CloseSqlconnection( lConex);
                }
            }
            return lResult;
        }

        public static string Dao_executeSqlScalarWithProcedement(List<SqlParameter> lListParameters, string pNameTransaction, string pNameProcedure)
        {

            string lResult = null;
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                using (var lTran = lConex.BeginTransaction(pNameTransaction))
                {
                    var lCommand = lConex.CreateCommand();
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
                    Dao_CloseSqlconnection(lConex);
                }
            }
            return lResult;
        }

        public static Bo_Object DaoUtilsLib_getObject(string lNameObject){
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lObject = new Bo_Object();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_getObjectByName",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("NameObject", lNameObject));
                    var lReader = lCommand.ExecuteReader();
                    
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {   
                            lObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            lObject.LNameObject = lReader["NameObject"].ToString();
                            lObject.LActive = Convert.ToBoolean(lReader["flActive"].ToString());
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lObject;
                }
                catch (Exception e)
                {
                    lObject = new Bo_Object
                    {
                        LException = e.Message,
                        LMessageDao = "Hubo un problema en la consulta, contacte al administrador."
                    };
                    if (e.InnerException != null)
                        lObject.LInnerException = e.InnerException.ToString();                  
                    Dao_CloseSqlconnection(lConex);
                    return lObject;
                }

            }
        }

        public static Bo_Status DaoUtilsLib_getStatusAppro(int pIdObject)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lStatus = new Bo_Status();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetStatusApproByIdObject",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("IdObject", pIdObject));
                    var lReader = lCommand.ExecuteReader();
                    
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
                    lStatus = new Bo_Status
                    {
                        LException = e.Message,
                        LMessageDao = "Hubo un problema en la Consulta del estado, contacte al administrador."
                    };
                    if (e.InnerException != null)
                        lStatus.LInnerException = e.InnerException.ToString();                   
                    Dao_CloseSqlconnection(lConex);
                    return lStatus;
                }

            }
        }

        public static List<Bo_Unit> DaoUtilsLib_getAllUnit()
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lListUnit = new List<Bo_Unit>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListAllUnit",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    var lReader = lCommand.ExecuteReader();
                    
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var oUnit = new Bo_Unit
                            {
                                LIdUnit = Convert.ToInt32(lReader["IdUnit"].ToString()),
                                LNameUnit = lReader["NameUnit"].ToString(),
                                LCdUnit = lReader["CdUnit"].ToString(),
                                LFlActive = Convert.ToBoolean(lReader["flActive"].ToString())
                            };
                            lListUnit.Add(oUnit);
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListUnit;
                }
                catch (Exception e)
                {
                    lListUnit = new List<Bo_Unit>();
                    var lUnit = new Bo_Unit
                    {
                        LException = e.Message,
                        LMessageDao = "Hubo un problema en la consulta, contacte al administrador."
                    };
                    if (e.InnerException != null)
                        lUnit.LInnerException = e.InnerException.ToString();                  
                    Dao_CloseSqlconnection(lConex);
                    lListUnit.Add(lUnit);
                    return lListUnit;
                }

            }
        }

        public static string DaoUtilsLib_getParameterValueConfiguration(string pNameParameter, string pNameParameterParent)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lConfigurationValue = new Bo_ConfigurationValue();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetParameterConfigurationValue",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("NameParameter", pNameParameter));
                    lCommand.Parameters.Add(new SqlParameter("NameParentParameter", pNameParameterParent));
                    var lReader = lCommand.ExecuteReader();                                    
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
                    lConfigurationValue = new Bo_ConfigurationValue
                    {
                        LException = e.Message,
                        LMessageDao = "Hubo un problema en la consulta, contacte al administrador."
                    };
                    if (e.InnerException != null)
                        lConfigurationValue.LInnerException = e.InnerException.ToString();                   
                    Dao_CloseSqlconnection(lConex);
                    return lConfigurationValue.LException;
                }

            }
        }

        public static string DaoUtilsLib_getParameterConfigurationActive(string pNameParameter, bool pActive)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lConfigurationValue = new Bo_ConfigurationValue();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetParameterConfigurationActive",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("NameParameter", pNameParameter));
                    lCommand.Parameters.Add(new SqlParameter("flActive", pActive));
                    var lReader = lCommand.ExecuteReader(); 
                    
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
                    lConfigurationValue = new Bo_ConfigurationValue
                    {
                        LException = e.Message,
                        LMessageDao = "Hubo un problema en la consulta, contacte al administrador."
                    };
                    if (e.InnerException != null)
                        lConfigurationValue.LInnerException = e.InnerException.ToString();                  
                    Dao_CloseSqlconnection(lConex);
                    return lConfigurationValue.LException;
                }

            }
        }



    }
}
