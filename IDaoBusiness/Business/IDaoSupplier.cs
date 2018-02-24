using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoSupplier
    {
        Bo_Supplier Dao_getSupplierById(int pIdSupplier);

        List<Bo_Supplier> Dao_getSupplierListAll();

        string Dao_InsertSupplier(Bo_Supplier pSupplier);

        string Dao_UpdateSupplier(Bo_Supplier pSupplier);

        string Dao_DeleteSupplier(Bo_Supplier pSupplier);
    }
}
