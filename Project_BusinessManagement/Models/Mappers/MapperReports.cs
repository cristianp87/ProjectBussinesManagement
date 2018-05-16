using System.Collections.Generic;
using BO_BusinessManagement;
using Project_BusinessManagement.Models.Reports;

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
            return lListReport;
        }
    }
}