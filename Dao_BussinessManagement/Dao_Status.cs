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
    public class DaoStatus : IDaoStatus
    {
        public List<BoStatus> Dao_getListStatusByIdObject(int pIdObject)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lListStatus = new List<BoStatus>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListStatusByObject",
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
                            var lStatus = new BoStatus
                            {
                                LIdStatus = lReader["IdStatus"].ToString(),
                                LDsEstado = lReader["DsEstado"].ToString(),
                                LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString()),
                                LFlActive = Convert.ToBoolean(lReader["flActive"].ToString())
                            };
                            lListStatus.Add(lStatus);
                        }


                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListStatus;
                }
                catch (Exception e)
                {
                    lListStatus = new List<BoStatus>();
                    var lStatus = new BoStatus
                    {
                        LException = e.Message,
                        LMessageDao = BoErrors.MsgErrorGetSql
                    };

                    if (e.InnerException != null)
                        lStatus.LInnerException = e.InnerException.ToString();
                    lListStatus.Add(lStatus);
                    Dao_CloseSqlconnection(lConex);
                    return lListStatus;
                }

            }
        }
    }
}
