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
    public class DeedController : ControllerBase
    {
        #region Variable Declaration & Initialization
        private IWebHostEnvironment _hostingEnvironment;
        private DeedMgt _manager = null;
        #endregion

        #region Constructor
        public DeedController(IWebHostEnvironment hostingEnvironment)
        {
            _manager = new DeedMgt();
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
        public async Task<object> getbyidforsetlocation([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                object[] arr = JsonConvert.DeserializeObject<object[]>(param);
                //dynamic data = JsonConvert.DeserializeObject(param);
                //vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetByIDForSetLocation(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/deed/getdeedmodelbyid
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getdeedmodelbyid([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                object[] arr = JsonConvert.DeserializeObject<object[]>(param);
                //dynamic data = JsonConvert.DeserializeObject(param);
                //vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetDocumentByID(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        //// POST: api/deed/saveupdateform
        //[HttpPost("[action]")]//BasicAuthorization
        //public async Task<object> saveupdateforms()
        //{
        //    object resdata = null;
        //    try
        //    {
        //        var req = Context.request;
        //        IFormCollection form;
        //        form = await req.HttpContext.Request.ReadFormAsync();
        //        var allDocs = form.Files;

        //        //dynamic data = JsonConvert.DeserializeObject(form["data"]);
        //        object[] arr = JsonConvert.DeserializeObject<object[]>(form["data"]);
        //        string rootPath = _hostingEnvironment.WebRootPath.ToString();
        //        resdata = await _manager.SaveUpdateFiles(allDocs, arr, rootPath);
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }

        //    return new
        //    {
        //        resdata
        //    };
        //}

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
                //string rootPath = _hostingEnvironment.WebRootPath.ToString();
                resdata = await _manager.SaveUpdate(allDocs, arr);
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

        // POST: api/deed/saveupdateform
        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> saveupdateforms()
        {
            object resdata = null;
            try
            {
                var req = Context.request;
                IFormCollection form;
                form = await req.HttpContext.Request.ReadFormAsync();
                var allDocs = form.Files;

                object[] arr = JsonConvert.DeserializeObject<object[]>(form["data"]);

                resdata = new {
                    result= "TLD000001",
                    message= "Saved Successfully",
                    resstate=true
                };
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

        // POST: api/deed/insertdata
        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> InsertJsonData([FromBody] object[] data)
        {
            object resdata = null;
            try
            {
                resdata = await _manager.InsertJsonData(data);
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

        //// POST: api/deed/saveupdate
        //[HttpPost("[action]")]//BasicAuthorization
        //public async Task<object> saveupdate([FromBody] object[] data)
        //{
        //    object resdata = null;
        //    try
        //    {
        //        resdata = await _manager.SaveUpdate(data, null, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }

        //    return new
        //    {
        //        resdata
        //    };
        //}

        //// POST: api/deed/saveupdateuploadedfileform
        //[HttpPost("[action]")]//BasicAuthorization
        //public async Task<object> saveupdateuploadedfileform()
        //{
        //    object resdata = null;
        //    try
        //    {
        //        var req = Context.request;
        //        IFormCollection form;
        //        form = await req.HttpContext.Request.ReadFormAsync();
        //        var allDocs = form.Files;

        //        //dynamic data = JsonConvert.DeserializeObject(form["data"]);
        //        object[] arr = JsonConvert.DeserializeObject<object[]>(form["data"]);
        //        string rootPath = _hostingEnvironment.WebRootPath.ToString();
        //        resdata = await _manager.SaveUpdateUploadedFiles(allDocs, arr, rootPath);
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }

        //    return new
        //    {
        //        resdata
        //    };
        //}

        // DELETE: api/deed/delete
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

        // DELETE: api/deed/delete
        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> setdeedlocation([FromBody] object[] data)
        {
            object resdata = null;
            try
            {                
                resdata = await _manager.SetDeedLocation(data);
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
