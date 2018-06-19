using System.Web.Mvc;
using IBusiness.Common;
using IBusiness.Management;
using Project_BusinessManagement.Models.Mappers;
using System.Linq;
using Project_BusinessManagement.Models.Enums;
using Project_BusinessManagement.Models.Reports;
using System.Collections.Generic;
using Project_BusinessManagement.Models;
using Neodynamic.SDK.Web;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = EGlobalVariables.LRoleAdmin)]
    public class InvoiceController : BaseApiController
    {
        #region Variables and Constants
        public IInvoice LInvoice =
        FacadeProvider.Resolv<IInvoice>();


        #endregion
        // GET: Invoice
        public ActionResult Index(int idCustomer)
        {
            var lListBoInvoice = this.LInvoice.bll_GetAllInvoice(idCustomer);
            return this.View(lListBoInvoice.MListInvoice());
        }

        [HttpPost]
        public ActionResult Index(int idCustomer, string pSearchCode)
        {
            var lListBoInvoice = this.LInvoice.bll_GetAllInvoice(idCustomer);
            if (string.IsNullOrEmpty(pSearchCode))
                return this.View(lListBoInvoice.MListInvoice());
            lListBoInvoice = lListBoInvoice.Where(s => s.LCdInvoice.ToUpper().Contains(pSearchCode.ToUpper())).ToList();
            return this.View(lListBoInvoice.MListInvoice());
        }

        // GET: Invoice/Details/5
        public ActionResult Details(int id)
        {
            var lBoInvoice = this.LInvoice.bll_GetInvoiceById(id).TrasferToMInvoice();
            ViewBag.WCPScript = WebClientPrint.CreateScript(Url.Action("ProcessRequest", "WebClientPrintAPI", null, HttpContext.Request.Url.Scheme), Url.Action("PrintCommands", "Invoice", new { pIdInvoice = id }, HttpContext.Request.Url.Scheme), HttpContext.Session.SessionID);
            return this.View(lBoInvoice);
        }

        [AllowAnonymous]
        public void PrintCommands(string useDefaultPrinter, string printerName, int pIdInvoice)
        {
            var lBoInvoice = this.LInvoice.bll_GetInvoiceById(pIdInvoice).TrasferToMInvoice();
            var lPrint = new Printer.Printing();
            lPrint.PrintInvoice("checked", null, lBoInvoice);
        }
    }
}
