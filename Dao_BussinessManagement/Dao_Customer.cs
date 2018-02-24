using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using IDaoBusiness.Business;

namespace Dao_BussinessManagement
{
    public class DaoCustomer : IDaoCustomer
    {
        private List<SqlParameter> LListParams { get; set; }

        public Bo_Customer Dao_getCustomerById(int pIdCustomer)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {

                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetCustomer",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("IdCustomer", pIdCustomer));

                    var lReader = lCommand.ExecuteReader();
                    var lCustomer = new Bo_Customer();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            lCustomer.LStatus = new Bo_Status();
                            lCustomer.LObject = new Bo_Object();
                            lCustomer.LTypeIdentification = new Bo_TypeIdentification();
                            lCustomer.LIdCustomer = Convert.ToInt32(lReader["IdCustomer"].ToString());
                            lCustomer.LTypeIdentification.LIdTypeIdentification = Convert.ToInt32(lReader["IdTypeIdentification"].ToString());
                            lCustomer.LNoIdentification = lReader["NoIdentification"].ToString();
                            lCustomer.LNameCustomer = lReader["NameCustomer"].ToString();
                            lCustomer.LLastNameCustomer = lReader["LastNameCustomer"].ToString();
                            lCustomer.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            lCustomer.LModificationDate = Convert.ToDateTime(lReader["ModificationDate"].ToString());
                            lCustomer.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            lCustomer.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());

                        }


                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return lCustomer;
                }
                catch (Exception e)
                {
                    var oCustomer = new Bo_Customer {LException = e.Message};
                    if (e.InnerException != null)
                        oCustomer.LInnerException = e.InnerException.ToString();
                    oCustomer.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oCustomer;
                }

            }
        }

        public Bo_Customer Dao_getCustomerByDocument(string pNoIdentification, int pIdTypeIdentification)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetCustomerByIdentification",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    lCommand.Parameters.Add(new SqlParameter("@NoIdentification", pNoIdentification));
                    lCommand.Parameters.Add(new SqlParameter("@IdTypeIdentification", pIdTypeIdentification));
                    var lReader = lCommand.ExecuteReader();
                    var oCustomer = new Bo_Customer();
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
                    var oCustomer = new Bo_Customer {LException = e.Message};
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
                    var lCommand = new SqlCommand
                    {
                        CommandText = "spr_GetListAllCustomer",
                        CommandTimeout = 30,
                        CommandType = CommandType.StoredProcedure,
                        Connection = lConex
                    };
                    var lReader = lCommand.ExecuteReader();
                    var oListCustomer = new List<Bo_Customer>();                    
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var oCustomer = new Bo_Customer
                            {
                                LStatus = new Bo_Status
                                {
                                    LIdStatus = lReader["IdStatus"].ToString(),
                                    LDsEstado = lReader["DsEstado"].ToString()
                                },
                                LObject = new Bo_Object
                                {
                                    LIdObject = Convert.ToInt32(lReader["IdObject"].ToString()),
                                    LNameObject = lReader["NameObject"].ToString()
                                },
                                LTypeIdentification =
                                    new Bo_TypeIdentification
                                    {
                                        LIdTypeIdentification =
                                            Convert.ToInt32(lReader["IdTypeIdentification"].ToString()),
                                        LTypeIdentification = lReader["TypeIdentification"].ToString()
                                    },
                                LIdCustomer = Convert.ToInt32(lReader["IdCustomer"].ToString()),
                                LNoIdentification = lReader["NoIdentification"].ToString(),
                                LNameCustomer = lReader["NameCustomer"].ToString(),
                                LLastNameCustomer = lReader["LastNameCustomer"].ToString(),
                                LCreationDate =
                                    Convert.ToDateTime(lReader["CreationDate"].ToString() == ""
                                        ? new DateTime().ToString(CultureInfo.InvariantCulture)
                                        : lReader["CreationDate"].ToString()),
                                LModificationDate =
                                    Convert.ToDateTime(lReader["ModificationDate"].ToString() == ""
                                        ? new DateTime().ToString(CultureInfo.InvariantCulture)
                                        : lReader["ModificationDate"].ToString())
                            };
                            oListCustomer.Add(oCustomer);
                        }


                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListCustomer;
                }
                catch (Exception e)
                {
                    var oListCustomer = new List<Bo_Customer>();
                    var oCustomer = new Bo_Customer {LException = e.Message};
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
            this.LListParams = new List<SqlParameter>();
            Dao_UtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@NameCustomer", pCustomer.LNameCustomer);
            Dao_UtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@LastNameCustomer", pCustomer.LLastNameCustomer);
            Dao_UtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@IdTypeIdentification", pCustomer.LTypeIdentification.LIdTypeIdentification.ToString());
            Dao_UtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@NoIdentification", pCustomer.LNoIdentification);
            Dao_UtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@IdStatus", pCustomer.LStatus.LIdStatus);
            Dao_UtilsLib.dao_Addparameters(this.LListParams, SqlDbType.Int, "@IdObject", pCustomer.LObject.LIdObject.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParams, "LTranInsertCustomer", "spr_CreateCustomer");
        }

        public string Dao_UpdateCustomer(Bo_Customer pCustomer)
        {
            this.LListParams = new List<SqlParameter>();
            Dao_UtilsLib.dao_Addparameters(this.LListParams, SqlDbType.Int, "@IdCustomer", pCustomer.LIdCustomer.ToString());
            Dao_UtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@NameCustomer", pCustomer.LNameCustomer);
            Dao_UtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@LastNameCustomer", pCustomer.LLastNameCustomer);
            Dao_UtilsLib.dao_Addparameters(this.LListParams, SqlDbType.Int, "@IdTypeIdentification", pCustomer.LTypeIdentification.LIdTypeIdentification.ToString());
            Dao_UtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@NoIdentification", pCustomer.LNoIdentification);
            Dao_UtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@IdStatus", pCustomer.LStatus.LIdStatus.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParams, "LTranUpdateCustomer", "spr_UpdateCustomer");
        }

        public string Dao_DeleteCustomer(Bo_Customer pCustomer)
        {
            this.LListParams = new List<SqlParameter>();
            Dao_UtilsLib.dao_Addparameters(this.LListParams, SqlDbType.Int, "@IdCustomer", pCustomer.LIdCustomer.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParams, "LTranDeleteCustomer", "spr_DeleteCustomer");
        }
    }
}
