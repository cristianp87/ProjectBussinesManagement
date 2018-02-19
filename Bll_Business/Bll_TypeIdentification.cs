using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;
using System.Collections.Generic;

namespace Bll_Business
{
    public class BllTypeIdentification : ITypeIdentification
    {
        public List<Bo_TypeIdentification>  bll_getListTypeIdentification()
        {
            var oTypeIdentification = new Dao_TypeIdentification();
            return oTypeIdentification.Dao_getListAllTypeIdentification();
        }
    }
}
