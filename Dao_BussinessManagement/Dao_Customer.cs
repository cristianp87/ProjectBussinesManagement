using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using BO_BusinessManagement.Enums;
using IDaoBusiness.Business;

namespace Dao_BussinessManagement
{
    public class DaoCustomer : IDaoCustomer
    {
        private List<SqlParameter> LListParams { get; set; }

        public BoCustomer Dao_getCustomerById(int pIdCustomer)
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = DaoUtilsLib.Dao_SqlConnection(lConex))
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
                    var lCustomer = new BoCustomer();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            lCustomer.LStatus = new BoStatus();
                            lCustomer.LObject = new BoObject();
                            lCustomer.LTypeIdentification = new BoTypeIdentification();
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
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return lCustomer;
                }
                catch (Exception e)
                {
                    var oCustomer = new BoCustomer {LException = e.Message};
                    if (e.InnerException != null)
                        oCustomer.LInnerException = e.InnerException.ToString();
                    oCustomer.LMessageDao = BoErrors.MsgErrorGetSql;
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return oCustomer;
                }

            }
        }

        public BoCustomer Dao_getCustomerByDocument(string pNoIdentification, int pIdTypeIdentification)
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = DaoUtilsLib.Dao_SqlConnection(lConex))
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
                    var oCustomer = new BoCustomer();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            oCustomer.LStatus = new BoStatus();
                            oCustomer.LObject = new BoObject();
                            oCustomer.LTypeIdentification = new BoTypeIdentification();
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
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return oCustomer;
                }
                catch (Exception e)
                {
                    var oCustomer = new BoCustomer {LException = e.Message};
                    if (e.InnerException != null)
                        oCustomer.LInnerException = e.InnerException.ToString();
                    oCustomer.LMessageDao = BoErrors.MsgErrorGetSql; 
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return oCustomer;
                }

            }
        }

        public List<BoCustomer> Dao_getListAllCustomer()
        {
            SqlConnection lConex = new SqlConnection();
            using (lConex = DaoUtilsLib.Dao_SqlConnection(lConex))
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
                    var oListCustomer = new List<BoCustomer>();                    
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            var oCustomer = new BoCustomer
                            {
                                LStatus = new BoStatus
                                {
                                    LIdStatus = lReader["IdStatus"].ToString(),
                                    LDsEstado = lReader["DsEstado"].ToString()
                                },
                                LObject = new BoObject
                                {
                                    LIdObject = Convert.ToInt32(lReader["IdObject"].ToString()),
                                    LNameObject = lReader["NameObject"].ToString()
                                },
                                LTypeIdentification =
                                    new BoTypeIdentification
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
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListCustomer;
                }
                catch (Exception e)
                {
                    var oListCustomer = new List<BoCustomer>();
                    var oCustomer = new BoCustomer {LException = e.Message};
                    if (e.InnerException != null)
                        oCustomer.LInnerException = e.InnerException.ToString();
                    oCustomer.LMessageDao = BoErrors.MsgErrorGetSql;
                    oListCustomer.Add(oCustomer);
                    DaoUtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListCustomer;
                }

            }
        }

        public string Dao_InsertCustomer(BoCustomer pCustomer)
        {
            this.LListParams = new List<SqlParameter>();
            DaoUtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@NameCustomer", pCustomer.LNameCustomer);
            DaoUtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@LastNameCustomer", pCustomer.LLastNameCustomer);
            DaoUtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@IdTypeIdentification", pCustomer.LTypeIdentification.LIdTypeIdentification.ToString());
            DaoUtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@NoIdentification", pCustomer.LNoIdentification);
            DaoUtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@IdStatus", pCustomer.LStatus.LIdStatus);
            DaoUtilsLib.dao_Addparameters(this.LListParams, SqlDbType.Int, "@IdObject", pCustomer.LObject.LIdObject.ToString());
            return DaoUtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParams, "LTranInsertCustomer", "spr_CreateCustomer");
        }

        public string Dao_UpdateCustomer(BoCustomer pCustomer)
        {
            this.LListParams = new List<SqlParameter>();
            DaoUtilsLib.dao_Addparameters(this.LListParams, SqlDbType.Int, "@IdCustomer", pCustomer.LIdCustomer.ToString());
            DaoUtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@NameCustomer", pCustomer.LNameCustomer);
            DaoUtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@LastNameCustomer", pCustomer.LLastNameCustomer);
            DaoUtilsLib.dao_Addparameters(this.LListParams, SqlDbType.Int, "@IdTypeIdentification", pCustomer.LTypeIdentification.LIdTypeIdentification.ToString());
            DaoUtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@NoIdentification", pCustomer.LNoIdentification);
            DaoUtilsLib.dao_Addparameters(this.LListParams, SqlDbType.VarChar, "@IdStatus", pCustomer.LStatus.LIdStatus);
            return DaoUtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParams, "LTranUpdateCustomer", "spr_UpdateCustomer");
        }

        public string Dao_DeleteCustomer(BoCustomer pCustomer)
        {
            this.LListParams = new List<SqlParameter>();
            DaoUtilsLib.dao_Addparameters(this.LListParams, SqlDbType.Int, "@IdCustomer", pCustomer.LIdCustomer.ToString());
            return DaoUtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParams, "LTranDeleteCustomer", "spr_DeleteCustomer");
        }
    }
}
