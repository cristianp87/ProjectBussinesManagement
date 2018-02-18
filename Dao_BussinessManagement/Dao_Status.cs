using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Dao_BussinessManagement
{
    public class Dao_Status
    {
        public List<Bo_Status> Dao_getListStatusByIdObject(int pIdObject)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {

                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetListStatusByObject";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("IdObject", pIdObject));
                    var lReader = lCommand.ExecuteReader();
                    List<Bo_Status> oListStatus = new List<Bo_Status>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_Status oStatus= new Bo_Status();
                            oStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oStatus.LDsEstado = lReader["DsEstado"].ToString();
                            oStatus.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oStatus.LFlActive = Convert.ToBoolean(lReader["flActive"].ToString());
                            oListStatus.Add(oStatus);
                        }


                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListStatus;
                }
                catch (Exception e)
                {
                    List<Bo_Status> oListStatus = new List<Bo_Status>();
                    Bo_Status oStatus = new Bo_Status();
                    oStatus.LException = e.Message;
                    if (e.InnerException != null)
                        oStatus.LInnerException = e.InnerException.ToString();
                    oStatus.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    oListStatus.Add(oStatus);
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListStatus;
                }

            }
        }
    }
}
