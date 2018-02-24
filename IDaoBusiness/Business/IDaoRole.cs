using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoRole
    {
        List<Bo_Role> Dao_getRolesByUser(int pUserId);
    }
}
