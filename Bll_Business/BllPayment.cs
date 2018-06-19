using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;
using IDaoBusiness.Business;
using System.Collections.Generic;

namespace Bll_Business
{
    public class BllPayment : IPayment
    {
        public IDaoPayment LiDaoPayment { get; set; }

        public BllPayment()
        {
            this.LiDaoPayment = new DaoPayment();
        }

        public List<BoPayment> bll_GetPaymentByOrder(int pIdOrder)
        {
            return this.LiDaoPayment.Dao_getListPaymentByOrder(pIdOrder);
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

        public string bll_DeletePayment(int pIdPayment)
        {
            var lPayment = new BoPayment
            {
                LIdPayment = pIdPayment
            };
            return this.LiDaoPayment.Dao_DeletePayment(lPayment);
        }

        public BoPayment bll_GetPayment(int pIdPayment)
        {
            return this.LiDaoPayment.Dao_GetPayment(pIdPayment);
        }
    }
}
