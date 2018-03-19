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
    public class DaoOrder : IDaoOrder
    {
        private List<SqlParameter> LListParam { get; set; }

        public List<BoOrder> Dao_getListOrderByCustomer(int pIdCustomer)
        {
            using (SqlConnection lConex = Dao_SqlConnection(lConex))
            {
                var lListOrder = new List<BoOrder>();
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListOrderByCustomer",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("IdCustomer", pIdCustomer));
                    var lReader = lCommand.ExecuteReader();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var lOrder = new BoOrder
                            {
                                LStatus = new BoStatus {LIdStatus = lReader["IdStatus"].ToString()},
                                LObject = new BoObject {LIdObject = Convert.ToInt32(lReader["IdObject"].ToString())},
                                LInventory = new BoInventory {LNameInventory = lReader["NameInventory"].ToString()},
                                LCustomer = new BoCustomer
                                {
                                    LNameCustomer = lReader["NameCustomer"].ToString(),
                                    LLastNameCustomer = lReader["LastNameCustomer"].ToString()
                                },
                                LIdOrder = Convert.ToInt32(lReader["IdOrder"].ToString()),
                                LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString())
                            };
                            lListOrder.Add(lOrder);
                        }
                    }
                    Dao_CloseSqlconnection(lConex);
                    return lListOrder;
                }
                catch (Exception e)
                {
                    var lOrder = new BoOrder {LException = e.Message};
                    if (e.InnerException != null)
                        lOrder.LInnerException = e.InnerException.ToString();
                    lOrder.LMessageDao = BoErrors.MsgErrorGetSql;
                    Dao_CloseSqlconnection(lConex);
                    lListOrder.Add(lOrder);
                    return lListOrder;
                }
            }
        }
        public string Dao_InsertOrder(BoOrder pOrder)
        {
            this.LListParam = new List<SqlParameter>();
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdCustomer", pOrder.LCustomer.LIdCustomer.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdInventory", pOrder.LInventory.LIdInventory.ToString());
            dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pOrder.LStatus.LIdStatus);
            dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pOrder.LObject.LIdObject.ToString());
            return Dao_executeSqlScalarWithProcedement(this.LListParam, "LTranInsertOrder", "spr_CreateOrder");
        }
    }
}
