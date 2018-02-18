using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;
using IBusiness.Management;

namespace Bll_Business
{
    public class BllSupplier : ISupplier
    {
        public Bo_Supplier bll_GetSupplierById(int pIdSupplier)
        {
            var oDaoSupplier = new Dao_Supplier();
            return oDaoSupplier.Dao_getSupplierById(pIdSupplier);
        }

        public List<Bo_Supplier> bll_GetAllSupplier()
        {
            var oDaoSupplier = new Dao_Supplier();
            return oDaoSupplier.Dao_getSupplierListAll();
        }

        public string bll_InsertSupplier(string pNameSupplier, string pNoIdentification, int pIdTypeIdentifiction, int pIdObject, string pIdStatus)
        {
            var oSupplier = new Bo_Supplier
            {
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus},
                LTypeIdentification = new Bo_TypeIdentification {LIdTypeIdentification = pIdTypeIdentifiction},
                LNameSupplier = pNameSupplier,
                LNoIdentification = pNoIdentification
            };
            var oDaoSupplier= new Dao_Supplier();
            return oDaoSupplier.Dao_InsertSupplier(oSupplier);
        }

        public string bll_UpdateSupplier(int pIdSupplier, string pNameSupplier, string pNoIdentification, int pIdTypeIdentifiction, int pIdObject, string pIdStatus)
        {
            var oSupplier = new Bo_Supplier
            {
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus},
                LTypeIdentification = new Bo_TypeIdentification {LIdTypeIdentification = pIdTypeIdentifiction},
                LIdSupplier = pIdSupplier,
                LNameSupplier = pNameSupplier,
                LNoIdentification = pNoIdentification
            };
            var oDaoSupplier = new Dao_Supplier();
            return oDaoSupplier.Dao_UpdateSupplier(oSupplier);
        }

        public string bll_DeleteSupplier(int pIdSupplier)
        {
            var oSupplier = new Bo_Supplier {LIdSupplier = pIdSupplier};
            var oDaoSupplier = new Dao_Supplier();
            return oDaoSupplier.Dao_DeleteSupplier(oSupplier);
        }
    }
}
