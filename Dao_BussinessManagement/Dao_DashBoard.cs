using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BO_BusinessManagement.Enums;
using IDaoBusiness.Business;

namespace Dao_BussinessManagement
{
    
    public class DaoDashBoard : IDaoDashBoard
    {
        public List<BoDashBoard> Dao_getProductSellToday()
        {
            using (SqlConnection lConex = DaoUtilsLib.Dao_SqlConnection(lConex))
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
                    var lListDashBoard = new List<BoDashBoard>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lDashBoard = new BoDashBoard
                            {
                                Xstring = lReader["x"].ToString(),
                                Yint = Convert.ToInt32(lReader["y"].ToString())
                            };
                            lListDashBoard.Add(lDashBoard);
                        }


                    }
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return lListDashBoard;
                }
                catch (Exception e)
                {
                    var lListDashBoard = new List<BoDashBoard>();
                    var lDashBoard = new BoDashBoard {LException = e.Message};
                    if (e.InnerException != null)
                        lDashBoard.LInnerException = e.InnerException.ToString();
                    lDashBoard.LMessageDao = BoErrors.MsgErrorGetSql;
                    lListDashBoard.Add(lDashBoard);
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return lListDashBoard;
                }

            }
        }
    }
}
