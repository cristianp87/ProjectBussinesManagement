using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;
using IDaoBusiness.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll_Business
{
    public class BllPayment : IPayment
    {
        public IDaoPayment LiDaoPayment { get; set; }

        public BllPayment()
        {
            this.LiDaoPayment = new DaoPayment();
        }

        public string bll_InsertPayment(int pIdOrder, decimal pValuePayment , int pIdObject, string pIdStatus)
        {
            var lPayment = new BoPayment
            {
                LObject = new BoObject { LIdObject = pIdObject },
                LStatus = new BoStatus { LIdStatus = pIdStatus },
                LOrder = new BoOrder { LIdOrder = pIdOrder },
                LValuePayment = pValuePayment
            };
            return this.LiDaoPayment.Dao_InsertPayment(lPayment);
        }
    }
}
