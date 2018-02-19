using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;
using System.Collections.Generic;

namespace Bll_Business
{
    public class BllTaxe : ITaxe
    {
        public List<Bo_Taxe>  bll_GetListallTaxesXProduct(int pIdProduct)
        {
            var oDaoTaxe = new Dao_Taxe();
            return oDaoTaxe.Dao_getLisAllTaxesXProduct(pIdProduct);
        }

        public List<Bo_Taxe> bll_GetListTaxes()
        {
            var oDaoTaxe = new Dao_Taxe();
            return oDaoTaxe.Dao_getLisTaxes();
        }

        public List<Bo_Taxe> bll_GetListTaxesWithOutProduct(int pIdProduct)
        {
            var oDaoTaxe = new Dao_Taxe();
            return oDaoTaxe.Dao_getLisAllTaxesWithOutProduct(pIdProduct);
        }

        public string bll_AssociateTaxeXProduct(int pIdProduct, int pIdTaxe)
        {
            var lDaoTaxe = new Dao_Taxe();
            return lDaoTaxe.Dao_InsertTaxeXProduct(pIdProduct, pIdTaxe);
        }

        public Bo_Taxe bll_GetTaxe(int pIdTaxe)
        {
            var lDaoTaxe = new Dao_Taxe();
            return lDaoTaxe.Dao_getTaxeById(pIdTaxe);
        }

        public string bll_DeleteTaxeXProduct(int pIdProduct, int pIdTaxe)
        {
            Dao_Taxe lDaoTaxe = new Dao_Taxe();
            return lDaoTaxe.Dao_DeleteTaxeXProduct(pIdProduct, pIdTaxe);
        }
    }
}
