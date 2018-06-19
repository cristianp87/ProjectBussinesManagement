using System.Collections.Generic;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoRole
    {
        List<BoRole> Dao_getRolesByUser(int pUserId);
    }
}
