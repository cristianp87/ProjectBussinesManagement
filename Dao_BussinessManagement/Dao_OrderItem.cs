using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao_BussinessManagement
{
    
    public class Dao_OrderItem
    {
        private List<SqlParameter> lListParam = new List<SqlParameter>();
        public string Dao_InsertOrderItem(Bo_OrderItem pOrderItem)
        {
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@CodProduct", pOrderItem.LProduct.LCdProduct.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdOrder", pOrderItem.LOrder.LIdOrder.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@ValueProduct", pOrderItem.LValueProduct.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@ValueSupplier", pOrderItem.LValueTaxes.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@ValueTaxesProduct", pOrderItem.LValueSupplier.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@ValueDescProduct", pOrderItem.LValueDesc.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Decimal, "@ValueTotalProduct", pOrderItem.LValueTotal.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.VarChar, "@IdStatus", pOrderItem.LStatus.LIdStatus.ToString());
            Dao_UtilsLib.dao_Addparameters(lListParam, SqlDbType.Int, "@IdObject", pOrderItem.LObject.LIdObject.ToString());
            return Dao_UtilsLib.Dao_executeSqlTransactionWithProcedement(lListParam, "LTranInsertOrder", "spr_CreateOrderItem");
        }
    }
}
