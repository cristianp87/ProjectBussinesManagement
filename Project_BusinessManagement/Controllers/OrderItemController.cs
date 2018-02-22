using System.Web.Mvc;
using IBusiness.Common;
using IBusiness.Management;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = "Administrador, Cajero")]
    public class OrderItemController : Controller
    {
        public IOrderItem LOrderItem =
           FacadeProvider.Resolver<IOrderItem>();
        // GET: OrderItem
        public ActionResult Index(int pIdOrder)
        {
            return View(Models.MOrderItem.MListOrder(this.LOrderItem.bll_GetOrderItem(pIdOrder)));
        }
    }
}
