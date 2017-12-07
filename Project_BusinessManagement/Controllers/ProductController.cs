using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO_BusinessManagement;
using Bll_Business;
using Project_BusinessManagement.App_Start;

namespace Project_BusinessManagement.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Bo_Product> oBListProduct = new List<Bo_Product>();
            oBListProduct = Bll_Product.bll_GetAllProduct();
            return View(Models.MProduct.MListProduct(oBListProduct));
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Bo_Product oBProduct = new Bo_Product();
            oBProduct = Bll_Product.bll_GetProductById(id);
            return View(Models.MProduct.MProductById(oBProduct));
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            Bo_Product oBProduct = new Bo_Product();
            return View(Models.MProduct.MProductEmpty(oBProduct));
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Models.MProduct pMProduct)
        {
            try
            {
                ModelState.Remove("LSupplier.LNameSupplier");
                ModelState.Remove("LSupplier.LNoIdentification");
                if (ModelState.IsValid)
                {
                    string lMessage = Bll_Product.bll_InsertProduct(Request.Form["LNameProduct"].ToString(), Request.Form["LCdProduct"].ToString(), Convert.ToDecimal(Request.Form["LValue"]), Convert.ToDecimal(Request.Form["LValueSupplier"]), Convert.ToInt32(Request.Form["LUnit.LIdUnit"].ToString()), Convert.ToInt32(Request.Form["LSupplier.LIdSupplier"].ToString()), Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString()), Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ListEmptyProduct(pMProduct);
                        pMProduct.LMessageException = lMessage;
                        return View(pMProduct);
                    }

                }
                else
                {
                    ListEmptyProduct(pMProduct);
                    return View(pMProduct);
                }
            }
            catch (Exception e)
            {
                ListEmptyProduct(pMProduct);
                pMProduct.LMessageException = e.Message;
                return View(pMProduct);
            }
        }

        [HttpPost]
        public ActionResult AddTaxe(Models.MProduct pMProduct)
        {
            try
            {
                
                pMProduct.LTaxe = new Models.MTaxe();
                pMProduct.LStatus = new Models.MStatus();
                if(pMProduct.LListIdsTaxe == null)
                {
                    pMProduct.LListIdsTaxe = Request.Form["LTaxe.LIdTaxe"].ToString();
                }
                else
                {
                    pMProduct.LListIdsTaxe = "," + Request.Form["LTaxe.LIdTaxe"].ToString();
                }
                ListEmptyProduct(pMProduct);
                List<Models.MTaxe> lListTaxe = new List<Models.MTaxe>();
                lListTaxe = pMProduct.LListTaxe;             
                pMProduct.LTaxe.LIdTaxe = Convert.ToInt32(Request.Form["LTaxe.LIdTaxe"].ToString());
                pMProduct.LListTaxe = new List<Models.MTaxe>();
                if (lListTaxe != null)
                {
                    pMProduct.LListTaxe = lListTaxe;
                }
                pMProduct.LListTaxe.Add(pMProduct.LTaxe);
                return View("Create", pMProduct);
            }
            catch (Exception e)
            {
                ListEmptyProduct(pMProduct);
                pMProduct.LMessageException = e.Message;
                return View("Create", pMProduct);
            }
        }



        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Bo_Product oBProduct = new Bo_Product();
            oBProduct = Bll_Product.bll_GetProductById(id);
            return View(Models.MProduct.MProductById(oBProduct));
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.MProduct pMProduct)
        {
            try
            {
                Models.MProduct lMProduct = new Models.MProduct();
                ModelState.Remove("LSupplier.LNameSupplier");
                ModelState.Remove("LSupplier.LNoIdentification");
                if (ModelState.IsValid)
                {
                    string lMessage = Bll_Product.bll_UpdateProduct(id, Request.Form["LNameProduct"].ToString(), Request.Form["LCdProduct"].ToString(), Convert.ToDecimal(Request.Form["LValue"]), Convert.ToDecimal(Request.Form["LValueSupplier"]), Convert.ToInt32(Request.Form["LUnit.LIdUnit"].ToString()), Convert.ToInt32(Request.Form["LSupplier.LIdSupplier"].ToString()), Convert.ToInt32(Request.Form["LObject.LIdObject"].ToString()), Request.Form["LStatus.LIdStatus"].ToString());
                    if (lMessage == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(CurrentProduct(lMProduct, pMProduct, id, lMessage));
                    }

                }
                else
                {
                    CurrentProduct(lMProduct, pMProduct, id, "Hay Campos que deben ser llenados.");
                    return View(lMProduct);
                }
            }
            catch(Exception e)
            {
                
                Models.MProduct lMProduct = new Models.MProduct();
                CurrentProduct(lMProduct, pMProduct, id, e.Message);
                return View(lMProduct);
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Bo_Product oBProduct = new Bo_Product();
            oBProduct = Bll_Product.bll_GetProductById(id);
            return View(Models.MProduct.MProductById(oBProduct));
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Models.MProduct pMProduct)
        {
            try
            {
                string lMessage = Bll_Product.bll_DeleteProduct(id);
                if(lMessage == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    pMProduct.LMessageException = lMessage;
                    return View(pMProduct);
                }
                
            }
            catch(Exception e)
            {
                pMProduct.LMessageException = e.Message;
                return View(pMProduct);
            }
        }

        private static void ListEmptyProduct(Models.MProduct pMProduct)
        {
            pMProduct.LListSupplier = new List<SelectListItem>();
            pMProduct.LListSupplier = Models.MSupplier.MListAllSupplierWithSelect(Bll_Supplier.bll_GetAllSupplier());
            pMProduct.LListUnit = new List<SelectListItem>();
            pMProduct.LListUnit = Models.MUnit.MListAllUnitWithSelect(Bll_UtilsLib.bll_GetAllUnit());
            pMProduct.LListStatus = new List<SelectListItem>();
            pMProduct.LListStatus = Models.MStatus.MListAllStatus(Bll_Status.Bll_getListStatusByIdObject(pMProduct.LObject.LIdObject));
            pMProduct.LListSelectTaxe = new List<SelectListItem>();
            pMProduct.LListSelectTaxe = Models.MTaxe.MListTaxesWithSelect(Bll_Taxe.bll_GetListTaxes());
        }

        private static Models.MProduct CurrentProduct(Models.MProduct pMProduct, Models.MProduct pMProductOld, int id, string pMessageException)
        {
            Bo_Product oBProduct = new Bo_Product();
            oBProduct = Bll_Product.bll_GetProductById(id);
            pMProduct = Models.MProduct.MProductById(oBProduct);
            pMProduct.LNameProduct = pMProductOld.LNameProduct;
            pMProduct.LValue = pMProductOld.LValue;
            pMProduct.LValueSupplier = pMProductOld.LValueSupplier;
            pMProduct.LSupplier.LIdSupplier = pMProductOld.LSupplier.LIdSupplier;
            pMProduct.LMessageException = pMessageException;
            return pMProduct;
        }
    }
}
