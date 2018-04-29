using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Management
{
    public interface IPayment
    {
        string bll_InsertPayment(int pIdOrder, decimal pValuePayment, int pIdObject, string pIdStatus);
    }
}
