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
    public class DaoTypeIdentification : IDaoTypeIdentification
    {

        public BoCustomer Dao_getTypeIdentification(int pIdTypeIdentification)
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = Dao_SqlConnection(lConex))
            {
                var lCustomer = new BoCustomer();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListAllTypeIdentification",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("IdCustomer", pIdTypeIdentification));

                    var lReader = lCommand.ExecuteReader();
                    
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {                           
                            lCustomer.LTypeIdentification = new BoTypeIdentification();
                            lCustomer.LIdCustomer = Convert.ToInt32(lReader["IdCustomer"].ToString());
                            lCustomer.LTypeIdentification.LIdTypeIdentification = Convert.ToInt32(lReader["IdTypeIdentification"].ToString());
                            lCustomer.LNoIdentification = lReader["NoIdentification"].ToString();
                            lCustomer.LNameCustomer = lReader["NameCustomer"].ToString();
                            lCustomer.LLastNameCustomer = lReader["LastNameCustomer"].ToString();
                            lCustomer.LStatus = new BoStatus {LIdStatus = lReader["IdStatus"].ToString()};
                            lCustomer.LObject = new BoObject
                            {
                                LIdObject = Convert.ToInt32(lReader["IdObject"].ToString())
                            };

                        }


                    }
                    Dao_CloseSqlconnection(lConex);
                    return lCustomer;
                }
                catch (Exception e)
                {
                    lCustomer = new BoCustomer
                    {
                        LException = e.Message,
                        LMessageDao = BoErrors.MsgErrorGetSql
                };
                    if (e.InnerException != null)
                        lCustomer.LInnerException = e.InnerException.ToString();                    
                    Dao_CloseSqlconnection(lConex);
                    return lCustomer;
                }

            }
        }

        public List<BoTypeIdentification> Dao_getListAllTypeIdentification()
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = Dao_SqlConnection(lConex))
            {
                var lListTypeIdentification = new List<BoTypeIdentification>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListAllTypeIdentification",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    var lReader = lCommand.ExecuteReader();
                    
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lTypeIdentification = new BoTypeIdentification
                            {
                                LIdTypeIdentification = Convert.ToInt32(lReader["IdTypeIdentification"].ToString()),
                                LTypeIdentification = lReader["TypeIdentification"].ToString(),
                                LActive = Convert.ToBoolean(lReader["flActive"].ToString())
                            };
                            lListTypeIdentification.Add(lTypeIdentification);
                        }


                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListTypeIdentification;
                }
                catch (Exception e)
                {
                    lListTypeIdentification = new List<BoTypeIdentification>();
                    var lTypeIdentification = new BoTypeIdentification
                    {
                        LException = e.Message,
                        LMessageDao = BoErrors.MsgErrorGetSql
                };
                    if (e.InnerException != null)
                        lTypeIdentification.LInnerException = e.InnerException.ToString();                    
                    lListTypeIdentification.Add(lTypeIdentification);
                    Dao_CloseSqlconnection(lConex);
                    return lListTypeIdentification;
                }

            }
        }
    }
}
