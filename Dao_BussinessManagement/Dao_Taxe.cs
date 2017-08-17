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
    public class Dao_Taxe
    {
        public List<Bo_Taxe> Dao_getLisAllTaxesXProduct(int idProduct)
        {
            using (SqlConnection lConex = Dao_UtilsLib.Dao_SqlConnection(lConex))
            {
                try
                {
                    SqlCommand lCommand = new SqlCommand();
                    lCommand.CommandText = "spr_GetListAllTaxesXProduct";
                    lCommand.CommandTimeout = 30;
                    lCommand.CommandType = CommandType.StoredProcedure;
                    lCommand.Connection = lConex;
                    lCommand.Parameters.Add("idProduct", SqlDbType.Int).Value = idProduct;
                    var lReader = lCommand.ExecuteReader();
                    List<Bo_Taxe> oListTaxe = new List<Bo_Taxe>();
                    if (lReader.HasRows)
                    {
                        while (lReader.Read())
                        {
                            Bo_Taxe oTaxe = new Bo_Taxe();
                            oTaxe.LStatus = new Bo_Status();
                            oTaxe.LObject = new Bo_Object();
                            oTaxe.LIdTaxe = Convert.ToInt32(lReader["IdTax"].ToString());
                            oTaxe.LNameTaxe = lReader["NameTax"].ToString();
                            oTaxe.LIsPercent = Convert.ToBoolean(lReader["IsPercent"].ToString());
                            oTaxe.LCreationDate = Convert.ToDateTime(lReader["CreationDate"].ToString());
                            oTaxe.LValueTaxe = Convert.ToDecimal(lReader["ValueTax"].ToString());
                            oTaxe.LStatus.LIdStatus = lReader["IdStatus"].ToString();
                            oTaxe.LStatus.LDsEstado = lReader["DsEstado"].ToString();
                            oTaxe.LObject.LIdObject = Convert.ToInt32(lReader["IdObject"].ToString());
                            oTaxe.LObject.LNameObject = lReader["NameObject"].ToString();
                            oListTaxe.Add(oTaxe);
                        }
                    }
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    return oListTaxe;
                }
                catch (Exception e)
                {
                    List<Bo_Taxe> oListTaxe = new List<Bo_Taxe>();
                    Bo_Taxe oTaxe = new Bo_Taxe();
                    oTaxe.LException = e.Message;
                    if (e.InnerException != null)
                        oTaxe.LInnerException = e.InnerException.ToString();
                    oTaxe.LMessageDao = "Hubo un problema en la consulta, contacte al administrador.";
                    Dao_UtilsLib.Dao_CloseSqlconnection(lConex);
                    oListTaxe.Add(oTaxe);
                    return oListTaxe;
                }
            }
        }
    }
}
