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
    public class userDashboardController : ControllerBase
    {
        #region Variable Declaration & Initialization
        private IWebHostEnvironment _hostingEnvironment;
        private UserDashboardMgt _manager = null;
        #endregion

        #region Constructor
        public userDashboardController(IWebHostEnvironment hostingEnvironment)
        {
            _manager = new UserDashboardMgt();
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        #region All Http Methods
        // GET: api/userDashboard/getallentryuserbytable
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getallentryuserbytable([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                object[] arr = JsonConvert.DeserializeObject<object[]>(param);
                //dynamic data = JsonConvert.DeserializeObject(param);
                //vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetAllEntryUserByTable(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/userDashboard/getallentryuseractivity
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getallentryuseractivity([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                object[] arr = JsonConvert.DeserializeObject<object[]>(param);
                //dynamic data = JsonConvert.DeserializeObject(param);
                //vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetAllEntryUserActivity(arr);
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
