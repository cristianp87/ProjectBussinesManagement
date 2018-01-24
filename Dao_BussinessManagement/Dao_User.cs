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
    public class Dao_User
    {
        List<SqlParameter> lListParam = new List<SqlParameter>();

        public Bo_User Dao_getUserByUser(string pUser)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetUserByUser";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("User", pUser));

                    var lReader = lCommand.ExecuteReader();
                    Bo_User lUser = new Bo_User();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            lUser.LStatus = new Bo_Status();
                            lUser.LObject = new Bo_Object();
                            lUser.LIdUser = Convert.ToInt32(lReader["IdUser"].ToString());
                            lUser.LUser = lReader["Usuario"].ToString();
                            lUser.LFNameUser = lReader["FName"].ToString();
                            lUser.LSNameUser = lReader["SName"].ToString();
                            lUser.LPassword = lReader["PasswordHash"].ToString(); 
                            lUser.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            lUser.LFLastName = lReader["FLastName"].ToString();
                            lUser.LEmail = lReader["Email"].ToString();
                            lUser.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lUser;
                }
                catch (Exception e)
                {
                    Bo_User lUser = new Bo_User();
                    lUser.LException = e.Message;
                    if (e.InnerException != null)
                        lUser.LInnerException = e.InnerException.ToString();
                    lUser.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lUser;
                }
            }
        }

        public Bo_User Dao_getUserById(int pIdUser)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetUserByIdUser";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("IdUser", pIdUser));

                    var lReader = lCommand.ExecuteReader();
                    Bo_User lUser = new Bo_User();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            lUser.LStatus = new Bo_Status();
                            lUser.LObject = new Bo_Object();
                            lUser.LIdUser = Convert.ToInt32(lReader["IdUser"].ToString());
                            lUser.LUser = lReader["Usuario"].ToString();
                            lUser.LFNameUser = lReader["FName"].ToString();
                            lUser.LSNameUser = lReader["SName"].ToString();
                            lUser.LPassword = lReader["PasswordHash"].ToString();
                            lUser.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            lUser.LFLastName = lReader["FLastName"].ToString();
                            lUser.LEmail = lReader["Email"].ToString();
                            lUser.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lUser;
                }
                catch (Exception e)
                {
                    Bo_User lUser = new Bo_User();
                    lUser.LException = e.Message;
                    if (e.InnerException != null)
                        lUser.LInnerException = e.InnerException.ToString();
                    lUser.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lUser;
                }
            }
        }



        public string Dao_InsertUser(Bo_User pUser)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdTypeIdentification", pUser.LTypeIdentification.LIdTypeIdentification.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@NoIdentification", pUser.LNoIdentification);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@FName", pUser.LFNameUser);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@SName", pUser.LSNameUser);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@FLastName", pUser.LFLastName);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@SLastName", pUser.LSLastName);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdObject", pUser.LObject.LIdObject.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.DateTime, "@BirthDate", pUser.LBirthDate.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@User", pUser.LUser);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@Password", pUser.LPassword);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pUser.LStatus.LIdStatus);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdRole", pUser.LRole.LIdRole.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranInsertUser", "spr_CreateUser");
        }
    }
}
