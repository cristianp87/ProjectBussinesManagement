using BO_BusinessManagement;
using Dao_BussinessManagement;
using System;
using System.Collections.Generic;
using BO_BusinessManagement.Enums;
using IBusiness.Management;
using IDaoBusiness.Business;

namespace Bll_Business
{
    public class BllOrder:IOrder
    {
        public IOrderItem LOrderItem { get; }

        public IDaoOrder LiDaoOrder { get; set; }

        public BllOrder()
        {
            this.LOrderItem = new BllOrderItem();
            this.LiDaoOrder = new DaoOrder();
        }
        public string bll_InsertOrder(int pIdInventory, int pIdCustomer, int pIdObject, string pIdStatus, List<BoOrderItem> pListOrderItem, bool pIsInventory, int pIdObjectOi,string pIdStatusOi)
        {
            string lResul;
            var lOrder = new BoOrder
            {
                LObject = new BoObject {LIdObject = pIdObject},
                LStatus = new BoStatus {LIdStatus = pIdStatus},
                LCustomer = new BoCustomer {LIdCustomer = pIdCustomer},
                LInventory = new BoInventory {LIdInventory = pIdInventory},
                LCreationDate = new DateTime()
            };
            int lIdOrder;
            var lstrIdOrder = this.LiDaoOrder.Dao_InsertOrder(lOrder);
            if (int.TryParse(lstrIdOrder, out lIdOrder))
            {
                lResul = this.LOrderItem.bll_InsertListOrderItem(lIdOrder,pIdInventory, pListOrderItem, pIsInventory);
                if (string.IsNullOrEmpty(lResul))
                {
                    lResul = lIdOrder.ToString();
                }
            }
            else
            {
                lResul = BoErrors.MsgRollbackOrder;
            }
            return lResul;
        }

        public List<BoOrder> bll_GetListOrderByCustomer(int pIdCustomer)
        {
            return this.LiDaoOrder.Dao_getListOrderByCustomer(pIdCustomer);
        }
    }
}
