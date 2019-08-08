using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BO_BusinessManagement.Enums;
using IDaoBusiness.Business;
using static Dao_BussinessManagement.DaoUtilsLib;

namespace Dao_BussinessManagement
{
    public class DaoRole : IDaoRole
    {
        public List<BoRole> Dao_getRolesByUser(int pUserId)
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = Dao_SqlConnection(lConex))
            {
                var lRoles = new List<BoRole>();
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
                            var lRole = new BoRole
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
                    var lRole = new BoRole {LException = e.Message, LMessageDao = BoErrors.MsgErrorGetSql};
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
