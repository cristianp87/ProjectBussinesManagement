using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using Dao_BussinessManagement;
namespace Bll_Business
{
    public class Bll_Status
    {
        public static List<Bo_Status>  Bll_getListStatusByIdObject(int pIdObject)
        {
            Dao_Status oDaoStatus = new Dao_Status();
            return oDaoStatus.Dao_getListStatusByIdObject(pIdObject);
        }
    }
}
