using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBusiness.Common;
using IBusiness.Management;
using Unity;
using Microsoft.Practices.Unity;

namespace Bll_Business.Common
{
    public class FacadeProvider : IFacadeProvider
    {
        #region  Variables And Constants
        public readonly ConcurrentDictionary<Type, IFacade> myFacadesInstances;
        public static IUnityContainer UnityContainer;
        #endregion


        #region  Constructor
        public FacadeProvider()
        {
            UnityContainer = new UnityContainer();
            UnityContainer.RegisterType<ICustomer, BllCustomer>();
            UnityContainer.RegisterType<IDashBoard, BllDashBoard>();
            UnityContainer.RegisterType<IInventory, BllInventory>();
            UnityContainer.RegisterType<IInventoryItem, BllInventoryItem>();
            UnityContainer.RegisterType<IInvoice, BllInvoice>();
            UnityContainer.RegisterType<IInvoiceItem, BllInvoiceItem>();
            UnityContainer.RegisterType<IOrder, BllOrder>();
            UnityContainer.RegisterType<IOrderItem, BllOrderItem>();
            UnityContainer.RegisterType<IProduct, BllProduct>();
            UnityContainer.RegisterType<IBusinessRole, BllRole>();
            UnityContainer.RegisterType<IStatus, BllStatus>();
            UnityContainer.RegisterType<ISupplier, BllSupplier>();
            UnityContainer.RegisterType<ITaxe, BllTaxe>();
            UnityContainer.RegisterType<ITypeIdentification, BllTypeIdentification>();
            UnityContainer.RegisterType<IBusinessUser, BllUser>();
            UnityContainer.RegisterType<IUtilsLib, BllUtilsLib>();           
            this.myFacadesInstances = new ConcurrentDictionary<Type, IFacade>();
        }

        #endregion
        public T Resolv<T>() where T : IFacade
        {
            if (this.myFacadesInstances.ContainsKey(typeof (T)))
            {
                IFacade facade;
                this.myFacadesInstances.TryGetValue(typeof (T), out facade);
                return (T) facade;
            }
            else
            {
                var facade = UnityContainer.Resolve<T>();
                if (facade == null)
                {
                    throw new ArgumentException("The facade type is invalid.");
                }
                this.myFacadesInstances.TryAdd(typeof (T), facade);
                return facade;
            }
        }

        public IFacadeProvider RegisterFacadeProvider()
        {
            UnityContainer.RegisterType<IFacadeProvider, FacadeProvider>();
            return UnityContainer.Resolve<IFacadeProvider>();
        }
    }
}
