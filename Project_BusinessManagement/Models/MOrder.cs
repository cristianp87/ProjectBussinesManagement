using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Project_BusinessManagement.Models
{
    public class MOrder
    {
        public int LIdOrder { get; set; }

        [DisplayName("Fecha De Creación")]
        public DateTime LCreationDate { get; set; }

        public MStatus LStatus { get; set; }

        public MObject LObject { get; set; }

        public MInventory LInventory { get; set; }

        public MCustomer LCustomer { get; set; }

        public string LMessageException { get; set; }

        public List<MOrderItem> LListOrderItem { get; set; }

        public static List<MOrder> MListOrder(List<Bo_Order> pListOrder)
        {
            var lListOrder= new List<MOrder>();
            pListOrder.ForEach(x => {
                                        var lMOrder = new MOrder
                                        {
                                            LInventory = new MInventory {LNameInventory = x.LInventory.LNameInventory},
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