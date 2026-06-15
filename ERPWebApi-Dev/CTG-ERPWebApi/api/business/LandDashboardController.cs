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
    public class LandDashboardController : ControllerBase
    {
        #region Variable Declaration & Initialization
        private IWebHostEnvironment _hostingEnvironment;
        private DashboardMgt _manager = null;
        
        #endregion

        #region Constructor
        public LandDashboardController(IWebHostEnvironment hostingEnvironment)
        {
            _manager = new DashboardMgt();
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        #region All Http Methods





        //DashbordData
        // GET: api/landdashboard/getdeeddashbordbyarea
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getdeeddashbordbyarea([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                resdata = await _manager.GetDashbordByDistThnaMouza();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }


       
        //GetDeedDashbordData
        // GET: api/case/getcasedashbord
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getdeeddashbord([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                resdata = await _manager.GetDeedDashbord();
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
