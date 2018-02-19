using BO_BusinessManagement;
using IBusiness.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Management
{
    public interface ITaxe : IFacade
    {
        List<Bo_Taxe> bll_GetListallTaxesXProduct(int pIdProduct);

        List<Bo_Taxe> bll_GetListTaxes();

        List<Bo_Taxe> bll_GetListTaxesWithOutProduct(int pIdProduct);

        string bll_AssociateTaxeXProduct(int pIdProduct, int pIdTaxe);

        Bo_Taxe bll_GetTaxe(int pIdTaxe);

        string bll_DeleteTaxeXProduct(int pIdProduct, int pIdTaxe);

    }
}
