﻿using BO_BusinessManagement;
using System.Collections.Generic;

namespace IDaoBusiness.Business
{
    public interface IDaoCashRegister
    {
        List<BoCashRegister> Dao_getListLastCashRegister();

        List<BoCashRegister> Dao_getListCashInput();

        List<BoCashRegister> Dao_getListCashOutputs();

        string Dao_InsertCashRegisterInput(BoCashRegister pCashRegister);

        string Dao_InsertCashRegisterOutPut(BoCashRegister pCashRegister);

        int Dao_getFirstIdCashRegister();

        string Dao_DeleteCashRegisterInput(BoCashRegister pCashRegister);

        string Dao_DeleteCashRegisterOutPut(BoCashRegister pCashRegister);

        BoCashRegister Dao_getCashInput(int pIdCash);

        BoCashRegister Dao_getCashOutPut(int pIdCash);
    }
}
