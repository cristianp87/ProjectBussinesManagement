using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;
using IBusiness.Management;
using IDaoBusiness.Business;

namespace Bll_Business
{
    public class BllInventory : IInventory
    {
        public IDaoInventory LiDaoInventory { get; set; }

        public BllInventory()
        {
            this.LiDaoInventory = new DaoInventory();
        }

        public List<BoInventory> bll_GetAllInventory()
        {
            return this.LiDaoInventory.Dao_getAllInventory();
        }

        public BoInventory bll_GetInventoryById(int pIdInventory)
        {
            return this.LiDaoInventory.Dao_getInventoryById(pIdInventory);
        }

        public string bll_InsertInventory(string pNameInventory, int pIdObject, string pIdStatus)
        {
            var lInventory = new BoInventory
            {
                LNameInventory = pNameInventory,
                LObject = new BoObject {LIdObject = pIdObject},
                LStatus = new BoStatus {LIdStatus = pIdStatus}
            };
            return this.LiDaoInventory.Dao_InsertInventory(lInventory);
        }

        public string bll_UpdateInventory(int pIdInventory, string pNameInventory, int pIdObject, string pIdStatus)
        {
            var lInventory = new BoInventory
            {
                LIdInventory = pIdInventory,
                LNameInventory = pNameInventory,
                LObject = new BoObject {LIdObject = pIdObject},
                LStatus = new BoStatus {LIdStatus = pIdStatus}
            };
            return this.LiDaoInventory.Dao_UpdateInventory(lInventory);
        }

        public string bll_DeleteInventory(int pIdInventory)
        {
            var lInventory = new BoInventory {LIdInventory = pIdInventory};
            return this.LiDaoInventory.Dao_DeleteInventory(lInventory);
        }
    }
}
