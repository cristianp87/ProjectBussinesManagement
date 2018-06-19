using System.Collections.Generic;
using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management
{
    public interface IInventory : IFacade
    {
        List<BoInventory> bll_GetAllInventory();

        BoInventory bll_GetInventoryById(int pIdInventory);

        string bll_InsertInventory(string pNameInventory, int pIdObject, string pIdStatus);

        string bll_UpdateInventory(int pIdInventory, string pNameInventory, int pIdObject, string pIdStatus);

        string bll_DeleteInventory(int pIdInventory);

    }
}
