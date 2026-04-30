using DataFactory.Infrastructure.business;
using DataFactory.Infrastructure.business.operation;
using DataUtilities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTG_ERPWebApi.api.business
{
    [Route("api/[controller]"), Produces("application/json"), EnableCors("AppPolicy")]
    [ApiController]
    public class docuploadController : ControllerBase
    {

        #region Variable Declaration & Initialization
        private IWebHostEnvironment _hostingEnvironment;
        private DocUploadMgt _manager = null;
        #endregion

        #region Constructor
        public docuploadController(IWebHostEnvironment hostingEnvironment)
        {
            _manager = new DocUploadMgt();
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

        //GET: api/uploadtype/getbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getbyid([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                object[] arr = JsonConvert.DeserializeObject<object[]>(param);
                resdata = await _manager.GetByID(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // POST: api/university/saveupdateform
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
                //string rootPath = _hostingEnvironment.WebRootPath.ToString();
                resdata = await _manager.SaveUpdateFiles(allDocs, arr);
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

        // POST: api/docupload/saveupdatedform
        [HttpPost("[action]")]//BasicAuthorization
        //[Consumes("application/x-www-form-urlencoded")]
        public async Task<object> saveupdatedform([FromForm] JsonRequestItem item)
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
                //string rootPath = _hostingEnvironment.WebRootPath.ToString();
                resdata = await _manager.SaveUpdateFiles(allDocs, arr);
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

        public class JsonRequestItem
        {
            public string data { get; set; }
        }

        //// POST: api/uploadtype/saveupdate
        //[HttpPost("[action]")]//BasicAuthorization
        //public async Task<object> saveupdate([FromBody] object[] data)
        //{
        //    object resdata = null;
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(data.ToString()))
        //        {
        //            resdata = await _manager.SaveUpdate(data);
        //        }
        //    }
        //    catch (Exception) { }

        //    return new
        //    {
        //        resdata
        //    };
        //}

        // DELETE: api/uploadtype/delete
        [HttpDelete("[action]")]//BasicAuthorization
        public async Task<object> delete([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                object[] arr = JsonConvert.DeserializeObject<object[]>(param);
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
