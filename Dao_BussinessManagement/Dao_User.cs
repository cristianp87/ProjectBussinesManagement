using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using IDaoBusiness.Business;
using static Dao_BussinessManagement.Dao_UtilsLib;


namespace Dao_BussinessManagement
{
    public class DaoUser : IDaoUser
    {
        private List<SqlParameter> LListParam { get; set; }

        public Bo_User Dao_getUserByUser(string pUser)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lUser = new Bo_User();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetUserByUser",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("User", pUser));

                    var lReader = lCommand.ExecuteReader();
                    
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {                            
                            lUser.LIdUser = Convert.ToInt32(lReader["IdUser"].ToString());
                            lUser.LUser = lReader["Usuario"].ToString();
                            lUser.LFNameUser = lReader["FName"].ToString();
                            lUser.LSNameUser = lReader["SName"].ToString();
                            lUser.LPassword = lReader["PasswordHash"].ToString();
                            lUser.LStatus = new Bo_Status {LIdStatus = lReader["IdStatus"].ToString()};
                            lUser.LFLastName = lReader["FLastName"].ToString();
                            lUser.LEmail = lReader["Email"].ToString();
                            lUser.LObject = new Bo_Object {LIdObject = Convert.ToInt32(lReader["IdObject"].ToString())};
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lUser;
                }
                catch (Exception e)
                {
                    lUser = new Bo_User
                    {
                        LException = e.Message,
                        LMessageDao = "Hubo un problema en la consulta, contacte al administrador."
                    };
                    if (e.InnerException != null)
                        lUser.LInnerException = e.InnerException.ToString();                   
                    Dao_CloseSqlconnection(lConex);
                    return lUser;
                }
            }
        }

        public Bo_User Dao_getUserById(int pIdUser)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lUser = new Bo_User();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetUserByIdUser",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("IdUser", pIdUser));

                    var lReader = lCommand.ExecuteReader();
                    
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            
                            
                            lUser.LIdUser = Convert.ToInt32(lReader["IdUser"].ToString());
                            lUser.LUser = lReader["Usuario"].ToString();
                            lUser.LFNameUser = lReader["FName"].ToString();
                            lUser.LSNameUser = lReader["SName"].ToString();
                            lUser.LPassword = lReader["PasswordHash"].ToString();
                            lUser.LStatus = new Bo_Status {LIdStatus = lReader["IdStatus"].ToString()};
                            lUser.LFLastName = lReader["FLastName"].ToString();
                            lUser.LEmail = lReader["Email"].ToString();
                            lUser.LObject = new Bo_Object {LIdObject = Convert.ToInt32(lReader["IdObject"].ToString())};
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lUser;
                }
                catch (Exception e)
                {
                    lUser = new Bo_User
                    {
                        LException = e.Message,
                        LMessageDao = "Hubo un problema en la consulta, contacte al administrador."
                    };
                    if (e.InnerException != null)
                        lUser.LInnerException = e.InnerException.ToString();                   
                    Dao_CloseSqlconnection(lConex);
                    return lUser;
                }
            }
        }



        public string Dao_InsertUser(Bo_User pUser)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdTypeIdentification", pUser.LTypeIdentification.LIdTypeIdentification.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@NoIdentification", pUser.LNoIdentification);
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@FName", pUser.LFNameUser);
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@SName", pUser.LSNameUser);
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@FLastName", pUser.LFLastName);
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@SLastName", pUser.LSLastName);
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pUser.LObject.LIdObject.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.DateTime, "@BirthDate", pUser.LBirthDate.ToString(CultureInfo.CurrentCulture));
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@User", pUser.LUser);
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@Password", pUser.LPassword);
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pUser.LStatus.LIdStatus);
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdRole", pUser.LRole.LIdRole.ToString());
            return Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranInsertUser", "spr_CreateUser");
        }
    }
}
