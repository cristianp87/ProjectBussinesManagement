using BO_BusinessManagement;
using Dao_BussinessManagement;
using System;
using System.Collections.Generic;
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
        public string bll_InsertOrder(int pIdInventory, int pIdCustomer, int pIdObject, string pIdStatus, List<Bo_OrderItem> pListOrderItem, bool pIsInventory, int pIdObjectOI,string pIdStatusOI)
        {
            var lResul = "";
            var lOrder = new Bo_Order
            {
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus},
                LCustomer = new Bo_Customer {LIdCustomer = pIdCustomer},
                LInventory = new Bo_Inventory {LIdInventory = pIdInventory},
                LCreationDate = new DateTime()
            };
            var lIdOrder = 0;
            var lstrIdOrder = this.LiDaoOrder.Dao_InsertOrder(lOrder);
            if (int.TryParse(lstrIdOrder, out lIdOrder))
            {
                lResul = this.LOrderItem.bll_InsertListOrderItem(lIdOrder,pIdInventory, pListOrderItem, pIsInventory);
                if (string.IsNullOrEmpty(lResul))
                {
                    lResul = "" + lIdOrder;
                }
            }
            else
            {
                lResul = "No se pudo ingresar la orden.";
            }
            return lResul;
        }

        public List<Bo_Order> bll_GetListOrderByCustomer(int pIdCustomer)
        {
            return this.LiDaoOrder.Dao_getListOrderByCustomer(pIdCustomer);
        }
    }
}
