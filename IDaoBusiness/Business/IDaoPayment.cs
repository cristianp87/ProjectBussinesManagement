using BO_BusinessManagement;
using System.Collections.Generic;

namespace IDaoBusiness.Business
{
    public interface IDaoPayment
    {
        string Dao_InsertPayment(BoPayment pPayment);

        List<BoPayment> Dao_getListPaymentByOrder(int lIdOrder);

        string Dao_DeletePayment(BoPayment pPayment);

        BoPayment Dao_GetPayment(int pIdPayment);
    }
}
