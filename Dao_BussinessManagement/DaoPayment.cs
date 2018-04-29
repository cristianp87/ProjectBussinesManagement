using BO_BusinessManagement;
using IDaoBusiness.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao_BussinessManagement
{
    public class DaoPayment : IDaoPayment
    {
        private List<SqlParameter> LListParam { get; set; }

        public string Dao_InsertPayment(BoPayment pPayment)
        {
            this.LListParam = new List<SqlParameter>();
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdOrder", pPayment.LOrder.LIdOrder.ToString());
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Decimal, "@ValuePayment", pPayment.LValuePayment.ToString());
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.VarChar, "@IdStatus", pPayment.LStatus.LIdStatus);
            DaoUtilsLib.dao_Addparameters(this.LListParam, SqlDbType.Int, "@IdObject", pPayment.LObject.LIdObject.ToString());
            return DaoUtilsLib.Dao_executeSqlTransactionWithProcedement(this.LListParam, "LTranInsertPayment", "spr_CreatePayment");
        }
    }
}
