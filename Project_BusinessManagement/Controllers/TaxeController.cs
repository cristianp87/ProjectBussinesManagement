using Bll_Business;
using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_BusinessManagement.Controllers
{
    public class TaxeController : Controller
    {
        // GET: Taxe
        public ActionResult Index(int pIdProduct)
        {
            List<Bo_Taxe> lListTaxes = new List<Bo_Taxe>();
            lListTaxes = Bll_Taxe.bll_GetListallTaxesXProduct(pIdProduct);
            return View(Models.MTaxe.MListAllTaxesXProduct(lListTaxes, pIdProduct));
        }

        // GET: Taxe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Taxe/Create
        public ActionResult AssociateProduct(int pIdProduct)
        {
            Bo_Product lProduct = new Bo_Product();
            Models.MProduct lMProduct = new Models.MProduct();
            lProduct = Bll_Product.bll_GetProductById(pIdProduct);
            lMProduct = Models.MProduct.MProductById(lProduct);
            lMProduct.LListSelectTaxe = Models.MTaxe.MListTaxesWithSelect(Bll_Taxe.bll_GetListTaxesWithOutProduct(pIdProduct));
            return View(lMProduct);
        }

        // POST: Taxe/Create
        [HttpPost]
        public ActionResult AssociateProduct(Models.MProduct pMProduct)
        {
            try
            {
                // TODO: Add insert logic here
                var result = Bll_Taxe.bll_AssociateTaxeXProduct(pMProduct.LIdProduct, pMProduct.LTaxe.LIdTaxe);
                if (string.IsNullOrEmpty(result))
                {
                    return RedirectToAction("Index", new { pIdProduct = pMProduct.LIdProduct});
                }
                else
                {
                    pMProduct.LMessageException = result;
                    return View(this.ListsEmptyViewProduct(pMProduct));
                }
                
            }
            catch(Exception e)
            {
                pMProduct.LMessageException = e.Message;
                return View(this.ListsEmptyViewProduct(pMProduct));
            }
        }

        // GET: Taxe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Taxe/Create
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

        // GET: Taxe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Taxe/Edit/5
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

        // GET: Taxe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Taxe/Delete/5
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

        public Models.MProduct ListsEmptyViewProduct(Models.MProduct pMProduct)
        {
            pMProduct.LListSelectTaxe = Models.MTaxe.MListTaxesWithSelect(Bll_Taxe.bll_GetListTaxes());
            return pMProduct;
        }
    }
}
