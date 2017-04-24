using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using Dao_BussinessManagement;

namespace Bll_Business
{
    public static class Bll_Product
    {
        public static Bo_Product bll_GetProductById(int pIdProduct)
        {
            Dao_Product oDaoProduct = new Dao_Product();
            return oDaoProduct.Dao_getProductById(pIdProduct);
        }

        public static List<Bo_Product> bll_GetAllProduct()
        {
            Dao_Product oDaoProduct = new Dao_Product();
            return oDaoProduct.Dao_getProductListAll();
        }

        public static string bll_InsertProduct(string pNameProduct, decimal pPrice, decimal pPriceSupplier, int pIdUnit, int pIdSupplier, int pIdObject, string pIdStatus)
        {
            Bo_Product oProduct = new Bo_Product();
            oProduct.LObject = new Bo_Object();
            oProduct.LStatus = new Bo_Status();
            oProduct.LSupplier = new Bo_Supplier();
            oProduct.LUnit = new Bo_Unit();
            oProduct.LNameProduct = pNameProduct;
            oProduct.LValue = pPrice;
            oProduct.LValueSupplier = pPriceSupplier;
            oProduct.LUnit.LIdUnit = pIdUnit;
            oProduct.LSupplier.LIdSupplier = pIdSupplier;
            oProduct.LObject.LIdObject = pIdObject;
            oProduct.LStatus.LIdStatus = pIdStatus;
            Dao_Product oDaoProduct = new Dao_Product();
            return oDaoProduct.Dao_InsertProduct(oProduct);
        }

        public static string bll_UpdateProduct(int pIdProduct, string pNameProduct, decimal pPrice, decimal pPriceSupplier, int pIdUnit, int pIdSupplier, int pIdObject, string pIdStatus)
        {
            Bo_Product oProduct = new Bo_Product();
            oProduct.LObject = new Bo_Object();
            oProduct.LStatus = new Bo_Status();
            oProduct.LSupplier = new Bo_Supplier();
            oProduct.LUnit = new Bo_Unit();
            oProduct.LIdProduct = pIdProduct;
            oProduct.LNameProduct = pNameProduct;
            oProduct.LValue = pPrice;
            oProduct.LValueSupplier = pPriceSupplier;
            oProduct.LUnit.LIdUnit = pIdUnit;
            oProduct.LSupplier.LIdSupplier = pIdSupplier;
            oProduct.LObject.LIdObject = pIdObject;
            oProduct.LStatus.LIdStatus = pIdStatus;
            Dao_Product oDaoProduct = new Dao_Product();
            return oDaoProduct.Dao_InsertProduct(oProduct);
        }

        public static string bll_DeleteProduct(int pIdProduct)
        {
            Bo_Product oProduct = new Bo_Product();
            oProduct.LIdProduct = pIdProduct;
            Dao_Product oDaoProduct = new Dao_Product();
            return oDaoProduct.Dao_DeleteProduct(oProduct);
        }
    }
}
