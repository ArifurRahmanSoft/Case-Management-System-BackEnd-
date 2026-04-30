using DataFactory.Infrastructure.business;
using DataFactory.Infrastructure.business.operation;
using Microsoft.AspNetCore.Cors;
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
    public class thanaSetupController : ControllerBase
    {

        #region Variable Declaration & Initialization
        private ThanaSetupMgt _manager = null;
        #endregion

        #region Constructor
        public thanaSetupController()
        {
            _manager = new ThanaSetupMgt();
        }
        #endregion

        #region All Http Methods                
        //GET: api/thanaSetup/getbypage
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

        //GET: api/thanaSetup/getbyid
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

        // POST: api/thanaSetup/saveupdate
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

        // DELETE: api/thanaSetup/delete
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
