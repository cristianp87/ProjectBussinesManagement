using BO_BusinessManagement;
using IBusiness.Common;
using System.Collections.Generic;

namespace IBusiness.Management
{
    public interface IPayment : IFacade
    {
        string bll_InsertPayment(int pIdOrder, decimal pValuePayment, int pIdObject, string pIdStatus);

        List<BoPayment> bll_GetPaymentByOrder(int pIdOrder);

        string bll_DeletePayment(int pIdPayment);

        BoPayment bll_GetPayment(int pIdPayment);
    }
}
