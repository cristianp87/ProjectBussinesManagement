using System.Collections.Generic;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoInventory
    {
        List<BoInventory> Dao_getAllInventory();

        BoInventory Dao_getInventoryById(int pIdInventory);

        string Dao_InsertInventory(BoInventory pInventory);

        string Dao_UpdateInventory(BoInventory pInventory);

        string Dao_DeleteInventory(BoInventory pInventory);
    }
}
