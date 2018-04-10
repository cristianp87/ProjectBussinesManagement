using System;
using System.Web.Mvc;
using IBusiness.Common;
using IBusiness.Management;
using Project_BusinessManagement.Models;
using Project_BusinessManagement.Models.Mappers;
using Project_BusinessManagement.Models.Enums;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = EGlobalVariables.LRoleAdmin)]
    public class TaxeController : BaseApiController
    {
        #region Variables and Constants
        public IProduct LiProduct =
        FacadeProvider.Resolv<IProduct>();

        public ITaxe LiTaxe =
        FacadeProvider.Resolv<ITaxe>();
        #endregion
        // GET: Taxe
        public ActionResult Index(int pIdProduct)
        {
            var lListTaxes = this.LiTaxe.bll_GetListallTaxesXProduct(pIdProduct);
            return this.View(lListTaxes.MListAllTaxesXProduct(pIdProduct));
        }


        // GET: Taxe/Create
        public ActionResult AssociateProduct(int pIdProduct)
        {
            var lProduct = this.LiProduct.bll_GetProductById(pIdProduct);
            var lMProduct = lProduct.MProductById();
            lMProduct.LListSelectTaxe = this.LiTaxe.bll_GetListTaxesWithOutProduct(pIdProduct).MListTaxesWithSelect(false);
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
                pMProduct.LMessageException = result;
                return this.View(this.ListsEmptyViewProduct(pMProduct));
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
            var lMTaxe = lTaxe.GetTaxeXProduct(pIdProduct);
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
                    return this.RedirectToAction("Index", new {pIdProduct});
                }
                pTaxe.LMessageException = lMessage;
                return this.View(pTaxe);
            }
            catch(Exception e)
            {
                pTaxe.LMessageException = e.Message;
                return this.View(pTaxe);
            }
        }

        public MProduct ListsEmptyViewProduct(MProduct pMProduct)
        {
            pMProduct.LListSelectTaxe = this.LiTaxe.bll_GetListTaxes().MListTaxesWithSelect(false);
            return pMProduct;
        }
    }
}
