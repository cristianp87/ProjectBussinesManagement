using System.Collections.Generic;
using BO_BusinessManagement;

namespace Project_BusinessManagement.Models.Mappers
{
    public static class MapperOrder
    {
        public static List<MOrder> MListOrder(this List<BoOrder> pListOrder)
        {
            var lListOrder = new List<MOrder>();
            pListOrder.ForEach(x => {
                var lMOrder = new MOrder
                {
                    LInventory = new MInventory { LNameInventory = x.LInventory.LNameInventory },
                    LCustomer = new MCustomer
                    {
                        LNameCustomer = x.LCustomer.LNameCustomer,
                        LLastNameCustomer = x.LCustomer.LLastNameCustomer
                    },
                    LIdOrder = x.LIdOrder,
                    LCreationDate = x.LCreationDate
                };
                lListOrder.Add(lMOrder);
            });
            return lListOrder;
        }
    }
}