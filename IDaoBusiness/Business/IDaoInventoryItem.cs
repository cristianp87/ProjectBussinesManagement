using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoInventoryItem
    {
        List<Bo_InventoryItem> Dao_getListInventoryItemByIdInventory(int pIdInventory);

        Bo_InventoryItem Dao_getInventoryItemById(int pIdInventoryItem);

        string Dao_InsertInventoryItem(Bo_InventoryItem pInventoryItem);

        string Dao_UpdateInventoryItem(Bo_InventoryItem pInventoryItem);

        string Dao_DeleteInventoryItem(Bo_InventoryItem pInventoryItem);

        string Dao_SubstractInventoryItem(Bo_InventoryItem pInventoryItem);
    }
}
