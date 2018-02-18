using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management
{
    public interface ISupplier : IFacade
    {
        Bo_Supplier bll_GetSupplierById(int pIdSupplier);

        List<Bo_Supplier> bll_GetAllSupplier();

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

    }
}
