using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using System.Data.SqlClient;
using System.Data;

namespace Dao_BussinessManagement
{
    public class Dao_Order
    {
        private List<SqlParameter> lListParam = new List<SqlParameter>();

        public List<Bo_Order> Dao_getListOrderByCustomer(int pIdCustomer)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {

                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetListOrderByCustomer";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("IdCustomer", pIdCustomer));
                    var lReader = lCommand.ExecuteReader();
                    List<Bo_Order> lListOrder = new List<Bo_Order>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_Order lOrder = new Bo_Order();
                            lOrder.LStatus = new Bo_Status();
                            lOrder.LObject = new Bo_Object();
                            lOrder.LInventory = new Bo_Inventory();
                            lOrder.LCustomer = new Bo_Customer();
                            lOrder.LIdOrder = Convert.ToInt32(lReader["IdOrder"].ToString());
                            lOrder.LInventory.LNameInventory = lReader["NameInventory"].ToString();
                            lOrder.LCustomer.LNameCustomer = lReader["NameCustomer"].ToString();
                            lOrder.LCustomer.LLastNameCustomer = lReader["LastNameCustomer"].ToString();
                            lOrder.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            lOrder.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            lOrder.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            lListOrder.Add(lOrder);
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lListOrder;
                }
                catch (Exception e)
                {
                    List<Bo_Order> lListOrder = new List<Bo_Order>();
                    Bo_Order lOrder = new Bo_Order();
                    lOrder.LException = e.Message;
                    if (e.InnerException != null)
                        lOrder.LInnerException = e.InnerException.ToString();
                    lOrder.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    lListOrder.Add(lOrder);
                    return lListOrder;
                }

            }
        }
        public string Dao_InsertOrder(Bo_Order pOrder)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdCustomer", pOrder.LCustomer.LIdCustomer.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdInventory", pOrder.LInventory.LIdInventory.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pOrder.LStatus.LIdStatus.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdObject", pOrder.LObject.LIdObject.ToString());
            return Dao_UtilsLib.Dao_executeSqlScalarWithProcedement(lListParam, "LTranInsertOrder", "spr_CreateOrder");
        }
    }
}
