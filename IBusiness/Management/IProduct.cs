using System.Collections.Generic;
using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management
{
    public interface IProduct : IFacade
    {
        BoProduct bll_GetProductByCode(string pCdProduct);

        BoProduct bll_GetProductById(int pIdProduct);

        List<BoProduct> bll_GetAllProduct();

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
