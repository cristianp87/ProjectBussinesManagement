using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;
using IBusiness.Management;

namespace Bll_Business
{
    public class BllProduct : IProduct
    {
        public Bo_Product bll_GetProductByCode(string pCdProduct)
        {
            var oDaoProduct = new Dao_Product();
            return oDaoProduct.Dao_getProductByCode(pCdProduct);
        }

        public Bo_Product bll_GetProductById(int pIdProduct)
        {
            var oDaoProduct = new Dao_Product();
            return oDaoProduct.Dao_getProductById(pIdProduct);
        }

        public List<Bo_Product> bll_GetAllProduct()
        {
            var oDaoProduct = new Dao_Product();
            return oDaoProduct.Dao_getProductListAll();
        }

        public string bll_InsertProduct(string pNameProduct, string pCdProduct, decimal pPrice, decimal pPriceSupplier, int pIdUnit, int pIdSupplier, int pIdObject, string pIdStatus)
        {
            var oProduct = new Bo_Product
            {
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus},
                LSupplier = new Bo_Supplier {LIdSupplier = pIdSupplier},
                LUnit = new Bo_Unit {LIdUnit = pIdUnit},
                LNameProduct = pNameProduct,
                LCdProduct = pCdProduct,
                LValue = pPrice,
                LValueSupplier = pPriceSupplier
            };
            var oDaoProduct = new Dao_Product();
            return oDaoProduct.Dao_InsertProduct(oProduct);
        }

        public string bll_UpdateProduct(int pIdProduct, string pNameProduct, string pCdProduct, decimal pPrice, decimal pPriceSupplier, int pIdUnit, int pIdSupplier, int pIdObject, string pIdStatus)
        {
            var oProduct = new Bo_Product
            {
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus},
                LSupplier = new Bo_Supplier {LIdSupplier = pIdSupplier},
                LUnit = new Bo_Unit {LIdUnit = pIdUnit},
                LIdProduct = pIdProduct,
                LNameProduct = pNameProduct,
                LCdProduct = pCdProduct,
                LValue = pPrice,
                LValueSupplier = pPriceSupplier
            };
            var oDaoProduct = new Dao_Product();
            return oDaoProduct.Dao_UpdateProduct(oProduct);
        }

        public string bll_DeleteProduct(int pIdProduct)
        {
            var oProduct = new Bo_Product {LIdProduct = pIdProduct};
            var oDaoProduct = new Dao_Product();
            return oDaoProduct.Dao_DeleteProduct(oProduct);
        }
    }
}
