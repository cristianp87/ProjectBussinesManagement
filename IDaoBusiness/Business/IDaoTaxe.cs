using System.Collections.Generic;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoTaxe
    {
        List<BoTaxe> Dao_getLisAllTaxesXProduct(int idProduct);

        List<BoTaxe> Dao_getLisTaxes();

        List<BoTaxe> Dao_getLisAllTaxesWithOutProduct(int pIdProduct);

        BoTaxe Dao_getTaxeById(int pIdTaxe);

        string Dao_InsertTaxeXProduct(int pIdProduct, int pIdTaxe);

        string Dao_DeleteTaxeXProduct(int pIdProduct, int pIdTaxe);
    }
}
