using System.Collections.Generic;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoStatus
    {
        List<BoStatus> Dao_getListStatusByIdObject(int pIdObject);
    }
}
