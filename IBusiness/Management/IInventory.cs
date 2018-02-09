using System.Collections.Generic;
using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management
{
    public interface IInventory : IFacade
    {
        List<Bo_Inventory> bll_GetAllInventory();

        Bo_Inventory bll_GetInventoryById(int pIdInventory);

        string bll_InsertInventory(string pNameInventory, int pIdObject, string pIdStatus);

        string bll_UpdateInventory(int pIdInventory, string pNameInventory, int pIdObject, string pIdStatus);

        string bll_DeleteInventory(int pIdInventory);

    }
}
