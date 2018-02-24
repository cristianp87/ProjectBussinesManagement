using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoInventory
    {
        List<Bo_Inventory> Dao_getAllInventory();

        Bo_Inventory Dao_getInventoryById(int pIdInventory);

        string Dao_InsertInventory(Bo_Inventory pInventory);

        string Dao_UpdateInventory(Bo_Inventory pInventory);

        string Dao_DeleteInventory(Bo_Inventory pInventory);
    }
}
