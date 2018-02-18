using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;

namespace Bll_Business
{
    public class Bll_TypeIdentification
    {
        public static List<Bo_TypeIdentification>  bll_getListTypeIdentification()
        {
            Dao_TypeIdentification oTypeIdentification = new Dao_TypeIdentification();
            return oTypeIdentification.Dao_getListAllTypeIdentification();
        }
    }
}
