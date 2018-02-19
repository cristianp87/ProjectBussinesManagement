using Bll_Business;
using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using IBusiness.Common;
using IBusiness.Management;
using Project_BusinessManagement.Models;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class TaxeController : Controller
    {
        #region Variables and Constants
        public IProduct LiProduct =
        FacadeProvider.Resolver<BllProduct>();

        public ITaxe LiTaxe =
        FacadeProvider.Resolver<BllTaxe>();
        #endregion
        // GET: Taxe
        public ActionResult Index(int pIdProduct)
        {
            var lListTaxes = this.LiTaxe.bll_GetListallTaxesXProduct(pIdProduct);
            return this.View(MTaxe.MListAllTaxesXProduct(lListTaxes, pIdProduct));
        }

        // GET: Taxe/Details/5
        public ActionResult Details(int id)
        {
            return this.View();
        }

        // GET: Taxe/Create
        public ActionResult AssociateProduct(int pIdProduct)
        {
            var lProduct = this.LiProduct.bll_GetProductById(pIdProduct);
            var lMProduct = MProduct.MProductById(lProduct);
            lMProduct.LListSelectTaxe = MTaxe.MListTaxesWithSelect(this.LiTaxe.bll_GetListTaxesWithOutProduct(pIdProduct));
            return this.View(lMProduct);
        }

        // POST: Taxe/Create
        [HttpPost]
        public ActionResult AssociateProduct(MProduct pMProduct)
        {
            try
            {
                var result = this.LiTaxe.bll_AssociateTaxeXProduct(pMProduct.LIdProduct, pMProduct.LTaxe.LIdTaxe);
                if (string.IsNullOrEmpty(result))
                {
                    return this.RedirectToAction("Index", new { pIdProduct = pMProduct.LIdProduct});
                }
                else
                {
                    pMProduct.LMessageException = result;
                    return this.View(this.ListsEmptyViewProduct(pMProduct));
                }
                
            }
            catch(Exception e)
            {
                pMProduct.LMessageException = e.Message;
                return this.View(this.ListsEmptyViewProduct(pMProduct));
            }
        }


        // GET: Taxe/Delete/5
        public ActionResult Delete(int pIdTaxe, int pIdProduct)
        {
            var lTaxe = this.LiTaxe.bll_GetTaxe(pIdTaxe);
            var lMTaxe = MTaxe.GetTaxeXProduct(lTaxe, pIdProduct);
            return this.View(lMTaxe);
        }

        // POST: Taxe/Delete/5
        [HttpPost]
        public ActionResult Delete(int pIdTaxe, int pIdProduct, MTaxe pTaxe)
        {
            try
            {
                var lMessage = this.LiTaxe.bll_DeleteTaxeXProduct(pIdProduct, pIdTaxe);
                if (string.IsNullOrEmpty(lMessage))
                {
                    return this.RedirectToAction("Index", new { pIdProduct = pIdProduct});
                }
                else
                {
                    pTaxe.LMessageException = lMessage;
                    return this.View(pTaxe);
                }
            }
            catch(Exception e)
            {
                pTaxe.LMessageException = e.Message;
                return this.View(pTaxe);
            }
        }

        public MProduct ListsEmptyViewProduct(MProduct pMProduct)
        {
            pMProduct.LListSelectTaxe = MTaxe.MListTaxesWithSelect(this.LiTaxe.bll_GetListTaxes());
            return pMProduct;
        }
    }
}
