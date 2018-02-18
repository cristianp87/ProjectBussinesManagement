using BO_BusinessManagement;
using Dao_BussinessManagement;
using System;
using System.Collections.Generic;
using IBusiness.Management;

namespace Bll_Business
{
    public class BllOrder:IOrder
    {
        private IOrderItem LOrderItem;

        public BllOrder()
        {
            this.LOrderItem = new BllOrderItem();
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
            var lDaoOrder = new Dao_Order();
            var lIdOrder = 0;
            var lstrIdOrder = lDaoOrder.Dao_InsertOrder(lOrder);
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
            var lDaoOrder = new Dao_Order();
            return lDaoOrder.Dao_getListOrderByCustomer(pIdCustomer);
        }
    }
}
