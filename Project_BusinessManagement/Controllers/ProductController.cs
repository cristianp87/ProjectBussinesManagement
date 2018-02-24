using BO_BusinessManagement;
using Project_BusinessManagement.Filters;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using IBusiness.Common;
using IBusiness.Management;
using Project_BusinessManagement.Models;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = "Administrador")]
    [ConfigurationApp(pParameter: "IsProduct")]
    public class ProductController : Controller
    {
        #region Variables and Constants
        public static IProduct LiProduct =
        FacadeProvider.Resolver<IProduct>();

        public static ISupplier LiSupplier =
        FacadeProvider.Resolver<ISupplier>();

        public static IStatus LStatus =
        FacadeProvider.Resolver<IStatus>();

        public static ITaxe LiTaxe =
        FacadeProvider.Resolver<ITaxe>();

        public IUtilsLib LiUtilsLib =
        FacadeProvider.Resolver<IUtilsLib>();
        #endregion
        // GET: Product
        public ActionResult Index()
        {
            var oBListProduct = LiProduct.bll_GetAllProduct();
            return this.View(Models.MProduct.MListProduct(oBListProduct));
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var oBProduct = LiProduct.bll_GetProductById(id);
            return this.View(Models.MProduct.MProductById(oBProduct));
        }

        [ConfigurationApp(pParameter: "CreateProduct")]
        // GET: Product/Create
        public ActionResult Create()
        {
            Bo_Product oBProduct = new Bo_Product();
            return this.View(Models.MProduct.MProductEmpty(oBProduct));
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Models.MProduct pMProduct)
        {
            try
            {
                this.ModelState.Remove("LSupplier.LNameSupplier");
                this.ModelState.Remove("LSupplier.LNoIdentification");
                if (this.ModelState.IsValid)
                {
                    var lMessage = LiProduct.bll_InsertProduct(this.Request.Form["LNameProduct"].ToString(), this.Request.Form["LCdProduct"].ToString(), Convert.ToDecimal(this.Request.Form["LValue"]), Convert.ToDecimal(this.Request.Form["LValueSupplier"]), Convert.ToInt32(this.Request.Form["LUnit.LIdUnit"].ToString()), Convert.ToInt32(this.Request.Form["LSupplier.LIdSupplier"].ToString()), Convert.ToInt32(this.Request.Form["LObject.LIdObject"].ToString()), this.Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index");
                    }
                    else
                    {
                        ListEmptyProduct(pMProduct);
                        pMProduct.LMessageException = lMessage;
                        return this.View(pMProduct);
                    }

                }
                else
                {
                    ListEmptyProduct(pMProduct);
                    return this.View(pMProduct);
                }
            }
            catch (Exception e)
            {
                ListEmptyProduct(pMProduct);
                pMProduct.LMessageException = e.Message;
                return this.View(pMProduct);
            }
        }



        public ActionResult AddTaxe(Models.MProduct pMProduct)
        {
            try
            {
                
                pMProduct.LTaxe = new Models.MTaxe();
                pMProduct.LStatus = new Models.MStatus();
                if(pMProduct.LListIdsTaxe == null)
                {
                    pMProduct.LListIdsTaxe = this.Request.Form["LTaxe.LIdTaxe"].ToString();
                }
                else
                {
                    pMProduct.LListIdsTaxe = "," + this.Request.Form["LTaxe.LIdTaxe"].ToString();
                }
                ListEmptyProduct(pMProduct);
                var lListTaxe = pMProduct.LListTaxe;             
                pMProduct.LTaxe.LIdTaxe = Convert.ToInt32(this.Request.Form["LTaxe.LIdTaxe"].ToString());
                pMProduct.LListTaxe = new List<Models.MTaxe>();
                if (lListTaxe != null)
                {
                    pMProduct.LListTaxe = lListTaxe;
                }
                pMProduct.LListTaxe.Add(pMProduct.LTaxe);
                return this.View("Create", pMProduct);
            }
            catch (Exception e)
            {
                ListEmptyProduct(pMProduct);
                pMProduct.LMessageException = e.Message;
                return this.View("Create", pMProduct);
            }
        }


        [ConfigurationApp(pParameter: "EditProduct")]
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var oBProduct = LiProduct.bll_GetProductById(id);
            return this.View(Models.MProduct.MProductById(oBProduct));
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.MProduct pMProduct)
        {
            try
            {
                var lMProduct = new MProduct();
                this.ModelState.Remove("LSupplier.LNameSupplier");
                this.ModelState.Remove("LSupplier.LNoIdentification");
                if (this.ModelState.IsValid)
                {
                    var lMessage = LiProduct.bll_UpdateProduct(id, this.Request.Form["LNameProduct"].ToString(), this.Request.Form["LCdProduct"].ToString(), Convert.ToDecimal(this.Request.Form["LValue"]), Convert.ToDecimal(this.Request.Form["LValueSupplier"]), Convert.ToInt32(this.Request.Form["LUnit.LIdUnit"].ToString()), Convert.ToInt32(this.Request.Form["LSupplier.LIdSupplier"].ToString()), Convert.ToInt32(this.Request.Form["LObject.LIdObject"].ToString()), this.Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return this.RedirectToAction("Index");
                    }
                    else
                    {
                        return this.View(CurrentProduct(lMProduct, pMProduct, id, lMessage));
                    }

                }
                else
                {
                    CurrentProduct(lMProduct, pMProduct, id, "Hay Campos que deben ser llenados.");
                    return this.View(lMProduct);
                }
            }
            catch(Exception e)
            {
                
                var lMProduct = new MProduct();
                CurrentProduct(lMProduct, pMProduct, id, e.Message);
                return this.View(lMProduct);
            }
        }

        [ConfigurationApp(pParameter: "DeleteProduct")]
        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var oBProduct = LiProduct.bll_GetProductById(id);
            return this.View(Models.MProduct.MProductById(oBProduct));
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Models.MProduct pMProduct)
        {
            try
            {
                var lMessage = LiProduct.bll_DeleteProduct(id);
                if(lMessage == null)
                {
                    return this.RedirectToAction("Index");
                }
                else
                {
                    pMProduct.LMessageException = lMessage;
                    return this.View(pMProduct);
                }
                
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
            pMProduct.LListSupplier = Models.MSupplier.MListAllSupplierWithSelect(LiSupplier.bll_GetAllSupplier());
            pMProduct.LListUnit = new List<SelectListItem>();
            pMProduct.LListUnit = Models.MUnit.MListAllUnitWithSelect(this.LiUtilsLib.bll_GetAllUnit());
            pMProduct.LListStatus = new List<SelectListItem>();
            pMProduct.LListStatus = Models.MStatus.MListAllStatus(LStatus.Bll_getListStatusByIdObject(pMProduct.LObject.LIdObject));
            pMProduct.LListSelectTaxe = new List<SelectListItem>();
            pMProduct.LListSelectTaxe = Models.MTaxe.MListTaxesWithSelect(LiTaxe.bll_GetListTaxes());
        }

        private static Models.MProduct CurrentProduct(MProduct pMProduct, MProduct pMProductOld, int id, string pMessageException)
        {
            var oBProduct = LiProduct.bll_GetProductById(id);
            pMProduct = MProduct.MProductById(oBProduct);
            pMProduct.LNameProduct = pMProductOld.LNameProduct;
            pMProduct.LValue = pMProductOld.LValue;
            pMProduct.LValueSupplier = pMProductOld.LValueSupplier;
            pMProduct.LSupplier.LIdSupplier = pMProductOld.LSupplier.LIdSupplier;
            pMProduct.LMessageException = pMessageException;
            return pMProduct;
        }
    }
}
