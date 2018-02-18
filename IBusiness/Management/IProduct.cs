using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management
{
    public interface IProduct : IFacade
    {
        Bo_Product bll_GetProductByCode(string pCdProduct);

        Bo_Product bll_GetProductById(int pIdProduct);

        List<Bo_Product> bll_GetAllProduct();

        string bll_InsertProduct(string pNameProduct,
            string pCdProduct,
            decimal pPrice,
            decimal pPriceSupplier,
            int pIdUnit,
            int pIdSupplier,
            int pIdObject,
            string pIdStatus);

        string bll_UpdateProduct(int pIdProduct,
            string pNameProduct,
            string pCdProduct,
            decimal pPrice,
            decimal pPriceSupplier,
            int pIdUnit,
            int pIdSupplier,
            int pIdObject,
            string pIdStatus);

        string bll_DeleteProduct(int pIdProduct);
    }
}
