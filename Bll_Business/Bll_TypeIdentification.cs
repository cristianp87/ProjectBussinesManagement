using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao_BussinessManagement;
using BO_BusinessManagement;

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
