using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using BO_BusinessManagement;

namespace Dao_BussinessManagement
{
    public class Dao_Customer
    {
        List<SqlParameter> lListParam = new List<SqlParameter>();

        public Bo_Customer Dao_getCustomerById(int pIdCustomer)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {

                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetCustomer";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add(new SqlParameter("IdCustomer", pIdCustomer));

                    var lReader = lCommand.ExecuteReader();
                    Bo_Customer oCustomer = new Bo_Customer();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            oCustomer.LStatus = new Bo_Status();
                            oCustomer.LObject = new Bo_Object();
                            oCustomer.LTypeIdentification = new Bo_TypeIdentification();
                            oCustomer.LIdCustomer = Convert.ToInt32(lReader["IdCustomer"].ToString());
                            oCustomer.LTypeIdentification.LIdTypeIdentification = Convert.ToInt32(lReader["IdTypeIdentification"].ToString());
                            oCustomer.LNoIdentification = lReader["NoIdentification"].ToString();
                            oCustomer.LNameCustomer = lReader["NameCustomer"].ToString();
                            oCustomer.LLastNameCustomer = lReader["LastNameCustomer"].ToString();
                            oCustomer.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oCustomer.LModificationDate = Convert.ToDateTime(lReader["ModificationDate"].ToString());
                            oCustomer.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oCustomer.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());

                        }


                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oCustomer;
                }
                catch (Exception e)
                {
                    Bo_Customer oCustomer = new Bo_Customer();
                    oCustomer.LException = e.Message;
                    if (e.InnerException != null)
                        oCustomer.LInnerException = e.InnerException.ToString();
                    oCustomer.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oCustomer;
                }

            }
        }

        public List<Bo_Customer> Dao_getListAllCustomer()
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {

                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetListAllCustomer";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    var lReader = lCommand.ExecuteReader();
                    List<Bo_Customer> oListCustomer = new List<Bo_Customer>();                    
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_Customer oCustomer = new Bo_Customer();
                            oCustomer.LStatus = new Bo_Status();
                            oCustomer.LObject = new Bo_Object();
                            oCustomer.LTypeIdentification = new Bo_TypeIdentification();
                            oCustomer.LIdCustomer = Convert.ToInt32(lReader["IdCustomer"].ToString());
                            oCustomer.LTypeIdentification.LIdTypeIdentification = Convert.ToInt32(lReader["IdTypeIdentification"].ToString());
                            oCustomer.LTypeIdentification.LTypeIdentification = lReader["TypeIdentification"].ToString();
                            oCustomer.LNoIdentification = lReader["NoIdentification"].ToString();
                            oCustomer.LNameCustomer = lReader["NameCustomer"].ToString();
                            oCustomer.LLastNameCustomer = lReader["LastNameCustomer"].ToString();
                            oCustomer.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString() == "" ? new DateTime().ToString(): lReader["CreationDate"].ToString());
                            oCustomer.LModificationDate = Convert.ToDateTime(lReader["ModificationDate"].ToString() == "" ? new DateTime().ToString() : lReader["ModificationDate"].ToString());
                            oCustomer.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oCustomer.LStatus.LDsEstado = lReader["DsEstado"].ToString();
                            oCustomer.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            oCustomer.LObject.LNameObject = lReader["NameObject"].ToString();
                            oListCustomer.Add(oCustomer);
                        }


                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListCustomer;
                }
                catch (Exception e)
                {
                    List<Bo_Customer> oListCustomer = new List<Bo_Customer>();
                    Bo_Customer oCustomer = new Bo_Customer();
                    oCustomer.LException = e.Message;
                    if (e.InnerException != null)
                        oCustomer.LInnerException = e.InnerException.ToString();
                    oCustomer.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    oListCustomer.Add(oCustomer);
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListCustomer;
                }

            }
        }

        public string Dao_InsertCustomer(Bo_Customer pCustomer)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@NameCustomer", pCustomer.LNameCustomer);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@LastNameCustomer", pCustomer.LNameCustomer);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdTypeIdentification", pCustomer.LTypeIdentification.LIdTypeIdentification.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@NoIdentification", pCustomer.LNoIdentification);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pCustomer.LStatus.LIdStatus.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdObject", pCustomer.LObject.LIdObject.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranInsertCustomer", "spr_CreateCustomer");
        }

        public string Dao_UpdateInventory(Bo_Customer pCustomer)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdCustomer", pCustomer.LIdCustomer.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@NameCustomer", pCustomer.LNameCustomer);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@LastNameCustomer", pCustomer.LLastNameCustomer);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdTypeIdentification", pCustomer.LTypeIdentification.LIdTypeIdentification.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@NoIdentification", pCustomer.LNoIdentification);
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pCustomer.LStatus.LIdStatus.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranUpdateCustomer", "spr_UpdateCustomer");
        }

        public string Dao_DeleteInventory(Bo_Customer pCustomer)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdCustomer", pCustomer.LIdCustomer.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranDeleteCustomer", "spr_DeleteCustomer");
        }
    }
}
