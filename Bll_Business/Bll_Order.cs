using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using Dao_BussinessManagement;

namespace Bll_Business
{
    public class Bll_Order
    {
        public static string bll_InsertOrder(int pIdInventory, int pIdCustomer, int pIdObject, string pIdStatus, List<Bo_OrderItem> pListOrderItem, int pIdObjectOI,string pIdStatusOI)
        {
            string resul = "";
            Bo_Order lOrder = new Bo_Order();
            lOrder.LObject = new Bo_Object();
            lOrder.LStatus = new Bo_Status();
            lOrder.LCustomer = new Bo_Customer();
            lOrder.LInventory = new Bo_Inventory();
            lOrder.LCreationDate = new DateTime();
            lOrder.LCustomer.LIdCustomer = pIdCustomer;
            lOrder.LInventory.LIdInventory = pIdInventory;
            lOrder.LObject.LIdObject = pIdObject;
            lOrder.LStatus.LIdStatus = pIdStatus;
            Dao_Order lDaoOrder = new Dao_Order();
            int lIdOrder = 0;
            string lstrIdOrder = lDaoOrder.Dao_InsertOrder(lOrder);
            if (int.TryParse(lstrIdOrder, out lIdOrder))
            {
                resul = Bll_OrderItem.bll_InsertListOrderItem(lIdOrder,pIdInventory, pListOrderItem);              
            }
            else
            {
                resul = "No se pudo ingresar la orden.";
            }
            return resul;
        }
    }
}
