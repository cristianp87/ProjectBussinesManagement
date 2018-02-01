using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;

namespace Bll_Business
{
    public class Bll_UtilsLib
    {
        public static Bo_Object bll_GetObjectByName(string pNameObject)
        {
            return Dao_UtilsLib.DaoUtilsLib_getObject(pNameObject);
        }

        public static List<Bo_Unit> bll_GetAllUnit()
        {
            return Dao_UtilsLib.DaoUtilsLib_getAllUnit();
        }

        public static Bo_Status bll_getStatusApproByObject(int pIdObject)
        {
            return Dao_UtilsLib.DaoUtilsLib_getStatusAppro(pIdObject);
        }

        /// <summary>
        /// traer el parametro que tiene valores en la bd.
        /// </summary>
        /// <param name="pNameParameter"></param>
        /// <param name="pNameParentParameter"></param>
        /// <returns></returns>
        public static string bll_GetValueParameter(string pNameParameter, string pNameParentParameter)
        {
            return Dao_UtilsLib.DaoUtilsLib_getParameterValueConfiguration(pNameParameter, pNameParentParameter);
        }

        /// <summary>
        /// Traer el parametro sin ningun valor solo para saber si esta activo
        /// </summary>
        /// <param name="pNameParameter"></param>
        /// <param name="pActive"></param>
        /// <returns></returns>
        public static string bll_GetValueParameter(string pNameParameter, bool pActive)
        {
            return Dao_UtilsLib.DaoUtilsLib_getParameterConfigurationActive(pNameParameter, pActive);
        }
    }
}
