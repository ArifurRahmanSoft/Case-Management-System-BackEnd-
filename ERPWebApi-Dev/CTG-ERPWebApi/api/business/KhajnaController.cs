using DataFactory.Infrastructure.business.operation;
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
    public class khajnaController : ControllerBase
    {
        #region Variable Declaration & Initialization
        private IWebHostEnvironment _hostingEnvironment;
        private KhajnaMgt _manager = null;
        #endregion

        #region Constructor
        public khajnaController(IWebHostEnvironment hostingEnvironment)
        {
            _manager = new KhajnaMgt();
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        #region All Http Methods
        // GET: api/deed/getbypage
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

        // GET: api/khajna/getduenewkhajnacount
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getduenewkhajnacount([FromQuery] string param)
        {
            object resdata = null;
            try
            {                
                dynamic data = JsonConvert.DeserializeObject(param);
                int year = data[0].yearBN;
                //vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetDueKhajnaCount(year);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/deed/getbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getbyid([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                object[] arr = JsonConvert.DeserializeObject<object[]>(param);
                //dynamic data = JsonConvert.DeserializeObject(param);
                //vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetByID(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/deed/getbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getkhajnalistbymutationid([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                object[] arr = JsonConvert.DeserializeObject<object[]>(param);
                //dynamic data = JsonConvert.DeserializeObject(param);
                //vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetKhajnaListByMutationId(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // POST: api/deed/saveupdateform
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
                string rootPath = _hostingEnvironment.WebRootPath.ToString();
                resdata = await _manager.SaveUpdateFiles(allDocs, arr, rootPath);
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
        
        [HttpDelete("[action]")]//BasicAuthorization
        public async Task<object> delete([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                object[] arr = JsonConvert.DeserializeObject<object[]>(param);
                //dynamic data = JsonConvert.DeserializeObject(param);
                //vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.Delete(arr);
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
