using System.Runtime.InteropServices.ComTypes;
using Unity;

namespace IBusiness.Common
{
    public interface IFacadeProvider
    {
        #region Methods

        T Resolver<T>() where T : IFacade ;

        #endregion
    }
}
