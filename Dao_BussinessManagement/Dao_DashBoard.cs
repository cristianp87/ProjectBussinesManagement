using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Dao_BussinessManagement
{
    public class Dao_DashBoard
    {

        List<SqlParameter> lListParam = new List<SqlParameter>();

        public List<Bo_DashBoard> Dao_getProductSellToday()
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {

                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_dsbProductSellToday";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    var lReader = lCommand.ExecuteReader();
                    List<Bo_DashBoard> lListDashBoard = new List<Bo_DashBoard>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_DashBoard lDashBoard = new Bo_DashBoard();

                            lDashBoard.Xstring = lReader["x"].ToString();
                            lDashBoard.Yint = Convert.ToInt32(lReader["y"].ToString());

                            lListDashBoard.Add(lDashBoard);
                        }


                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lListDashBoard;
                }
                catch (Exception e)
                {
                    List<Bo_DashBoard> lListDashBoard = new List<Bo_DashBoard>();
                    Bo_DashBoard lDashBoard = new Bo_DashBoard();
                    lDashBoard.LException = e.Message;
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
