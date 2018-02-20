using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using IDaoBusiness.Business;

namespace Dao_BussinessManagement
{
    
    public class DaoDashBoard : IDaoDashBoard
    {
        public List<Bo_DashBoard> Dao_getProductSellToday()
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {

                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_dsbProductSellToday",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    var lReader = lCommand.ExecuteReader();
                    var lListDashBoard = new List<Bo_DashBoard>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lDashBoard = new Bo_DashBoard
                            {
                                Xstring = lReader["x"].ToString(),
                                Yint = Convert.ToInt32(lReader["y"].ToString())
                            };
                            lListDashBoard.Add(lDashBoard);
                        }


                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lListDashBoard;
                }
                catch (Exception e)
                {
                    var lListDashBoard = new List<Bo_DashBoard>();
                    var lDashBoard = new Bo_DashBoard {LException = e.Message};
                    if (e.InnerException != null)
                        lDashBoard.LInnerException = e.InnerException.ToString();
                    lDashBoard.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    lListDashBoard.Add(lDashBoard);
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lListDashBoard;
                }

            }
        }
    }
}
