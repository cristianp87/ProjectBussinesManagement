namespace IBusiness.Common
{
    public interface IFacadeProvider
    {
        #region Methods

        T Resolv<T>() where T : IFacade ;

        IFacadeProvider RegisterFacadeProvider();


        #endregion
    }
}
