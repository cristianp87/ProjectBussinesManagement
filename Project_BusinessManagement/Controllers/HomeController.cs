using System.Web.Mvc;
using Bll_Business;

namespace Project_BusinessManagement.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            //Bo_Inventory oInventory = Bll_Inventory.bll_GetInventoryById(4);
            //string resul = Bll_Inventory.bll_InsertInventory("InvenotryPrueba", 1, "APPRO");
            //resul = Bll_Inventory.bll_UpdateInventory(1003, "InvenotryPruebaMod", 1, "APPRO");
            //resul = Bll_Inventory.bll_DeleteInventory(1003);
            return View();
        }
        public ActionResult Prueba()
        {

            //Bo_Inventory oInventory = Bll_Inventory.bll_GetInventoryById(4);
            //string resul = Bll_Inventory.bll_InsertInventory("InvenotryPrueba", 1, "APPRO");
            //resul = Bll_Inventory.bll_UpdateInventory(1003, "InvenotryPruebaMod", 1, "APPRO");
            //resul = Bll_Inventory.bll_DeleteInventory(1003);
            return View();
        }
    }
}