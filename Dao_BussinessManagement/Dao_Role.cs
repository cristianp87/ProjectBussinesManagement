using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Dao_BussinessManagement
{
    public class Dao_Role
    {
        public List<Bo_Role> Dao_getRolesByUser(int pUserId)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetRolesByUser";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("IdUser", pUserId));

                    var lReader = lCommand.ExecuteReader();
                    List<Bo_Role> lRoles = new List<Bo_Role>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_Role lRole = new Bo_Role();
                            lRole.LIdRole = Convert.ToInt32(lReader["IdRole"].ToString());
                            lRole.LNameRole = lReader["NameRole"].ToString();
                            lRole.LFlActive = Convert.ToBoolean(lReader["flActive"].ToString());
                            lRoles.Add(lRole);
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lRoles;
                }
                catch (Exception e)
                {
                    List<Bo_Role> lRoles = new List<Bo_Role>();
                    Bo_Role lRole = new Bo_Role();
                    lRole.LException = e.Message;
                    if (e.InnerException != null)
                        lRole.LInnerException = e.InnerException.ToString();
                    lRole.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    lRoles.Add(lRole);
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lRoles;
                }
            }
        }
    }
}
