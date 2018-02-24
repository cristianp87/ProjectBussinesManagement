using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;
using IBusiness.Management;
using IDaoBusiness.Business;

namespace Bll_Business
{
    public class BllProduct : IProduct
    {
        public IDaoProduct LiDaoProduct { get; set; }

        public BllProduct()
        {
            this.LiDaoProduct = new DaoProduct();
        }
        public Bo_Product bll_GetProductByCode(string pCdProduct)
        {
            return this.LiDaoProduct.Dao_getProductByCode(pCdProduct);
        }

        public Bo_Product bll_GetProductById(int pIdProduct)
        {
            return this.LiDaoProduct.Dao_getProductById(pIdProduct);
        }

        public List<Bo_Product> bll_GetAllProduct()
        {
            return this.LiDaoProduct.Dao_getProductListAll();
        }

        public string bll_InsertProduct(string pNameProduct, string pCdProduct, decimal pPrice, decimal pPriceSupplier, int pIdUnit, int pIdSupplier, int pIdObject, string pIdStatus)
        {
            var lProduct = new Bo_Product
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
            return this.LiDaoProduct.Dao_InsertProduct(lProduct);
        }

        public string bll_UpdateProduct(int pIdProduct, string pNameProduct, string pCdProduct, decimal pPrice, decimal pPriceSupplier, int pIdUnit, int pIdSupplier, int pIdObject, string pIdStatus)
        {
            var lProduct = new Bo_Product
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
            return this.LiDaoProduct.Dao_UpdateProduct(lProduct);
        }

        public string bll_DeleteProduct(int pIdProduct)
        {
            var lProduct = new Bo_Product {LIdProduct = pIdProduct};
            return this.LiDaoProduct.Dao_DeleteProduct(lProduct);
        }
    }
}
