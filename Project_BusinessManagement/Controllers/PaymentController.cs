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
        #endregion

        #region controllers
        
        // GET: Payment
        public ActionResult Index(int pIdOrder, decimal pValueOrder)
        {
            ViewData["LIdOrder"] = pIdOrder;
            ViewData["ValueOrder"] = Convert.ToInt32(pValueOrder);
            var lListPayment = this.LiPaymentFacade.bll_GetPaymentByOrder(pIdOrder);
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
                if (LValueTotal >= lValidatesum)
                {
                    var lMessage = this.LiPaymentFacade.bll_InsertPayment(pPayment.LOrder.LIdOrder, pPayment.LValuePayment, this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectPayment).LIdObject, this.LiUtilsLib.bll_getStatusApproByObject(this.LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectPayment).LIdObject).LIdStatus);
                    if (string.IsNullOrEmpty(lMessage))
                    {
                        return RedirectToAction("Index", new { pIdOrder = LIdOrder , pValueOrder = LValueTotal});
                    }
                    pPayment.LMessageException = lMessage;
                    return View(pPayment);
                }
                pPayment.LMessageException = CodesError.LMsgPaymentDenied;
                return View(pPayment);

            }
            catch
            {
                return View();
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
