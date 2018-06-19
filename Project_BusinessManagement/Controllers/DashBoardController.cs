using System.Collections;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using IBusiness.Common;
using IBusiness.Management;
using Project_BusinessManagement.Filters;
using Project_BusinessManagement.Models.Enums;

namespace Project_BusinessManagement.Controllers
{
    [Authorize(Roles = EGlobalVariables.LRoleAdmin)]
    [ConfigurationApp(EGlobalVariables.LIsDashBoard)]
    public class DashBoardController : BaseApiController
    {
        #region properties

        public IDashBoard LBoard = FacadeProvider.Resolv<IDashBoard>();
        #endregion
        // GET: DashBoard
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult ProductSellToday()
        {
            var xValue = new ArrayList();
            var yValue = new ArrayList();
            var list =  this.LBoard.bll_GetProductSellToday();

            list.ToList().ForEach(rs => xValue.Add(rs.Xstring));
            list.ToList().ForEach(rs => yValue.Add(rs.Yint));
             new Chart(400, 200, ChartTheme.Green)
            .AddTitle(EMessages.LMsgTitleDashProductSellToday)
            .AddSeries(EMessages.LMsgDashDefault, EMessages.LMsgDashColumn, xValue: xValue, yValues: yValue)
            .Write(EMessages.LMsgDashbmp);

            return null;
        }

        public ActionResult ProductSellTodayLine()
        {
            var xValue = new ArrayList();
            var yValue = new ArrayList();
            var list = this.LBoard.bll_GetProductSellToday();

            list.ToList().ForEach(rs => xValue.Add(rs.Xstring));
            list.ToList().ForEach(rs => yValue.Add(rs.Yint));
            new Chart(400, 200, ChartTheme.Green)
           .AddTitle(EMessages.LMsgTitleDashProductSellToday)
           .AddSeries(EMessages.LMsgDashDefault, EMessages.LMsgDashLine, xValue: xValue, yValues: yValue)
           .Write(EMessages.LMsgDashbmp);

            return null;
        }



    }
}
