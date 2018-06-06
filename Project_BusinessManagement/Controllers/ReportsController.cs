using IBusiness.Common;
using IBusiness.Management;
using Project_BusinessManagement.Models.Enums;
using Project_BusinessManagement.Models.Mappers;
using Project_BusinessManagement.Models.Reports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = EGlobalVariables.LRoleAdmin)]
    public class ReportsController : BaseApiController
    {
        #region Variables and Constants
        public IReports LiReportFacade =
        FacadeProvider.Resolv<IReports>();

        private static string _lRouteSales = ConfigurationManager.AppSettings["RoutePdfSales"];
        private static string _lRoutePdfAccountReceivable = ConfigurationManager.AppSettings["RoutePdfAccountReceivable"];
        private static string _lRouteInventory = ConfigurationManager.AppSettings["RoutePdfInventory"];
        #endregion

        // GET: Reports
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult SalesReport()
        {
            try {
                var lResult = this.LiReportFacade.bll_SalesReport(DateTime.Now, DateTime.Now).ToListMSales();
                Pdfs.PdfReports.GeneratePdfSales(lResult);
                return View(lResult);
            }catch(Exception e)
            {
                var lList = new List<MReportSales>();
                var lModel = new MReportSales
                {
                    LMessage = e.Message
                };
                lList.Add(lModel);
                return View(lList);
            }
            
        }

        public ActionResult AccountReceivableReport()
        {
            var lResult = this.LiReportFacade.bll_AccountReceivableReport().ToListMReportAccountReceivable();
            Pdfs.PdfReports.GeneratePdfAccountReceivable(lResult);
            return View(lResult);
        }

        public ActionResult InventoryReport()
        {      
            var lResult = this.LiReportFacade.bll_InventoryReport().ToListMInventoryItem();
            Pdfs.PdfReports.GeneratePdfInventory(lResult);
            return View(lResult);
        }

        public void DownloadFile(EDownloadReport lReport)
        {
            
            Response.ContentType = "application/pdf";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.AppendHeader("Ventas", "VideoJuegos RM");
            switch (lReport)
            {
                case EDownloadReport.sales:
                    Response.TransmitFile(Server.MapPath(_lRouteSales));
                    break;
                case EDownloadReport.accountReceivable:
                    Response.TransmitFile(Server.MapPath(_lRoutePdfAccountReceivable));
                    break;
                case EDownloadReport.inventory:
                    Response.TransmitFile(Server.MapPath(_lRouteInventory));
                    break;
                default:
                    break;
            }
                
            
            Response.End();
        }

        // GET: Reports/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reports/Create
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

        // GET: Reports/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reports/Edit/5
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

        // GET: Reports/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reports/Delete/5
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
