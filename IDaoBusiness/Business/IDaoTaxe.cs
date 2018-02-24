using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoTaxe
    {
        List<Bo_Taxe> Dao_getLisAllTaxesXProduct(int idProduct);

        List<Bo_Taxe> Dao_getLisTaxes();

        List<Bo_Taxe> Dao_getLisAllTaxesWithOutProduct(int pIdProduct);

        Bo_Taxe Dao_getTaxeById(int pIdTaxe);

        string Dao_InsertTaxeXProduct(int pIdProduct, int pIdTaxe);

        string Dao_DeleteTaxeXProduct(int pIdProduct, int pIdTaxe);
    }
}
