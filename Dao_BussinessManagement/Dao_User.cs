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

        public Bo_User Dao_getUserByUser(string pUser, string pPassword)
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
                    lCommand.Parameters.Add(new SqlParameter("Password", pPassword));

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
                            lUser.LStatus.LIdStatus = lReader["IdStatus"].ToString();
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
    }
}
