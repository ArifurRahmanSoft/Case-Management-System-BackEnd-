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
    public class CaseController : ControllerBase
    {
        #region Variable Declaration & Initialization
        private IWebHostEnvironment _hostingEnvironment;
        private CaseMgt _manager = null;
        private DeedMgt _managerDoc = null;
        #endregion

        #region Constructor
        public CaseController(IWebHostEnvironment hostingEnvironment)
        {
            _manager = new CaseMgt();
            _managerDoc = new DeedMgt();
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        #region All Http Methods
                
        //GET: api/uploadtype/getbypage
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getbypage([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                object[] arr = JsonConvert.DeserializeObject<object[]>(param);
                resdata = await _manager.GetByPage(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/case/getbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getdeedbyid([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetDeedByID(cparam);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }


        // GET: api/quotations/getbyid
        // GET: api/quotations/getbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getbyid([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetByID(cmnParam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }


        // POST: api/uploadtype/saveupdate
        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> saveupdate([FromBody] object[] data)
        {
            object resdata = null;
            try
            {
                if (!string.IsNullOrEmpty(data.ToString()))
                {
                    resdata = await _manager.SaveUpdate(data);
                }
            }
            catch (Exception) { }

            return new
            {
                resdata
            };
        }


        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> saveupdateform()
        {
            object resdata = null;
            try
            {
                var req = Context.request;
                IFormCollection form;
                form = await req.HttpContext.Request.ReadFormAsync();
                var allDocs = form.Files;

                //dynamic data = JsonConvert.DeserializeObject(form["data"]);
                object[] arr = JsonConvert.DeserializeObject<object[]>(form["data"]);
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(arr[0].ToString());
                string JsonData_Mstr = arr[1].ToString();
                string JsonData_Hearing = arr[2].ToString();
                string JsonData_Adv_Hearing = arr[3].ToString();
                resdata = await _manager.SaveUpdateForm(JsonData_Mstr, JsonData_Hearing, JsonData_Adv_Hearing, allDocs,cparam);
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



        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> saveupdatedoc()
        {
            object resdata = null;
            try
            {
                var req = Context.request;
                IFormCollection form;
                form = await req.HttpContext.Request.ReadFormAsync();
                var allDocs = form.Files;

                //dynamic data = JsonConvert.DeserializeObject(form["data"]);
                object[] arr = JsonConvert.DeserializeObject<object[]>(form["data"]);
                string refId = arr[0].ToString();

               // resdata = await _manager.SaveUpdateForm(JsonData_Mstr, JsonData_Hearing, JsonData_Adv_Hearing, allDocs, cparam);
                resdata = await _manager.SaveUpdateFiles( allDocs, arr, refId);
           
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


        //GET DASHBORD DATA

        // GET: api/case/getcasedashbord
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getcasedashbord([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                resdata = await _manager.GetDashbordData();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        //GetDeedDashbordData
        // GET: api/case/getcasedashbord
   /*     [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getdashbordbyarea([FromQuery] string param)
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
        }*/


       
        //GetDeedDashbordData
        // GET: api/case/getcasedashbord
       /* [HttpGet("[action]")]//BasicAuthorization
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
        }*/

        #endregion
    }
}
