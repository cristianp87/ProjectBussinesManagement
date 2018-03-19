using System.Web.Mvc;
using IBusiness.Common;
using IBusiness.Management;
using Project_BusinessManagement.Models.Mappers;
using Project_BusinessManagement.Models.Enums;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = EGlobalVariables.LRoleAdmin + EGlobalVariables.LQuote + EGlobalVariables.LRoleEmp1)]
    public class OrderItemController : Controller
    {
        public IOrderItem LOrderItem =
           FacadeProvider.Resolv<IOrderItem>();
        // GET: OrderItem
        public ActionResult Index(int pIdOrder)
        {
            return this.View(this.LOrderItem.bll_GetOrderItem(pIdOrder).MListOrderItem());
        }
    }
}
