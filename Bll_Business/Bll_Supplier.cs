using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;
using IBusiness.Management;
using IDaoBusiness.Business;

namespace Bll_Business
{
    public class BllSupplier : ISupplier
    {
        public IDaoSupplier LiDaosupplier { get; set; }

        public BllSupplier()
        {
            this.LiDaosupplier = new DaoSupplier();
        }

        public Bo_Supplier bll_GetSupplierById(int pIdSupplier)
        {
            return this.LiDaosupplier.Dao_getSupplierById(pIdSupplier);
        }

        public List<Bo_Supplier> bll_GetAllSupplier()
        {
            return this.LiDaosupplier.Dao_getSupplierListAll();
        }

        public string bll_InsertSupplier(string pNameSupplier, string pNoIdentification, int pIdTypeIdentifiction, int pIdObject, string pIdStatus)
        {
            var lSupplier = new Bo_Supplier
            {
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus},
                LTypeIdentification = new Bo_TypeIdentification {LIdTypeIdentification = pIdTypeIdentifiction},
                LNameSupplier = pNameSupplier,
                LNoIdentification = pNoIdentification
            };
            return this.LiDaosupplier.Dao_InsertSupplier(lSupplier);
        }

        public string bll_UpdateSupplier(int pIdSupplier, string pNameSupplier, string pNoIdentification, int pIdTypeIdentifiction, int pIdObject, string pIdStatus)
        {
            var lSupplier = new Bo_Supplier
            {
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus},
                LTypeIdentification = new Bo_TypeIdentification {LIdTypeIdentification = pIdTypeIdentifiction},
                LIdSupplier = pIdSupplier,
                LNameSupplier = pNameSupplier,
                LNoIdentification = pNoIdentification
            };
            return this.LiDaosupplier.Dao_UpdateSupplier(lSupplier);
        }

        public string bll_DeleteSupplier(int pIdSupplier)
        {
            var lSupplier = new Bo_Supplier {LIdSupplier = pIdSupplier};
            return this.LiDaosupplier.Dao_DeleteSupplier(lSupplier);
        }
    }
}
