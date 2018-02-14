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
            UnityContainer.RegisterType<IInventory, Bll_Inventory>();
            this.myFacadesInstances = new ConcurrentDictionary<Type, IFacade>();
        }

        #endregion
        public T Resolver<T>() where T : IFacade
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
    }
}
