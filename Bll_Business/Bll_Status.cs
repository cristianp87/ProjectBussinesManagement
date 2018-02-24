using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;
using System.Collections.Generic;
using IDaoBusiness.Business;

namespace Bll_Business
{
    public class BllStatus : IStatus
    {
        public IDaoStatus LiStatus { get; set; }
    

        public BllStatus()
        {
            this.LiStatus = new DaoStatus();
        }

        public List<Bo_Status>  Bll_getListStatusByIdObject(int pIdObject)
        {
            return this.LiStatus.Dao_getListStatusByIdObject(pIdObject);
        }
    }
}
