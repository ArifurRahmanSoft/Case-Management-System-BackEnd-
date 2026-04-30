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
    public class DocUploadMgt
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
            string listDocUpload = string.Empty;
            try
            {
                string mouzaId = string.IsNullOrEmpty(param.strId) || param.strId == "0" ? null : param.strId;
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "PageNumber", (1, Convert.ToDecimal(param.pageNumber))},
                    { "PageSize", (2, Convert.ToDecimal(param.pageSize)) },
                    { "BasePath", (3, param.Path) },
                    { "MouzaId", (4, mouzaId) },
                    { "SearchValue", (5, param.SearchVal) }
                };

                listDocUpload = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_ExtDocumentByPage, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                listDocUpload
            };
        }

        public async Task<object> GetByID(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            string objDoc = string.Empty;
            try
            {
                Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "gId", (1, param.id)}
                };

                objDoc = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_ExtDocumentById, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex);
            }

            return new
            {
                objDoc
            };
        }

        public async Task<object> SaveUpdateFiles(IFormFileCollection allDocs, object[] datas)
        {
            object docSave = null; string message = string.Empty; bool resstate = false;
            _ctxOra = new ModelContext();
            //dynamic data = JsonConvert.DeserializeObject(datas[0].ToString());
            List<vmCmnDocument> documentList = JsonConvert.DeserializeObject<List<vmCmnDocument>>(datas[1].ToString());
            List<vmCmnDocument> ndocList = new List<vmCmnDocument>();
            vmCmnDocument ndoc = null;
            //string referenceId = data.id;
            string filePath = documentList[0].basePath;
            string docPath = documentList[0].documentPath;
            string docVPath = documentList[0].virtualPath;
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
            vmCmnDocument docInfo = documentList.FirstOrDefault();
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

                    if (docInfo.documentId > 0)
                    {
                        TCmnDocumentUpload exdoc = _ctxOra.TCmnDocumentUploads.Where(x => x.Documentid == docInfo.documentId).FirstOrDefault();

                        if (File.Exists(exdoc.Documentfullpath))
                        {
                            File.Delete(exdoc.Documentfullpath);
                        }

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

                    ndoc = new vmCmnDocument();
                    ndoc.documentId = docInfo.documentId;
                    ndoc.referenceId = docInfo.referenceId;
                    ndoc.originalDocName = originalFileName;
                    ndoc.documentName = fileName;
                    ndoc.documentType = docFile.ContentType;
                    ndoc.documentSize = docFile.Length;
                    ndoc.basePath = basePath;
                    ndoc.documentPath = filePath;
                    ndoc.documentFullPath = fullPath;
                    ndoc.virtualPath = vPath + filePath + "/" + fileName;
                    ndoc.remarks = docInfo.remarks;
                    ndoc.isActive = docInfo.isActive;
                    ndoc.isCancel = docInfo.isCancel;
                    ndoc.createBy = docInfo.createBy;
                    ndocList.Add(ndoc);
                }
            }

            docSave = await SaveUpdate(datas, ndocList);
            dynamic res = docSave;
            message = res.message;
            resstate = res.resstate;

            return new
            {
                message,
                resstate
            };
        }

        public async Task<object> SaveUpdate(object[] data, List<vmCmnDocument> ndocList)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            string _JsonData = JsonConvert.SerializeObject(ndocList);
            string message = string.Empty; bool resstate = false;
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string result = string.Empty;
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("JsonData", OracleDbType.Clob).Value = _JsonData;
                ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();

                result = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpSetPut_ExtDocument, ocmd, "gresult", StaticInfos.conStringOracle.ToString());
                if (!string.IsNullOrEmpty(result) && result != "0")
                {
                    message = result == "-1" ? "Document already exists!!!" : MessageConstants.Saved;
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
                        if (param.id > 0)
                        {
                            var delmodel = await _ctxOra.TCmnDocumentUploads.Where(x => x.Documentid == param.id).FirstOrDefaultAsync();
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