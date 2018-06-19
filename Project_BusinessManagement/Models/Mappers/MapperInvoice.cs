using System.Collections.Generic;
using BO_BusinessManagement;

namespace Project_BusinessManagement.Models.Mappers
{
    public static class MapperInvoice
    {
        public static List<MInvoice> MListInvoice(this List<BoInvoice> pBoListInvoice)
        {
            var lMListInvoice = new List<MInvoice>();
            pBoListInvoice.ForEach(x => {
                var lMInvoice = new MInvoice
                {
                    LIdInvoice = x.LIdInvoice,
                    LCdInvoice = x.LCdInvoice,
                    LCreationDate = x.LCreationDate
                };
                var lMCustomer = new MCustomer
                {
                    LNameCustomer = x.LCustomer.LNameCustomer,
                    LIdCustomer = x.LCustomer.LIdCustomer
                };
                lMInvoice.LCustomer = lMCustomer;
                lMListInvoice.Add(lMInvoice);
            });
            return lMListInvoice;
        }

        public static MInvoice TrasferToMInvoice(this BoInvoice lBoInvoice)
        {
            var oMInvoice = new MInvoice
            {
                LIdInvoice = lBoInvoice.LIdInvoice,
                LCdInvoice = lBoInvoice.LCdInvoice,
                LCreationDate = lBoInvoice.LCreationDate,
                LCustomer = new MCustomer
                {
                   LIdCustomer = lBoInvoice.LCustomer.LIdCustomer,
                   LNameCustomer = lBoInvoice.LCustomer.LNameCustomer,
                   LLastNameCustomer = lBoInvoice.LCustomer.LLastNameCustomer
                },
                LListMInvoiceItem = lBoInvoice.LListInvoiceItem.MListInvoiceItem()
            };
            return oMInvoice;
        }
    }
}