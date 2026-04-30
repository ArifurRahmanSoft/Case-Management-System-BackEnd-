using DataFactory.Infrastructure.business.operation;
using DataModels.ViewModels;
using DataUtilities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace CTG_ERPWebApi.api.business.configuration
{
    [Route("api/[controller]"), Produces("application/json"), EnableCors("AppPolicy")]
    [ApiController]
    public class deedreportController : ControllerBase
    {
        #region Variable Declaration & Initialization
        private IWebHostEnvironment _hostingEnvironment;
        private DeedReportMgt _manager = null;
        #endregion

        #region Constructor
        public deedreportController(IWebHostEnvironment hostingEnvironment)
        {
            _manager = new DeedReportMgt();
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        #region All Http Methods
        // GET: api/deedreport/getbypage
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getbypage([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                object[] arr = JsonConvert.DeserializeObject<object[]>(param);
                //dynamic data = JsonConvert.DeserializeObject(param);
                //vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetByPage(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // POST: api/deedreport/getdeedreport
        [HttpPost("[action]")]
        public async Task<object> getdeedreport([FromBody] object[] data)
        {
            object resdata = null;
            try
            { 
                dynamic cparam = JsonConvert.DeserializeObject(data[0].ToString());
                string filePath = _hostingEnvironment.WebRootPath + cparam.reportPath;
                string repType = cparam.reportType;
                resdata = await _manager.GetDeedReports(data, filePath, repType);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }
        #endregion
    }
}
