using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using IDaoBusiness.Business;
using static Dao_BussinessManagement.Dao_UtilsLib;

namespace Dao_BussinessManagement
{
    public class DaoTypeIdentification : IDaoTypeIdentification
    {

        public Bo_Customer Dao_getTypeIdentification(int pIdTypeIdentification)
        {           
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lCustomer = new Bo_Customer();
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
                            lCustomer.LTypeIdentification = new Bo_TypeIdentification();
                            lCustomer.LIdCustomer = Convert.ToInt32(lReader["IdCustomer"].ToString());
                            lCustomer.LTypeIdentification.LIdTypeIdentification = Convert.ToInt32(lReader["IdTypeIdentification"].ToString());
                            lCustomer.LNoIdentification = lReader["NoIdentification"].ToString();
                            lCustomer.LNameCustomer = lReader["NameCustomer"].ToString();
                            lCustomer.LLastNameCustomer = lReader["LastNameCustomer"].ToString();
                            lCustomer.LStatus = new Bo_Status {LIdStatus = lReader["IdStatus"].ToString()};
                            lCustomer.LObject = new Bo_Object
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
                    lCustomer = new Bo_Customer
                    {
                        LException = e.Message,
                        LMessageDao = "Hubo un problema en la consulta, contacte al administrador."
                    };
                    if (e.InnerException != null)
                        lCustomer.LInnerException = e.InnerException.ToString();                    
                    Dao_CloseSqlconnection(lConex);
                    return lCustomer;
                }

            }
        }

        public List<Bo_TypeIdentification> Dao_getListAllTypeIdentification()
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lListTypeIdentification = new List<Bo_TypeIdentification>();
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
                            var lTypeIdentification = new Bo_TypeIdentification
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
                    lListTypeIdentification = new List<Bo_TypeIdentification>();
                    var lTypeIdentification = new Bo_TypeIdentification
                    {
                        LException = e.Message,
                        LMessageDao = "Hubo un problema en la consulta, contacte al administrador."
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
