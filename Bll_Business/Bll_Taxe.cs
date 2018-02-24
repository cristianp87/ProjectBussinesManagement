using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;
using System.Collections.Generic;
using IDaoBusiness.Business;

namespace Bll_Business
{
    public class BllTaxe : ITaxe
    {
        public IDaoTaxe LiDaoTaxe { get; set; }

        public BllTaxe()
        {
            this.LiDaoTaxe = new DaoTaxe();
        }
        public List<Bo_Taxe>  bll_GetListallTaxesXProduct(int pIdProduct)
        {
            return this.LiDaoTaxe.Dao_getLisAllTaxesXProduct(pIdProduct);
        }

        public List<Bo_Taxe> bll_GetListTaxes()
        {
            return this.LiDaoTaxe.Dao_getLisTaxes();
        }

        public List<Bo_Taxe> bll_GetListTaxesWithOutProduct(int pIdProduct)
        {
            return this.LiDaoTaxe.Dao_getLisAllTaxesWithOutProduct(pIdProduct);
        }

        public string bll_AssociateTaxeXProduct(int pIdProduct, int pIdTaxe)
        {
            return this.LiDaoTaxe.Dao_InsertTaxeXProduct(pIdProduct, pIdTaxe);
        }

        public Bo_Taxe bll_GetTaxe(int pIdTaxe)
        {
            return this.LiDaoTaxe.Dao_getTaxeById(pIdTaxe);
        }

        public string bll_DeleteTaxeXProduct(int pIdProduct, int pIdTaxe)
        {
            return this.LiDaoTaxe.Dao_DeleteTaxeXProduct(pIdProduct, pIdTaxe);
        }
    }
}
