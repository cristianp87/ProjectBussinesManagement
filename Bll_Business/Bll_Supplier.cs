using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using Dao_BussinessManagement;

namespace Bll_Business
{
    public class Bll_Supplier
    {
        public static Bo_Supplier bll_GetSupplierById(int pIdSupplier)
        {
            Dao_Supplier oDaoSupplier = new Dao_Supplier();
            return oDaoSupplier.Dao_getSupplierById(pIdSupplier);
        }

        public static List<Bo_Supplier> bll_GetAllSupplier()
        {
            Dao_Supplier oDaoSupplier = new Dao_Supplier();
            return oDaoSupplier.Dao_getSupplierListAll();
        }

        public static string bll_InsertSupplier(string pNameSupplier, string pNoIdentification, int pIdTypeIdentifiction, int pIdObject, string pIdStatus)
        {
            Bo_Supplier oSupplier = new Bo_Supplier();
            oSupplier.LObject = new Bo_Object();
            oSupplier.LStatus = new Bo_Status();
            oSupplier.LTypeIdentification = new Bo_TypeIdentification();
            oSupplier.LNameSupplier = pNameSupplier;
            oSupplier.LNoIdentification = pNoIdentification;
            oSupplier.LTypeIdentification.LIdTypeIdentification = pIdTypeIdentifiction;
            oSupplier.LObject.LIdObject = pIdObject;
            oSupplier.LStatus.LIdStatus = pIdStatus;
            Dao_Supplier oDaoSupplier= new Dao_Supplier();
            return oDaoSupplier.Dao_InsertSupplier(oSupplier);
        }

        public static string bll_UpdateSupplier(int pIdSupplier, string pNameSupplier, string pNoIdentification, int pIdTypeIdentifiction, int pIdObject, string pIdStatus)
        {
            Bo_Supplier oSupplier = new Bo_Supplier();
            oSupplier.LObject = new Bo_Object();
            oSupplier.LStatus = new Bo_Status();
            oSupplier.LTypeIdentification = new Bo_TypeIdentification();
            oSupplier.LIdSupplier = pIdSupplier;
            oSupplier.LNameSupplier = pNameSupplier;
            oSupplier.LNoIdentification = pNoIdentification;
            oSupplier.LTypeIdentification.LIdTypeIdentification = pIdTypeIdentifiction;
            oSupplier.LObject.LIdObject = pIdObject;
            oSupplier.LStatus.LIdStatus = pIdStatus;
            Dao_Supplier oDaoSupplier = new Dao_Supplier();
            return oDaoSupplier.Dao_UpdateSupplier(oSupplier);
        }

        public static string bll_DeleteSupplier(int pIdSupplier)
        {
            Bo_Supplier oSupplier = new Bo_Supplier();
            oSupplier.LIdSupplier = pIdSupplier;
            Dao_Supplier oDaoSupplier = new Dao_Supplier();
            return oDaoSupplier.Dao_DeleteSupplier(oSupplier);
        }
    }
}
