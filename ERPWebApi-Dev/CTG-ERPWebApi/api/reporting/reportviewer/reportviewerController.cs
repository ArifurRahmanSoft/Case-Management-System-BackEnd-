using DataUtilities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using DataFactory.Infrastructure.business;
using DataModels.ViewModels;
using DataFactory.Infrastructure.business.operation;

namespace CTG_ERPWebApi.api.reporting.reportviewer
{
    [Route("api/[controller]"), EnableCors("AppPolicy")]
    [ApiController]
    public class reportviewerController : Controller
    {
        private IMemoryCache _cache;
        private IWebHostEnvironment _hostingEnvironment;
        private TestReportMgt _manager = null;
        private DeedReportMgt _deedReportMgt;
        public reportviewerController(IMemoryCache memoryCache, IWebHostEnvironment hostingEnvironment)
        {
            _manager = new TestReportMgt();
            _deedReportMgt = new DeedReportMgt();
            _cache = memoryCache;
            _hostingEnvironment = hostingEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [HttpPost("[action]")]
        public async Task<object> gettestreport([FromBody] object[] data)
        {
            object resdata = null;
            try
            {
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[1].ToString());
                dynamic cparam = JsonConvert.DeserializeObject(data[0].ToString());
                string filePath = _hostingEnvironment.WebRootPath + cparam.reportPath;
                string repType = cparam.reportType;
                resdata = _manager.GetTestReport(filePath, repType, cmnParam).Result;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return new
            {
                resdata
            };
        }

        [HttpPost("[action]")]
        public async Task<object> getdeedreportbyid([FromBody] object[] data)
        {
            object resdata = null;
            try
            {                
                dynamic cparam = JsonConvert.DeserializeObject(data[0].ToString());
                string filePath = _hostingEnvironment.WebRootPath + cparam.reportPath;
                string repType = cparam.reportType;
                resdata = _deedReportMgt.GetDeedReport(data, filePath, repType).Result;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return new
            {
                resdata
            };
        }
    }
}