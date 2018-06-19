using System.Collections.Generic;
using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management
{
    public interface ISupplier : IFacade
    {
        #region Methods
        BoSupplier bll_GetSupplierById(int pIdSupplier);

        List<BoSupplier> bll_GetAllSupplier();

        string bll_InsertSupplier(string pNameSupplier,
            string pNoIdentification,
            int pIdTypeIdentifiction,
            int pIdObject,
            string pIdStatus);

        string bll_UpdateSupplier(int pIdSupplier,
            string pNameSupplier,
            string pNoIdentification,
            int pIdTypeIdentifiction,
            int pIdObject,
            string pIdStatus);

        string bll_DeleteSupplier(int pIdSupplier);
    #endregion
    }
}
