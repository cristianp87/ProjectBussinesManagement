using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;
using IBusiness.Management;

namespace Bll_Business
{
    public class BllInventory : IInventory
    {
        public List<Bo_Inventory> bll_GetAllInventory()
        {
            var oDao = new Dao_Inventory();
            return oDao.Dao_getAllInventory();
        }

        public Bo_Inventory bll_GetInventoryById(int pIdInventory)
        {
            var oDao = new Dao_Inventory();
            return oDao.Dao_getInventoryById(pIdInventory);
        }

        public string bll_InsertInventory(string pNameInventory, int pIdObject, string pIdStatus)
        {
            var oInventory = new Bo_Inventory
            {
                LNameInventory = pNameInventory,
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus}
            };
            var oDao = new Dao_Inventory();
            return oDao.Dao_InsertInventory(oInventory);
        }

        public string bll_UpdateInventory(int pIdInventory, string pNameInventory, int pIdObject, string pIdStatus)
        {
            var oInventory = new Bo_Inventory
            {
                LIdInventory = pIdInventory,
                LNameInventory = pNameInventory,
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus}
            };
            var oDao = new Dao_Inventory();
            return oDao.Dao_UpdateInventory(oInventory);
        }

        public string bll_DeleteInventory(int pIdInventory)
        {
            var oInventory = new Bo_Inventory {LIdInventory = pIdInventory};
            var oDao = new Dao_Inventory();
            return oDao.Dao_DeleteInventory(oInventory);
        }
    }
}
