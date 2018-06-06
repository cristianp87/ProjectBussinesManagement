using IBusiness.Common;
using IBusiness.Management;
using Project_BusinessManagement.Models;
using Project_BusinessManagement.Models.Enums;
using Project_BusinessManagement.Models.Mappers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Project_BusinessManagement.Controllers
{
    public class PaymentController : BaseApiController
    {
        #region Variables and Constants
        public IPayment LiPaymentFacade =
        FacadeProvider.Resolv<IPayment>();


        public IUtilsLib LiUtilsLib =
        FacadeProvider.Resolv<IUtilsLib>();

        public IInvoiceItem LInvoiceItem =
        FacadeProvider.Resolv<IInvoiceItem>();

        public IInvoice LInvoice =
        FacadeProvider.Resolv<IInvoice>();

        public IOrder LiOrder =
        FacadeProvider.Resolv<IOrder>();

        public IOrderItem LiOrderItem =
        FacadeProvider.Resolv<IOrderItem>();
        #endregion

        #region controllers

        // GET: Payment
        public ActionResult Index(int pIdOrder, decimal pValueOrder, int? pIdInvoice)
        {
            ViewData["LIdOrder"] = pIdOrder;
            ViewData["ValueOrder"] = Convert.ToInt32(pValueOrder);
            ViewData["MsgCompleted"] = "";
            ViewData["Total"] = "0";
            if (pIdInvoice != null)
            {
                var lInvoice = this.LInvoice.bll_GetInvoiceById(Convert.ToInt32(pIdInvoice));
                ViewData["MsgCompleted"] = string.Format(EMessages.LMsgPaymentcompleted, lInvoice.LCdInvoice);
            }            
            var lListPayment = this.LiPaymentFacade.bll_GetPaymentByOrder(pIdOrder);
            if (lListPayment.Any())
            {
                ViewData["Total"] = EGlobalVariables.LMoney + Convert.ToInt32((pValueOrder - lListPayment.Sum(x => x.LValuePayment))).ToString(); 
            }
            
            return this.View(lListPayment.MListPayment());
        }



        // GET: Payment/Create
        public ActionResult Create(int pIdOrder, decimal pValueOrder)
        {
            MPayment lPayment = new MPayment();
            lPayment.LOrder = new MOrder
            {
                LIdOrder = pIdOrder,
                LValueOrder = pValueOrder
            };
            lPayment.LIsCompleted = false;
            return View(lPayment);
        }

        // POST: Payment/Create
        [HttpPost]
        public ActionResult Create(MPayment pPayment)
        {
            try
            {
                var LValueTotal = Convert.ToInt32(pPayment.LOrder.LValueOrder);
                var LIdOrder = Convert.ToInt32(pPayment.LOrder.LIdOrder);
                var lPayments = this.LiPaymentFacade.bll_GetPaymentByOrder(LIdOrder);
                var lSumValuePay = Convert.ToInt32(lPayments.Sum(x => x.LValuePayment));
                var lValidatesum = lSumValuePay + pPayment.LValuePayment;
                if (LValueTotal > lValidatesum)
                {
                    var lMessage = this.LiPaymentFacade.bll_InsertPayment(pPayment.LOrder.LIdOrder, pPayment.LValuePayment, this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectPayment).LIdObject, this.LiUtilsLib.bll_getStatusApproByObject(this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectPayment).LIdObject).LIdStatus);
                    if (string.IsNullOrEmpty(lMessage))
                    {
                        return RedirectToAction("Index", new { pIdOrder = LIdOrder , pValueOrder = LValueTotal});
                    }
                    pPayment.LMessageException = lMessage;
                    return View(pPayment);
                }
                if(LValueTotal == lValidatesum)
                {
                    var lMessage = this.LiPaymentFacade.bll_InsertPayment(pPayment.LOrder.LIdOrder, pPayment.LValuePayment, this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectPayment).LIdObject, this.LiUtilsLib.bll_getStatusApproByObject(this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectPayment).LIdObject).LIdStatus);                                       
                    if (string.IsNullOrEmpty(lMessage))
                    {
                        var lIdInvoice = 0;
                        var lOrder = this.LiOrder.bll_GetOrder(pPayment.LOrder.LIdOrder);
                        var lListOrderItem = this.LiOrderItem.bll_GetOrderItem(pPayment.LOrder.LIdOrder);
                        var lListInvoiceItem = this.LInvoiceItem.bll_ChangeOrderItemToInvoiceItem(lListOrderItem, this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectInvoiceItem));
                        var lResult = this.LInvoice.bll_InsertInvoiceAll(lOrder.LCustomer.LIdCustomer, lOrder.LIdOrder, this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectInvoice).LIdObject, lListInvoiceItem);
                        if(int.TryParse(lResult,out lIdInvoice))
                        {
                            this.LiOrder.bll_UpdateOrder(lOrder.LIdOrder, this.LiUtilsLib.bll_getStatusApproByObject(this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectOrder).LIdObject).LIdStatus);
                            return RedirectToAction("Index", new { pIdOrder = LIdOrder, pValueOrder = LValueTotal, pIdInvoice =  lIdInvoice});
                        }
                        return RedirectToAction("Index", new { pIdOrder = LIdOrder, pValueOrder = LValueTotal});
                    }
                    pPayment.LMessageException = lMessage;
                    return View(pPayment);
                }
                pPayment.LMessageException = CodesError.LMsgPaymentDenied;
                return View(pPayment);

            }
            catch(Exception e)
            {
                pPayment.LMessageException = e.Message;
                return View(pPayment);
            }
        }


        // GET: Payment/Delete/5
        public ActionResult Delete(int id, decimal pValueOrder)
        {
            var lPayment = this.LiPaymentFacade.bll_GetPayment(id);
            lPayment.LOrder.LValueOrder = pValueOrder;
            return View(lPayment.ToMPayment());
        }

        // POST: Payment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MPayment pPayment)
        {
            try
            {
                var LValueTotal = Convert.ToInt32(pPayment.LOrder.LValueOrder);
                var LIdOrder = Convert.ToInt32(pPayment.LOrder.LIdOrder);
                // TODO: Add delete logic here
                var lMessage = this.LiPaymentFacade.bll_DeletePayment(id);
                if (string.IsNullOrEmpty(lMessage))
                {
                    return RedirectToAction("Index", new { pIdOrder = LIdOrder, pValueOrder = LValueTotal });
                }
                pPayment.LMessageException = lMessage;
                return View(id);
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region privateMethods

        #endregion  
    }
}
