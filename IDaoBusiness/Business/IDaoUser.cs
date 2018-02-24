using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoUser
    {
        Bo_User Dao_getUserByUser(string pUser);

        Bo_User Dao_getUserById(int pIdUser);

        string Dao_InsertUser(Bo_User pUser);
    }
}
