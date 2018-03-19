using BO_BusinessManagement;
using IBusiness.Common;
using System.Collections.Generic;

namespace IBusiness.Management
{
    public interface ITaxe : IFacade
    {
        List<BoTaxe> bll_GetListallTaxesXProduct(int pIdProduct);

        List<BoTaxe> bll_GetListTaxes();

        List<BoTaxe> bll_GetListTaxesWithOutProduct(int pIdProduct);

        string bll_AssociateTaxeXProduct(int pIdProduct, int pIdTaxe);

        BoTaxe bll_GetTaxe(int pIdTaxe);

        string bll_DeleteTaxeXProduct(int pIdProduct, int pIdTaxe);

    }
}
