using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;
using System.Collections.Generic;

namespace Bll_Business
{
    public class BllUtilsLib : IUtilsLib
    {
        public BoObject bll_GetObjectByName(string pNameObject)
        {
            return DaoUtilsLib.DaoUtilsLib_getObject(pNameObject);
        }

        public List<BoUnit> bll_GetAllUnit()
        {
            return DaoUtilsLib.DaoUtilsLib_getAllUnit();
        }

        public BoStatus bll_getStatusApproByObject(int pIdObject)
        {
            return DaoUtilsLib.DaoUtilsLib_getStatusAppro(pIdObject);
        }

        public BoStatus bll_getStatusInProByObject(int pIdObject)
        {
            return DaoUtilsLib.DaoUtilsLib_getStatusInPro(pIdObject);
        }

        /// <summary>
        /// traer el parametro que tiene valores en la bd.
        /// </summary>
        /// <param name="pNameParameter"></param>
        /// <param name="pNameParentParameter"></param>
        /// <returns></returns>
        public string bll_GetValueParameter(string pNameParameter, string pNameParentParameter)
        {
            return DaoUtilsLib.DaoUtilsLib_getParameterValueConfiguration(pNameParameter, pNameParentParameter);
        }

        /// <summary>
        /// Traer el parametro sin ningun valor solo para saber si esta activo
        /// </summary>
        /// <param name="pNameParameter"></param>
        /// <param name="pActive"></param>
        /// <returns></returns>
        public string bll_GetValueParameter(string pNameParameter, bool pActive)
        {
            return DaoUtilsLib.DaoUtilsLib_getParameterConfigurationActive(pNameParameter, pActive);
        }
    }
}
