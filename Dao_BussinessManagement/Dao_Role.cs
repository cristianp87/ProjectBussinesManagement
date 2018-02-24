using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using IDaoBusiness.Business;
using static Dao_BussinessManagement.Dao_UtilsLib;

namespace Dao_BussinessManagement
{
    public class DaoRole : IDaoRole
    {
        public List<Bo_Role> Dao_getRolesByUser(int pUserId)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lRoles = new List<Bo_Role>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetRolesByUser",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("IdUser", pUserId));

                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lRole = new Bo_Role
                            {
                                LIdRole = Convert.ToInt32(lReader["IdRole"].ToString()),
                                LNameRole = lReader["NameRole"].ToString(),
                                LFlActive = Convert.ToBoolean(lReader["flActive"].ToString())
                            };
                            lRoles.Add(lRole);
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lRoles;
                }
                catch (Exception e)
                {
                    var lRole = new Bo_Role {LException = e.Message, LMessageDao = "Hubo un problema en la consulta, contacte al administrador." };
                    if (e.InnerException != null)
                        lRole.LInnerException = e.InnerException.ToString();
                    lRoles.Add(lRole);
                    Dao_CloseSqlconnection(lConex);
                    return lRoles;
                }
            }
        }
    }
}
