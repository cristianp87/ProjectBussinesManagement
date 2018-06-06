using System.Collections.Generic;
using BO_BusinessManagement;
using Project_BusinessManagement.Models.Reports;
using System.Linq;

namespace Project_BusinessManagement.Models.Mappers
{
    public static class MapperReports
    {
        public static MReportSales ToMSales(this BoReportSales pBoSales)
        {
            return new MReportSales()
            {
                LCode = pBoSales.LCode,
                LCreationDate = pBoSales.LCreationDate,
                LId = pBoSales.LId,
                LProduct = new MProduct()
                {
                    LCdProduct = pBoSales.LProduct.LCdProduct,
                    LIdProduct = pBoSales.LProduct.LIdProduct,
                    LNameProduct = pBoSales.LProduct.LNameProduct
                }
            };
        }

        public static List<MReportSales> ToListMSales(this List<BoReportSales> pListBoSales)
        {
            var lListReport = new List<MReportSales>();
            pListBoSales.ForEach(x => {
                var lReport = new MReportSales() {
                    LCode = x.LCode,
                    LCreationDate= x.LCreationDate,
                    LId = x.LId,
                    LProduct = new MProduct() {
                        LCdProduct = x.LProduct.LCdProduct,
                        LNameProduct = x.LProduct.LNameProduct,
                        LIdProduct = x.LProduct.LIdProduct
                    },
                    LValuetotal = x.LValuetotal                  
                };
                lListReport.Add(lReport);
            });
            return lListReport.OrderBy(o => o.LProduct.LNameProduct).ToList();
        }

        public static List<MReportAccountReceivable> ToListMReportAccountReceivable(this List<BoReportAccountReceivable> pListBoAccount)
        {
            var lListReport = new List<MReportAccountReceivable>();
            pListBoAccount.ForEach(x => {
                var lReport = new MReportAccountReceivable
                {
                    LId = x.LId,
                    LCustomer = new MCustomer
                    {
                        LIdCustomer = x.LCustomer.LIdCustomer,
                        LNameCustomer = x.LCustomer.LNameCustomer,
                        LLastNameCustomer = x.LCustomer.LLastNameCustomer
                    },
                    LValueDebt = x.LValueDebt
                };
                lListReport.Add(lReport);
            });
            return lListReport.OrderBy(o => o.LCustomer.LNameCustomer).ToList(); ;
        }

        public static List<MInventoryItem> ToListMInventoryItem(this List<BoInventoryItem> pListBoInventoryItem)
        {
            var lListReport = new List<MInventoryItem>();
            pListBoInventoryItem.ForEach(x => {
                var lReport = new MInventoryItem
                {
                    LProduct = new MProduct()
                    {
                        LCdProduct = x.LProduct.LCdProduct,
                        LNameProduct = x.LProduct.LNameProduct,
                        LIdProduct = x.LProduct.LIdProduct
                    },
                    LInventory = new MInventory()
                    {
                        LIdInventory = x.LInventory.LIdInventory,
                        LNameInventory = x.LInventory.LNameInventory
                    },
                    LQtyNonSellable = x.LQtyNonSellable,
                    LQtySellable = x.LQtySellable
                };
                lListReport.Add(lReport);
            });
            return lListReport.OrderBy(o => o.LProduct.LNameProduct).ToList(); ;
        }
    }
}