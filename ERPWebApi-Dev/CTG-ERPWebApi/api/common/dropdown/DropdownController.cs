using DataFactory.Infrastructure.common.dropdown;
using DataModels.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CTG_ERPWebApi.api.common.dropdown
{
    [Route("api/[controller]"), Produces("application/json"), EnableCors("AppPolicy")]
    [ApiController]
    public class dropdownController : ControllerBase
    {
        #region Variable Declaration & Initialization
        private CommonDropdownMgt _manager = null;
        #endregion

        #region Constructor
        public dropdownController()
        {
            _manager = new CommonDropdownMgt();
        }
        #endregion
        
        // GET: api/dropdown/getallrole
        [HttpGet("[action]")]//BasicAuthorization
        public async Task<object> getallrole()
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.GetAllRole();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET: api/dropdown/getallroleForReopen
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getalluserbycompany([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetAllUserByCompany(cparam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET: api/dropdown/getallcompanyuser
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getallcompanyuser([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                vmCmnParameter cparam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
                resdata = await _manager.GetAllCompanyUser(cparam);
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET: api/dropdown/getalluploadtype
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getalluploadtype([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                //dynamic data = JsonConvert.DeserializeObject(param);
                //object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetAllUploadType();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getalldivision
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getalldivision([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                //dynamic data = JsonConvert.DeserializeObject(param);
                //object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetAllDivision();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getalldistrict
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getalldistrict([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                //dynamic data = JsonConvert.DeserializeObject(param);
                //object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetAllDistrict();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getdistrictbyId
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getdistrictbyid([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetDistrictById(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getthanabyid
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getthanabyid([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetThanaById(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getmouzabyid
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getmouzabyid([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetMouzaById(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getallmouza
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getallmouza([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetAllMouza(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getregistryofficebyid
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getregistryofficebyid([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetRegistryOfficeById(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getlandofficebyid
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getlandofficebyid([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetLandOfficeById(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getallowner
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getallowner([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                //dynamic data = JsonConvert.DeserializeObject(param);
                //object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetAllOwner();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getallseller
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getallsellers([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                //dynamic data = JsonConvert.DeserializeObject(param);
                //object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetAllSeller();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getallseller
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getallseller([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetAllSeller(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        //GET: api/dropdown/getcompanylist
        [HttpGet("[action]"), BasicAuthorization]
        public async Task<object> getcompanylist([FromQuery] string param)
        {
            object result = null; object resdata = null;
            try
            {
                resdata = await _manager.GetAllCompany();
            }
            catch (Exception) { }
            return result = new
            {
                resdata
            };
        }

        // GET: api/dropdown/getalldistrict
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getalldistrictsrc([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetAllDistrictSrc(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getthanabyid
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getthanabyidsrc([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetThanaByIdSrc(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getmouzabyid
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getmouzabyidsrc([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetMouzaByIdSrc(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }        

        // GET: api/dropdown/getallowner
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getallownersrc([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetAllOwnerSrc(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getallseller
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getallsellersrc([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetAllSellerSrc(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getallservey
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getallservey([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetAllServey();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getalllandclass
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getalllandclass([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetAllLandClass();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getalllanddeed
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getalllanddeed([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetAllLandDeed(arr);
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getalllandproject
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getalllandproject([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetAllLandProject();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getalllandcategories
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getalllandcategories([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetAllLandCategories();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getalllandsubcategories
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getalllandsubcategories([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                dynamic data = JsonConvert.DeserializeObject(param);
                object[] arr = JsonConvert.DeserializeObject<object[]>(data.ToString());
                resdata = await _manager.GetAllLandSubCategories();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }


        //CASE START FROM HERE 
        // GET: api/dropdown/getallcasetype
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getallcasetype([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                resdata = await _manager.GetAllCaseType();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getallcourt
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getallcourt([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                resdata = await _manager.GetAllCourt();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getallcasestatus
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getallcasestatus([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                resdata = await _manager.GetAllCaseStatus();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        // GET: api/dropdown/getallcasepriority
        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getallcasepriority([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                resdata = await _manager.GetAllCasePriority();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getalladvocate([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                resdata = await _manager.GetAllAdvocate();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }


        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getallhearingevent([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                resdata = await _manager.GetAllHearingEvent();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }

        [HttpGet("[action]")]//, BasicAuthorization
        public async Task<object> getallpurchars([FromQuery] string param)
        {
            object resdata = null;
            try
            {
                resdata = await _manager.GetAllPurchars();
            }
            catch (Exception) { }
            return new
            {
                resdata
            };
        }


        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> saveupdatecaseevent([FromBody] object[] data)
        {
            object resdata = null;
            try
            {
                if (!string.IsNullOrEmpty(data.ToString()))
                {
                    resdata = await _manager.SaveCaseHearingEvnt(data);
                }
            }
            catch (Exception) { }

            return new
            {
                resdata
            };
        }

        [HttpPost("[action]")]//BasicAuthorization
        public async Task<object> saveupdatecasecourt([FromBody] object[] data)
        {
            object resdata = null;
            try
            {
                if (!string.IsNullOrEmpty(data.ToString()))
                {
                    resdata = await _manager.SaveCaseCort(data);
                }
            }
            catch (Exception) { }

            return new
            {
                resdata
            };
        }


        //CASE END HERE






    }
}