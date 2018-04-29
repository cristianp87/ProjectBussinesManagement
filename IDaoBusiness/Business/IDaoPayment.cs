using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDaoBusiness.Business
{
    public interface IDaoPayment
    {
        string Dao_InsertPayment(BoPayment pPayment);
    }
}
