using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using IDaoBusiness.Business;
using static Dao_BussinessManagement.Dao_UtilsLib;

namespace Dao_BussinessManagement
{
    public class DaoStatus : IDaoStatus
    {
        public List<Bo_Status> Dao_getListStatusByIdObject(int pIdObject)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lListStatus = new List<Bo_Status>();
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
                            var lStatus= new Bo_Status();
                            lStatus.LIdStatus = lReader["IdStatus"].ToString();
                            lStatus.LDsEstado = lReader["DsEstado"].ToString();
                            lStatus.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            lStatus.LFlActive = Convert.ToBoolean(lReader["flActive"].ToString());
                            lListStatus.Add(lStatus);
                        }


                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListStatus;
                }
                catch (Exception e)
                {
                    lListStatus = new List<Bo_Status>();
                    var lStatus = new Bo_Status
                    {
                        LException = e.Message,
                        LMessageDao = "Hubo un problema en la consulta, contacte al administrador."
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
