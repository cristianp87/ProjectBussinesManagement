using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Bll_Business;
using System.Collections;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult ProductSellToday()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            var list =  Bll_DashBoard.bll_GetProductSellToday();

            list.ToList().ForEach(rs => xValue.Add(rs.Xstring));
            list.ToList().ForEach(rs => yValue.Add(rs.Yint));
             new System.Web.Helpers.Chart(width: 400, height: 200, theme: ChartTheme.Green)
            .AddTitle("Productos Vendidos Hoy")
            .AddSeries("default", chartType: "column", xValue: xValue, yValues: yValue)
            .Write("bmp");

            return null;
        }

        public ActionResult ProductSellTodayLine()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            var list = Bll_DashBoard.bll_GetProductSellToday();

            list.ToList().ForEach(rs => xValue.Add(rs.Xstring));
            list.ToList().ForEach(rs => yValue.Add(rs.Yint));
            new System.Web.Helpers.Chart(width: 400, height: 200, theme: ChartTheme.Green)
           .AddTitle("Productos Vendidos Hoy")
           .AddSeries("default", chartType: "line", xValue: xValue, yValues: yValue)
           .Write("bmp");

            return null;
        }



    }
}
