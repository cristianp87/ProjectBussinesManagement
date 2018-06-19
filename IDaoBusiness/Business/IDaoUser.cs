using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoUser
    {
        BoUser Dao_getUserByUser(string pUser);

        BoUser Dao_getUserById(int pIdUser);

        string Dao_InsertUser(BoUser pUser);
    }
}
