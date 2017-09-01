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
