using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;
using System.Collections.Generic;
using IDaoBusiness.Business;

namespace Bll_Business
{
    public class BllTypeIdentification : ITypeIdentification
    {
        public IDaoTypeIdentification LiDaoTypeIdentification { get; set; }

        public BllTypeIdentification()
        {
            this.LiDaoTypeIdentification = new DaoTypeIdentification();
        }
        public List<Bo_TypeIdentification>  bll_getListTypeIdentification()
        {
            return this.LiDaoTypeIdentification.Dao_getListAllTypeIdentification();
        }
    }
}
