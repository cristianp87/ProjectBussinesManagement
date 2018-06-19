using System.Collections.Generic;
using BO_BusinessManagement;

namespace Project_BusinessManagement.Models.Mappers
{
    public static class MapperInvoiceItem
    {
        public static List<MInvoiceItem> MListInvoiceItem(this List<BoInvoiceItem> pBoListInvoiceItem)
        {
            var lMListInvoiceItem = new List<MInvoiceItem>();
            if (pBoListInvoiceItem != null)
            {
                pBoListInvoiceItem.ForEach(x => {
                    var lMInvoiceItem = new MInvoiceItem
                    {
                        LProduct = new MProduct
                        {
                            LIdProduct = x.LProduct.LIdProduct,
                            LCdProduct = x.LProduct.LCdProduct,
                            LNameProduct = x.LProduct.LNameProduct,
                            LValue = x.LProduct.LValue
                        },
                        LIdInvoice = x.LIdInvoice,
                        LIdInvoiceItem = x.LIdInvoiceItem,
                        LCreationDate = x.LCreationDate,
                        LQuantity = x.LQuantity,
                        LValueProd = x.LValueProd
                    };
                    lMListInvoiceItem.Add(lMInvoiceItem);
                });
                return lMListInvoiceItem;
            }
            var lItem = new MInvoiceItem { LMessageException = "no tiene ningun item" };
            lMListInvoiceItem.Add(lItem);
            return lMListInvoiceItem;

        }
    }
}