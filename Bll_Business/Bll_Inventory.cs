using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using Dao_BussinessManagement;

namespace Bll_Business
{
    public static class Bll_Inventory
    {
        public static List<Bo_Inventory> bll_GetAllInventory()
        {
            Dao_Inventory oDao = new Dao_Inventory();
            return oDao.Dao_getAllInventory();
        }

        public static Bo_Inventory bll_GetInventoryById(int pIdInventory)
        {
            Dao_Inventory oDao = new Dao_Inventory();
            return oDao.Dao_getInventoryById(pIdInventory);
        }

        public static string bll_InsertInventory(string pNameInventory, int pIdObject, string pIdStatus)
        {
            Bo_Inventory oInventory = new Bo_Inventory();
            oInventory.LNameInventory = pNameInventory;
            oInventory.LObject = new Bo_Object();
            oInventory.LStatus = new Bo_Status();
            oInventory.LObject.LIdObject = pIdObject;
            oInventory.LStatus.LIdStatus = pIdStatus;
            Dao_Inventory oDao = new Dao_Inventory();
            return oDao.Dao_InsertInventory(oInventory);
        }

        public static string bll_UpdateInventory(int pIdInventory, string pNameInventory, int pIdObject, string pIdStatus)
        {
            Bo_Inventory oInventory = new Bo_Inventory();
            oInventory.LIdInventory = pIdInventory;
            oInventory.LNameInventory = pNameInventory;
            oInventory.LObject = new Bo_Object();
            oInventory.LStatus = new Bo_Status();
            oInventory.LObject.LIdObject = pIdObject;
            oInventory.LStatus.LIdStatus = pIdStatus;
            Dao_Inventory oDao = new Dao_Inventory();
            return oDao.Dao_UpdateInventory(oInventory);
        }

        public static string bll_DeleteInventory(int pIdInventory)
        {
            Bo_Inventory oInventory = new Bo_Inventory();
            oInventory.LIdInventory = pIdInventory;
            Dao_Inventory oDao = new Dao_Inventory();
            return oDao.Dao_DeleteInventory(oInventory);
        }
    }
}
