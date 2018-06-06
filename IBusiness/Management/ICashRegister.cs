using BO_BusinessManagement;
using IBusiness.Common;
using System.Collections.Generic;

namespace IBusiness.Management
{
    public interface ICashRegister : IFacade
    {
        List<BoCashRegister> bll_GetListLastCashRegister();

        List<BoCashRegister> bll_GetListCashInput();

        List<BoCashRegister> bll_GetListCashOutputs();

        string bll_CreateCashOutput(int pIdCashRegister, decimal pValue, string pDescription);

        string bll_CreateCashInput(int pIdCashRegister, decimal pValue, string pDescription);

        int bll_GetFirstIdCashRegister();
    }
}
