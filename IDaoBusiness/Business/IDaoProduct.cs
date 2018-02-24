using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoProduct
    {
        Bo_Product Dao_getProductById(int pIdProduct);

        Bo_Product Dao_getProductByCode(string pCdProduct);

        List<Bo_Product> Dao_getProductListAll();

        string Dao_InsertProduct(Bo_Product pProduct);

        string Dao_UpdateProduct(Bo_Product pProduct);

        string Dao_DeleteProduct(Bo_Product pProduct);
    }
}
