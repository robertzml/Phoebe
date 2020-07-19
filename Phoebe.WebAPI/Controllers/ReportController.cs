using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FastReport;
using FastReport.Export.Html;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phoebe.Core.BL;

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
        public IActionResult StockIn(string id)
        {
            string webRootPath = _hostingEnvironment.WebRootPath; //Define the path to the wwwroot folder
            string reportPath = (webRootPath + "/App_Data/StockIn.frx"); //Define the path to the report

            using (MemoryStream stream = new MemoryStream()) //Create the stream for the report
            {
                try
                {
                    // 获取入库单


                    // 获取入库任务
                    StockInTaskBusiness stockInTaskBusiness = new StockInTaskBusiness();
                    var stockInTasks = stockInTaskBusiness.Query(r => r.StockInId == id);

                    // create report instance
                    Report report = new Report();

                    report.Load(reportPath); //Load the report

                    // register the array
                    report.RegisterData(stockInTasks, "StockInTasks");

                    // prepare the report
                    report.Prepare();

                    //report export to HTML
                    HTMLExport html = new HTMLExport();
                    html.SinglePage = true; //report on the one page
                    html.Navigator = false; //navigation panel on top
                    html.EmbedPictures = true; //build in images to the document
                    report.Export(html, stream);
                    var mime = "text/html"; //redefine mime for html

                    //Get the name of resulting report file with needed extension
                    var file = String.Concat(Path.GetFileNameWithoutExtension(reportPath), ".", "html");
                    return File(stream.ToArray(), mime);
                }
                catch
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
