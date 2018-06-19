using System.Collections.Generic;
using BO_BusinessManagement;

namespace Project_BusinessManagement.Models.Mappers
{
    public static class MapperOrderItem
    {
        public static List<MOrderItem> MListOrderItem(this List<BoOrderItem> pListOrderItem)
        {
            var lListOrderItem = new List<MOrderItem>();
            pListOrderItem.ForEach(x => {
                var lMOrderItem = new MOrderItem
                {
                    LProduct = new MProduct
                    {
                        LNameProduct = x.LProduct.LNameProduct,
                        LIdProduct = x.LProduct.LIdProduct
                    },
                    LOrder = new MOrder { LIdOrder = x.LOrder.LIdOrder },
                    LIdOrderItem = x.LIdOrderItem,
                    LQty = x.LQty,
                    LValueProduct = x.LValueProduct,
                    LValueSupplier = x.LValueSupplier,
                    LValueTaxes = x.LValueTaxes,
                    LValueDesc = x.LValueDesc,
                    LCreationDate = x.LCreationDate,
                    LValueTotal = x.LValueTotal
                };
                lListOrderItem.Add(lMOrderItem);
            });
            return lListOrderItem;
        }
    }
}