using System.Web.Mvc;

namespace Project_BusinessManagement.Extensibles
{
    public static class MvcViews
    {
        public static MvcHtmlString IfAllowedConfiguration(this MvcHtmlString action, string pConfigurationApp)
        {                    
            return pConfigurationApp.ToCompareconfiguration()? action:null;
        }
    }
}