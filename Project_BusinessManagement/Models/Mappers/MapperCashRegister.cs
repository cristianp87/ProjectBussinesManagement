using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_BusinessManagement.Models.Mappers
{
    public static class MapperCashRegister
    {
        public static List<MCashRegister> MListCashhRegister(this List<BoCashRegister> pListCashRegister)
        {
            var lMListCashRegister = new List<MCashRegister>();
            pListCashRegister.ForEach(x => {
                var lMCashRegister = new MCashRegister
                {
                    LDescription = x.LDescription,
                    LIdCash = x.LIdCash,
                    LIdCashRegister = x.LIdCashRegister,
                    LIsInput = x.LIsInput,
                    LValue = x.LValue,
                    LCreationDate = x.LCreationDate,
                    LModificationDate = x.LModificationDate
                };
                lMListCashRegister.Add(lMCashRegister);
            });
            return lMListCashRegister;
        }
    }
}