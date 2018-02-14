using System.Runtime.InteropServices.ComTypes;

namespace IBusiness.Common
{
    public interface IFacadeProvider
    {
        #region Methods

        T GetFacade <T>() where T : IFacade;

        #endregion
    }
}
