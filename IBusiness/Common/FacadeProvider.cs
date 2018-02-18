using IBusiness.Management;
using Microsoft.Practices.Unity;
using Unity;

namespace IBusiness.Common
{
    public static class FacadeProvider
    {
        #region Properties

        public static IFacadeProvider FacadeProviderInstance { private get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Get instance of facade obtained from IoC Container.
        /// </summary>
        /// <typeparam name="T">Facade type.</typeparam>
        /// <returns>Returns the instance of facade.</returns>
        public static T Resolver<T>() where T : IFacade
        {
            return FacadeProviderInstance.Resolver<T>();
        }

        #endregion
    }
}
