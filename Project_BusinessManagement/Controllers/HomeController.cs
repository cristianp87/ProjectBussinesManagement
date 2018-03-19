using System.Web.Mvc;

namespace Project_BusinessManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return this.View();
        }

    }
}