using IBusiness.Common;
using IBusiness.Management;
using Project_BusinessManagement.Models;
using Project_BusinessManagement.Models.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_BusinessManagement.Controllers
{
    public class CashRegisterController : BaseApiController
    {
        #region Variables and Constants
        public ICashRegister LiCashRegister =
        FacadeProvider.Resolv<ICashRegister>();

        #endregion
        // GET: CashRegister
        public ActionResult Index()
        {
            ViewData["Total"] = "$0";
            var lBoListCash = this.LiCashRegister.bll_GetListLastCashRegister();
            if(lBoListCash.Count() <= 0)
            {
                var lIdCashRegister = this.LiCashRegister.bll_GetFirstIdCashRegister();
                var lCashRegister = new BO_BusinessManagement.BoCashRegister
                {
                    LIdCashRegister = lIdCashRegister
                };
                lBoListCash.Add(lCashRegister);
            }
            var lSumInput = lBoListCash.Where(x => x.LIsInput == true).Sum(y => y.LValue);
            var lSumOutPut = lBoListCash.Where(x => x.LIsInput == false).Sum(y => y.LValue);
            ViewData["Total"] = "$" + Convert.ToInt32(lSumInput - lSumOutPut);
            return this.View(lBoListCash.MListCashhRegister());
        }

        public ActionResult CreateInput(int pIdCashRegister)
        {
            var lMCashRegister = new MCashRegister
            {
                LIdCashRegister = pIdCashRegister
            };
            return this.View(lMCashRegister);
        }

        [HttpPost]
        public ActionResult CreateInput(MCashRegister pCashRegister)
        {
            var lResult = this.LiCashRegister.bll_CreateCashInput(pCashRegister.LIdCashRegister, pCashRegister.LValue, pCashRegister.LDescription);
            if (string.IsNullOrEmpty(lResult))
            {
                return RedirectToAction("Index");
            }
            pCashRegister.LMessageException = lResult;
            return this.View(pCashRegister);
        }

        public ActionResult CreateOutPut(int pIdCashRegister)
        {
            var lMCashRegister = new MCashRegister
            {
                LIdCashRegister = pIdCashRegister
            };
            return this.View(lMCashRegister);
        }

        [HttpPost]
        public ActionResult CreateOutPut(MCashRegister pCashRegister)
        {
            var lResult = this.LiCashRegister.bll_CreateCashOutput(pCashRegister.LIdCashRegister, pCashRegister.LValue, pCashRegister.LDescription);
            if (string.IsNullOrEmpty(lResult))
            {
                return RedirectToAction("Index");
            }
            pCashRegister.LMessageException = lResult;
            return this.View(pCashRegister);
        }
    }
}