using System.Web.Mvc;

namespace Project_BusinessManagement.Controllers
{
    public class HomeController : BaseApiController
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            return this.View();
        }

        public ActionResult Contact()
        {
            return this.View();
        }

    }
}