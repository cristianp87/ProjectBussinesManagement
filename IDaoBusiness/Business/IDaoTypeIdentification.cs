using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoTypeIdentification
    {
        Bo_Customer Dao_getTypeIdentification(int pIdTypeIdentification);

        List<Bo_TypeIdentification> Dao_getListAllTypeIdentification();

    }
}
