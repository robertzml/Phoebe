using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FastReport;
using FastReport.Export.Html;
using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phoebe.Core.BL;
using Phoebe.Core.DL;

namespace Phoebe.WebAPI.Controllers
{
    /// <summary>
    /// 报表控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        #region Field
        private readonly IHostingEnvironment _hostingEnvironment; // We use the web interface hosting environment to get out root path of it
        #endregion //Field

        #region Constructor
        public ReportController(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 入库单报表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult StockIn(string id, int uid)
        {
            string webRootPath = _hostingEnvironment.WebRootPath; //Define the path to the wwwroot folder
            string reportPath = (webRootPath + "/App_Data/StockIn.frx"); //Define the path to the report

            using (MemoryStream stream = new MemoryStream()) //Create the stream for the report
            {
                try
                {
                    // 获取用户
                    UserBusiness userBusiness = new UserBusiness();
                    var user = userBusiness.FindById(uid);

                    // 获取入库单
                    StockInViewBusiness stockInViewBusiness = new StockInViewBusiness();
                    var stockIn = stockInViewBusiness.FindById(id);

                    // 获取入库任务
                    StockInTaskViewBusiness stockInTaskViewBusiness = new StockInTaskViewBusiness();
                    var stockInTasks = stockInTaskViewBusiness.Query(r => r.StockInId == id);

                    // create report instance
                    Report report = new Report();

                    // 载入报表
                    report.Load(reportPath);

                    // 配置数据
                    report.SetParameterValue("VehicleNumber", stockIn.VehicleNumber);
                    report.SetParameterValue("CustomerName", stockIn.CustomerName);
                    report.SetParameterValue("CustomerNumber", stockIn.CustomerNumber);
                    report.SetParameterValue("StockInTime", stockIn.InTime.ToString("yyyy-MM-dd"));
                    report.SetParameterValue("FlowNumber", stockIn.FlowNumber);
                    report.SetParameterValue("UserName", user.Name);
                    report.RegisterData(stockInTasks, "StockInTasks");

                    // prepare the report
                    report.Prepare();

                    // 导出PDF
                    PDFSimpleExport pdf = new PDFSimpleExport();
                    report.Export(pdf, stream);
                    var mime = "application/pdf";

                    //Get the name of resulting report file with needed extension
                    var file = String.Concat(Path.GetFileNameWithoutExtension(reportPath), ".", "pdf");
                    return File(stream.ToArray(), mime);
                }
                catch (Exception e)
                {
                    return new NoContentResult();
                }
                finally
                {
                    stream.Dispose();
                }
            }
        }

        /// <summary>
        /// 出库单报表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult StockOut(string id, int uid)
        {
            string webRootPath = _hostingEnvironment.WebRootPath; //Define the path to the wwwroot folder
            string reportPath = (webRootPath + "/App_Data/StockOut.frx"); //Define the path to the repor

            using (MemoryStream stream = new MemoryStream()) //Create the stream for the report
            {
                try
                {
                    // 获取用户
                    UserBusiness userBusiness = new UserBusiness();
                    var user = userBusiness.FindById(uid);

                    // 获取出库单
                    StockOutViewBusiness stockOutViewBusiness = new StockOutViewBusiness();
                    var stockOut = stockOutViewBusiness.FindById(id);

                    // 获取出库任务
                    StockOutTaskViewBusiness stockOutTaskViewBusiness = new StockOutTaskViewBusiness();
                    var stockOutTasks = stockOutTaskViewBusiness.Query(r => r.StockOutId == id);

                    // create report instance
                    Report report = new Report();

                    // 载入报表
                    report.Load(reportPath);

                    // 配置数据
                    report.SetParameterValue("VehicleNumber", stockOut.VehicleNumber);
                    report.SetParameterValue("CustomerName", stockOut.CustomerName);
                    report.SetParameterValue("CustomerNumber", stockOut.CustomerNumber);
                    report.SetParameterValue("StockOutTime", stockOut.OutTime.ToString("yyyy-MM-dd"));
                    report.SetParameterValue("FlowNumber", stockOut.FlowNumber);
                    report.SetParameterValue("UserName", user.Name);
                    report.RegisterData(stockOutTasks, "StockOutTasks");

                    // prepare the report
                    report.Prepare();

                    // 导出PDF
                    PDFSimpleExport pdf = new PDFSimpleExport();
                    report.Export(pdf, stream);
                    var mime = "application/pdf";

                    //Get the name of resulting report file with needed extension
                    var file = String.Concat(Path.GetFileNameWithoutExtension(reportPath), ".", "pdf");
                    return File(stream.ToArray(), mime);
                }
                catch (Exception e)
                {
                    return new NoContentResult();
                }
                finally
                {
                    stream.Dispose();
                }
            }
        }
        #endregion //Action
    }
}
