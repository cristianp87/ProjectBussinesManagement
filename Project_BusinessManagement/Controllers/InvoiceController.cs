using Bll_Business;
using BO_BusinessManagement;
using System.Collections.Generic;
using System.Web.Mvc;
using IBusiness.Common;
using IBusiness.Management;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class InvoiceController : Controller
    {
        #region Variables and Constants
        public IInvoice LInvoice =
        FacadeProvider.Resolver<BllInvoice>();


        #endregion
        // GET: Invoice
        public ActionResult Index(int idCustomer)
        {
            var lListBoInvoice = this.LInvoice.bll_GetAllInvoice(idCustomer);
            return View(Models.MInvoice.MListInvoice(lListBoInvoice));
        }

        // GET: Invoice/Details/5
        public ActionResult Details(int id)
        {
            var lBoInvoice = this.LInvoice.bll_GetInvoiceById(id);
            return View(Models.MInvoice.TrasferToMInvoice(lBoInvoice));
        }
    }
}
