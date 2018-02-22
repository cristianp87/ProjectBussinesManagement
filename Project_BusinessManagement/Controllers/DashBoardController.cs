﻿using Project_BusinessManagement.Filters;
using System.Collections;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using IBusiness.Common;
using IBusiness.Management;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = "Administrador")]
    [ConfigurationApp(pParameter: "IsDashBoard")]
    public class DashBoardController : Controller
    {
        #region properties

        public IDashBoard LBoard = FacadeProvider.Resolver<IDashBoard>();
        #endregion
        // GET: DashBoard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductSellToday()
        {
            var xValue = new ArrayList();
            var yValue = new ArrayList();
            var list =  this.LBoard.bll_GetProductSellToday();

            list.ToList().ForEach(rs => xValue.Add(rs.Xstring));
            list.ToList().ForEach(rs => yValue.Add(rs.Yint));
             new Chart(width: 400, height: 200, theme: ChartTheme.Green)
            .AddTitle("Productos Vendidos Hoy")
            .AddSeries("default", chartType: "column", xValue: xValue, yValues: yValue)
            .Write("bmp");

            return null;
        }

        public ActionResult ProductSellTodayLine()
        {
            var xValue = new ArrayList();
            var yValue = new ArrayList();
            var list = this.LBoard.bll_GetProductSellToday();

            list.ToList().ForEach(rs => xValue.Add(rs.Xstring));
            list.ToList().ForEach(rs => yValue.Add(rs.Yint));
            new Chart(width: 400, height: 200, theme: ChartTheme.Green)
           .AddTitle("Productos Vendidos Hoy")
           .AddSeries("default", chartType: "line", xValue: xValue, yValues: yValue)
           .Write("bmp");

            return null;
        }



    }
}
