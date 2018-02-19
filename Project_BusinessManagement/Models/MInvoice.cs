using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Project_BusinessManagement.Models
{
    public class MInvoice
    {
        [DisplayName("Id Factura")]
        public int LIdInvoice { get; set; }

        [DisplayName("Codigo De Factura")]
        public string LCdInvoice { get; set; }

        [DisplayName("Fecha De Creación")]
        public DateTime LCreationDate { get; set; }

        public MObject LObject { get; set; }

        public MStatus LStatus { get; set; }

        public MCustomer LCustomer { get; set; }

        public List<MInvoiceItem> LListMInvoiceItem { get; set; } = new List<MInvoiceItem>();

        public static List<MInvoice> MListInvoice(List<Bo_Invoice> pBoListInvoice)
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

        public static MInvoice TrasferToMInvoice(Bo_Invoice oBInvoice)
        {
            var oMInvoice = new MInvoice
            {
                LIdInvoice = oBInvoice.LIdInvoice,
                LCdInvoice = oBInvoice.LCdInvoice,
                LCreationDate = oBInvoice.LCreationDate,
                LListMInvoiceItem = MInvoiceItem.MListInvoiceItem(oBInvoice.LListInvoiceItem)
            };
            return oMInvoice;
        }
    }
}