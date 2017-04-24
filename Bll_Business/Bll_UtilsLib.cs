using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using Dao_BussinessManagement;

namespace Bll_Business
{
    public class Bll_UtilsLib
    {
        public static Bo_Object bll_GetObjectByName(string pNameObject)
        {
            return Dao_UtilsLib.DaoUtilsLib_getObject(pNameObject);
        }
    }
}
