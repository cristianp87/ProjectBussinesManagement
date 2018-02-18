using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;
using System.Collections.Generic;
namespace Bll_Business
{
    public class BllStatus : IStatus
    {
        public List<Bo_Status>  Bll_getListStatusByIdObject(int pIdObject)
        {
            Dao_Status oDaoStatus = new Dao_Status();
            return oDaoStatus.Dao_getListStatusByIdObject(pIdObject);
        }
    }
}
