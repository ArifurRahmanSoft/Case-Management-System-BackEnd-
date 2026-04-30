using DataFactory.AllServiceClasses;
using DataFactory.BaseFactory;
using DataModels.EntityModels.OraModel;
using DataModels.ViewModels;
using DataModels.ViewModels.ERPViewModel.Common;
using DataUtilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataFactory.Infrastructure.business.operation
{
    public class MouzaSetupMgt
    {
        #region Variable declaration & initialization
        Hashtable ht = null;
        OracleCommand ocmd = null;
        IGenericFactoryOracle<vmCmnParameter> Ora_Generic_vmCmnParameter = null;
        ModelContext _ctxOra = null;
        #endregion

        #region All Methods
        public async Task<object> GetByPage(object[] data) //vmCmnParameters cmnParam
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listMouza = string.Empty;
            try
            {
                int DistrictId = string.IsNullOrEmpty(param.strId) ? 0 : Convert.ToInt32(param.strId);
                int ThanaId = string.IsNullOrEmpty(param.strId2) ? 0 : Convert.ToInt32(param.strId2);
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "PageNumber", (1, Convert.ToDecimal(param.pageNumber))},
                    { "PageSize", (2, Convert.ToDecimal(param.pageSize)) },
                    { "DistrictId", (3, DistrictId) },
                    { "ThanaId", (4, ThanaId) },
                    { "SearchValue", (5, param.SearchVal) }
                };

                listMouza = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_MouzaByPage, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                listMouza
            };
        }

        public async Task<object> GetByID(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            string objMouza = string.Empty, objDoc = string.Empty;
            try
            {
                Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "gId", (1, param.strId)}
                };

                objMouza = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_MouzaById, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex);
            }

            return new
            {
                objMouza,
                objDoc
            };
        }

        public async Task<object> SaveUpdateFiles(IFormFileCollection allDocs, object[] datas, string rootPath)
        {
            object docSave = null; string message = string.Empty; bool resstate = false;
            dynamic data = JsonConvert.DeserializeObject(datas[1].ToString());
            string mouzaId = data.id;
            string filePath = data.basePath;
            string docPath = data.logoPath;
            string docVPath = data.logoVpath;
            //string basePath = StaticInfos.IsLive ? "C:/UploadFile/" : "E:/UploadFile/";
            string basePath = "E:/DMS/landdoc/";
            string newPath = basePath + filePath;
            string _newPath = newPath.ToString().Replace(@"\", @"/");

            //Virtual Directory
            string vIpAdd = StaticInfos.IsLive ? "https://app.citygroupbd.com/uploadFiles" : "http://192.168.61.246";
            string vPort = StaticInfos.IsLive ? "/landdoc" : "84";
            string vPath = StaticInfos.IsLive ? vIpAdd + vPort : vIpAdd + ":" + vPort;
            string docVrPath = docVPath;
            string fullPath = docPath;
            //Virtual Directory

            int totalfile = allDocs.Count;
            IFormFile docFile = null;
            if (totalfile > 0)
            {
                docFile = allDocs[0];
            }

            if (docFile != null)
            {
                if (!Directory.Exists(_newPath))
                {
                    Directory.CreateDirectory(_newPath);
                }

                if (docFile.Length > 0)
                {
                    string originalFileName = ContentDispositionHeaderValue.Parse(docFile.ContentDisposition).FileName.Trim('"');
                    var newFileName = Extension.UtcToday.ToString("yyyyMMddHHmmssfff");
                    var arrayExtens = originalFileName.Split(".");
                    var exten = arrayExtens[arrayExtens.Length - 1];
                    string fileName = originalFileName.Substring(0, originalFileName.Length - (exten.Length + 1)) + "_" + newFileName + "." + exten;
                    docVrPath = vPath.Trim() + filePath + "/" + fileName;
                    fullPath = Path.Combine(_newPath, fileName);

                    if (!string.IsNullOrEmpty(mouzaId))
                    {
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            docFile.CopyTo(stream);
                        }
                    }
                    else
                    {
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            docFile.CopyTo(stream);
                        }
                    }
                }
            }

            docSave = await SaveUpdate(datas, docVrPath, fullPath);
            dynamic res = docSave;
            message = res.message;
            resstate = res.resstate;

            return new
            {
                message,
                resstate
            };
        }

        public async Task<object> SaveUpdate(object[] data, string docVrPath, string docPath)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            string _JsonData = data[1].ToString();
            string message = string.Empty; bool resstate = false;
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string result = string.Empty;
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("JsonData", OracleDbType.Clob).Value = _JsonData;
                ocmd.Parameters.Add("mDocVrPath", OracleDbType.Varchar2).Value = docVrPath;
                ocmd.Parameters.Add("mDocPath", OracleDbType.Varchar2).Value = docPath;
                ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();

                result = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpSetPut_Mouza, ocmd, "gresult", StaticInfos.conStringOracle.ToString());
                if (!string.IsNullOrEmpty(result) && result != "0")
                {
                    message = result == "-1" ? "Mouza already exists!!!" : MessageConstants.Saved;
                    resstate = MessageConstants.SuccessState;
                }
                else
                {
                    message = MessageConstants.SavedWarning;
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                result,
                message,
                resstate
            };
        }

        public async Task<object> Delete(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            object result = null; string message = string.Empty; bool resstate = false;
            using (_ctxOra = new ModelContext())
            {
                using (var _ctxOraTran = await _ctxOra.Database.BeginTransactionAsync())
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(param.strId))
                        {
                            var delmodel = await _ctxOra.TMouzas.Where(x => x.Oid == param.strId).FirstOrDefaultAsync();
                            delmodel.Iscancel = Extension.BoolVal(true);
                            delmodel.Cancelpc = Extension.Createpc();
                            delmodel.Cancelby = param.LoggedUserId;
                            delmodel.Cancelon = Extension.Today;
                        }

                        await _ctxOra.SaveChangesAsync();
                        _ctxOraTran.Commit();
                        message = MessageConstants.Deleted;
                        resstate = MessageConstants.SuccessState;
                    }
                    catch (Exception ex)
                    {
                        _ctxOraTran.Rollback();
                        //Logs.WriteBug(ex);
                        message = MessageConstants.DeletedWarning;
                        resstate = MessageConstants.ErrorState;
                    }
                }
            }

            return result = new
            {
                message,
                resstate
            };
        }

        #endregion
    }
}