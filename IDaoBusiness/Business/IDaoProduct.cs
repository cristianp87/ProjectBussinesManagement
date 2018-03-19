using System.Collections.Generic;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoProduct
    {
        BoProduct Dao_getProductById(int pIdProduct);

        BoProduct Dao_getProductByCode(string pCdProduct);

        List<BoProduct> Dao_getProductListAll();

        string Dao_InsertProduct(BoProduct pProduct);

        string Dao_UpdateProduct(BoProduct pProduct);

        string Dao_DeleteProduct(BoProduct pProduct);
    }
}
