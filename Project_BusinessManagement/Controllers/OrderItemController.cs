using System.Web.Mvc;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class OrderItemController : Controller
    {
        // GET: OrderItem
        public ActionResult Index(int pIdOrder)
        {
            return View(Models.MOrderItem.MListOrder(Bll_Business.Bll_OrderItem.bll_GetOrderItem(pIdOrder)));
        }

        // GET: OrderItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderItem/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderItem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderItem/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
