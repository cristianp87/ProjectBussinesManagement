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
        public BoProduct bll_GetProductByCode(string pCdProduct)
        {
            return this.LiDaoProduct.Dao_getProductByCode(pCdProduct);
        }

        public BoProduct bll_GetProductById(int pIdProduct)
        {
            return this.LiDaoProduct.Dao_getProductById(pIdProduct);
        }

        public List<BoProduct> bll_GetAllProduct()
        {
            return this.LiDaoProduct.Dao_getProductListAll();
        }

        public string bll_InsertProduct(string pNameProduct, string pCdProduct, decimal pPrice, decimal pPriceSupplier, int pIdUnit, int pIdSupplier, int pIdObject, string pIdStatus)
        {
            var lProduct = new BoProduct
            {
                LObject = new BoObject {LIdObject = pIdObject},
                LStatus = new BoStatus {LIdStatus = pIdStatus},
                LSupplier = new BoSupplier {LIdSupplier = pIdSupplier},
                LUnit = new BoUnit {LIdUnit = pIdUnit},
                LNameProduct = pNameProduct,
                LCdProduct = pCdProduct,
                LValue = pPrice,
                LValueSupplier = pPriceSupplier
            };
            return this.LiDaoProduct.Dao_InsertProduct(lProduct);
        }

        public string bll_UpdateProduct(int pIdProduct, string pNameProduct, string pCdProduct, decimal pPrice, decimal pPriceSupplier, int pIdUnit, int pIdSupplier, int pIdObject, string pIdStatus)
        {
            var lProduct = new BoProduct
            {
                LObject = new BoObject {LIdObject = pIdObject},
                LStatus = new BoStatus {LIdStatus = pIdStatus},
                LSupplier = new BoSupplier {LIdSupplier = pIdSupplier},
                LUnit = new BoUnit {LIdUnit = pIdUnit},
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
            var lProduct = new BoProduct {LIdProduct = pIdProduct};
            return this.LiDaoProduct.Dao_DeleteProduct(lProduct);
        }
    }
}
