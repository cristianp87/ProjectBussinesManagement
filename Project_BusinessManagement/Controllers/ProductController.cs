using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BO_BusinessManagement;
using IBusiness.Common;
using IBusiness.Management;
using Project_BusinessManagement.Filters;
using Project_BusinessManagement.Models;
using Project_BusinessManagement.Models.Enums;
using Project_BusinessManagement.Models.Mappers;
using System.Linq;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = EGlobalVariables.LRoleAdmin)]
    [ConfigurationApp(EGlobalVariables.LIsProduct)]
    public class ProductController : BaseApiController
    {
        #region Variables and Constants
        public static IProduct LiProduct =
        FacadeProvider.Resolv<IProduct>();

        public static ISupplier LiSupplier =
        FacadeProvider.Resolv<ISupplier>();

        public static IStatus LStatus =
        FacadeProvider.Resolv<IStatus>();

        public static ITaxe LiTaxe =
        FacadeProvider.Resolv<ITaxe>();

        public IUtilsLib LiUtilsLib =
        FacadeProvider.Resolv<IUtilsLib>();
        #endregion
        // GET: Product
        public ActionResult Index()
        {
            var lListProduct = LiProduct.bll_GetAllProduct();
            return this.View(lListProduct.MListProduct());
        }

        [HttpPost]
        public ActionResult Index(string pSearchName)
        {
            var lListProduct = LiProduct.bll_GetAllProduct();
            if (string.IsNullOrEmpty(pSearchName))
                return this.View(lListProduct.MListProduct());
            lListProduct = lListProduct.Where(s => s.LNameProduct.ToUpper().Contains(pSearchName.ToUpper())).ToList();
            return this.View(lListProduct.MListProduct());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var oBProduct = LiProduct.bll_GetProductById(id);
            return this.View(oBProduct.MProductById());
        }

        [ConfigurationApp(EGlobalVariables.LCreateProduct)]
        // GET: Product/Create
        public ActionResult Create()
        {
            var lBProduct = new BoProduct();
            return this.View(lBProduct.MProductEmpty());
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(MProduct pMProduct)
        {
            try
            {
                this.ModelState.Remove(EFields.LFieldNameSupplier);
                this.ModelState.Remove(EFields.LFieldNoIdentificationSupplier);
                if (this.ModelState.IsValid)
                {
                    var lMessage = LiProduct.bll_InsertProduct(pMProduct.LNameProduct, pMProduct.LCdProduct, Convert.ToDecimal(pMProduct.LValue), Convert.ToDecimal(pMProduct.LValueSupplier), Convert.ToInt32(pMProduct.LUnit.LIdUnit), Convert.ToInt32(pMProduct.LSupplier.LIdSupplier), Convert.ToInt32(this.Request.Form[EFields.LFieldListObject]), this.LiUtilsLib.bll_getStatusApproByObject(this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectProduct).LIdObject).LIdStatus);
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index");
                    }
                    this.ListEmptyProduct(pMProduct);
                    pMProduct.LMessageException = lMessage;
                    return this.View(pMProduct);
                }
                this.ListEmptyProduct(pMProduct);
                return this.View(pMProduct);
            }
            catch (Exception e)
            {
                this.ListEmptyProduct(pMProduct);
                pMProduct.LMessageException = e.Message;
                return this.View(pMProduct);
            }
        }



        public ActionResult AddTaxe(MProduct pMProduct)
        {
            try
            {
                
                pMProduct.LTaxe = new MTaxe();
                pMProduct.LStatus = new MStatus();
                if(pMProduct.LListIdsTaxe == null)
                {
                    pMProduct.LListIdsTaxe = pMProduct.LTaxe.LIdTaxe.ToString();
                }
                else
                {
                    pMProduct.LListIdsTaxe = "," + pMProduct.LTaxe.LIdTaxe;
                }
                this.ListEmptyProduct(pMProduct);
                var lListTaxe = pMProduct.LListTaxe;             
                pMProduct.LTaxe.LIdTaxe = Convert.ToInt32(pMProduct.LTaxe.LIdTaxe);
                pMProduct.LListTaxe = new List<MTaxe>();
                if (lListTaxe != null)
                {
                    pMProduct.LListTaxe = lListTaxe;
                }
                pMProduct.LListTaxe.Add(pMProduct.LTaxe);
                return this.View("Create", pMProduct);
            }
            catch (Exception e)
            {
                this.ListEmptyProduct(pMProduct);
                pMProduct.LMessageException = e.Message;
                return this.View("Create", pMProduct);
            }
        }


        [ConfigurationApp(EGlobalVariables.LEditProduct)]
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var oBProduct = LiProduct.bll_GetProductById(id);
            return this.View(oBProduct.MProductById());
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MProduct pMProduct)
        {
            try
            {
                var lMProduct = new MProduct();
                this.ModelState.Remove(EFields.LFieldNameSupplier);
                this.ModelState.Remove(EFields.LFieldNoIdentificationSupplier);
                if (this.ModelState.IsValid)
                {
                    var lMessage = LiProduct.bll_UpdateProduct(id, pMProduct.LNameProduct, pMProduct.LCdProduct, Convert.ToDecimal(pMProduct.LValue), Convert.ToDecimal(pMProduct.LValueSupplier), Convert.ToInt32(pMProduct.LUnit.LIdUnit), Convert.ToInt32(pMProduct.LSupplier.LIdSupplier), Convert.ToInt32(this.Request.Form[EFields.LFieldListObject]), this.Request.Form[EFields.LFieldListStatus]);
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index");
                    }
                    return this.View(CurrentProduct(lMProduct, pMProduct, id, lMessage));
                }
                CurrentProduct(lMProduct, pMProduct, id, EMessages.LMsgEditfieldsemtpy);
                return this.View(lMProduct);
            }
            catch(Exception e)
            {
                
                var lMProduct = new MProduct();
                CurrentProduct(lMProduct, pMProduct, id, e.Message);
                return this.View(lMProduct);
            }
        }

        [ConfigurationApp(EGlobalVariables.LDeleteProduct)]
        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var oBProduct = LiProduct.bll_GetProductById(id);
            return this.View(oBProduct.MProductById());
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MProduct pMProduct)
        {
            try
            {
                var lMessage = LiProduct.bll_DeleteProduct(id);
                if(lMessage == null)
                {
                    return this.RedirectToAction("Index");
                }
                pMProduct.LMessageException = lMessage;
                return this.View(pMProduct);
            }
            catch(Exception e)
            {
                pMProduct.LMessageException = e.Message;
                return this.View(pMProduct);
            }
        }

        private void ListEmptyProduct(MProduct pMProduct)
        {
            pMProduct.LListSupplier = new List<SelectListItem>();
            pMProduct.LListSupplier = LiSupplier.bll_GetAllSupplier().MListAllSupplierWithSelect(true);
            pMProduct.LListUnit = new List<SelectListItem>();
            pMProduct.LListUnit = this.LiUtilsLib.bll_GetAllUnit().MListAllUnitWithSelect();
            pMProduct.LListStatus = new List<SelectListItem>();
            pMProduct.LListStatus = LStatus.Bll_getListStatusByIdObject(pMProduct.LObject.LIdObject).MListAllStatus();
            pMProduct.LListSelectTaxe = new List<SelectListItem>();
            pMProduct.LListSelectTaxe = LiTaxe.bll_GetListTaxes().MListTaxesWithSelect(false);
        }

        private static MProduct CurrentProduct(MProduct pMProduct, MProduct pMProductOld, int id, string pMessageException)
        {
            var oBProduct = LiProduct.bll_GetProductById(id);
            if (pMProduct == null)
            {
                pMProduct = oBProduct.MProductById();
                pMProduct.LNameProduct = pMProductOld.LNameProduct;
                pMProduct.LValue = pMProductOld.LValue;
                pMProduct.LValueSupplier = pMProductOld.LValueSupplier;
                pMProduct.LSupplier.LIdSupplier = pMProductOld.LSupplier.LIdSupplier;
                pMProduct.LMessageException = pMessageException;
            }           
            pMProduct = oBProduct.MProductById();
            pMProduct.LNameProduct = pMProductOld.LNameProduct;
            pMProduct.LValue = pMProductOld.LValue;
            pMProduct.LValueSupplier = pMProductOld.LValueSupplier;
            pMProduct.LSupplier.LIdSupplier = pMProductOld.LSupplier.LIdSupplier;
            pMProduct.LMessageException = pMessageException;
            return pMProduct;
        }
    }
}
