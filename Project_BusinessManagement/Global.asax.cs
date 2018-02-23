﻿using Project_BusinessManagement.App_Start;
using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IBusiness.Common;
using Unity;

namespace Project_BusinessManagement
{
    public class Global : System.Web.HttpApplication
    {
        private  IUnityContainer _unityContainer;

        protected void Application_Start(object sender, EventArgs e)
        {
            _unityContainer = new UnityContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.Configure(GlobalFilters.Filters);
            RouteConfig.Configure(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var registerUnity = _unityContainer.RegisterType<IFacadeProvider, Bll_Business.Common.FacadeProvider>();
            FacadeProvider.FacadeProviderInstance = registerUnity.Resolve<IFacadeProvider>();
        }

    protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}