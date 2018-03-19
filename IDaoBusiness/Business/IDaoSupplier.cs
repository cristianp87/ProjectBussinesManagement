using System.Collections.Generic;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoSupplier
    {
        BoSupplier Dao_getSupplierById(int pIdSupplier);

        List<BoSupplier> Dao_getSupplierListAll();

        string Dao_InsertSupplier(BoSupplier pSupplier);

        string Dao_UpdateSupplier(BoSupplier pSupplier);

        string Dao_DeleteSupplier(BoSupplier pSupplier);
    }
}
