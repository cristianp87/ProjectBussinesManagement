using System.Collections.Generic;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoInventoryItem
    {
        List<BoInventoryItem> Dao_getListInventoryItemByIdInventory(int pIdInventory);

        BoInventoryItem Dao_getInventoryItemById(int pIdInventoryItem);

        string Dao_InsertInventoryItem(BoInventoryItem pInventoryItem);

        string Dao_UpdateInventoryItem(BoInventoryItem pInventoryItem);

        string Dao_DeleteInventoryItem(BoInventoryItem pInventoryItem);

        string Dao_SubstractInventoryItem(BoInventoryItem pInventoryItem);
    }
}
