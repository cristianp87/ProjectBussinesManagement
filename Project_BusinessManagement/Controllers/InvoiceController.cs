using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO_BusinessManagement;
using Bll_Business;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index(int idCustomer)
        {
            List<Bo_Invoice> lListBoInvoice = new List<Bo_Invoice>();
            lListBoInvoice = Bll_Invoice.bll_GetAllInvoice(idCustomer);
            return View(Models.MInvoice.MListInvoice(lListBoInvoice));
        }

        // GET: Invoice/Details/5
        public ActionResult Details(int id)
        {
            Bo_Invoice lBoInvoice = new Bo_Invoice();
            lBoInvoice = Bll_Invoice.bll_GetInvoiceById(id);
            return View(Models.MInvoice.TrasferToMInvoice(lBoInvoice));
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invoice/Create
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

        // GET: Invoice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Invoice/Edit/5
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

        // GET: Invoice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Invoice/Delete/5
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
