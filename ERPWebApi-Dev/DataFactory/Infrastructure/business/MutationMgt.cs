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
    public class MutationMgt
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
            string listMutation = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "PageNumber", (1, Convert.ToDecimal(param.pageNumber))},
                    { "PageSize", (2, Convert.ToDecimal(param.pageSize)) },
                    { "DistrictId", (3, param.strId) },
                    { "ThanaId", (4, param.strId2) },
                    { "MouzaId", (5, param.strId3) },
                    { "SearchValue", (6, param.SearchVal) }
                };

                listMutation = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_MutationByPage, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                listMutation
            };
        }

        public async Task<object> GetByID(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            string objMutation = string.Empty;
            try
            {
                Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "gId", (1, param.strId)}
                };

                objMutation = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_MutationById, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex);
            }

            return new
            {
                objMutation
            };
        }

        public async Task<object> GetReportDataByID(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[1].ToString());
            string objDeed = string.Empty, objDoc = string.Empty, objOwner = string.Empty, objSeller = string.Empty;
            try
            {
                Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "gId", (1, param.strId)}
                };

                objDeed = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_DeedReportById, ht, StaticInfos.conStringOracle.ToString());
                objDoc = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_DocumentReportById, ht, StaticInfos.conStringOracle.ToString());
                objOwner = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_OwnerReportByDeedId, ht, StaticInfos.conStringOracle.ToString());
                objSeller = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_SellerReportByDeedId, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex);
            }

            return new
            {
                objDeed,
                objDoc,
                objOwner,
                objSeller
            };
        }

        public async Task<object> GetDocumentByID(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            string objDeed = string.Empty;
            try
            {
                Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
                ht = new Hashtable
                {
                    { "gId", param.id }
                };

                objDeed = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_DocumentById, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex);
            }

            return new
            {
                objDeed
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
                            var delmodel = await _ctxOra.TLandMutations.Where(x => x.Oid == param.strId).FirstOrDefaultAsync();
                            delmodel.Iscancel = Extension.BoolVal(true);
                            delmodel.Cancelpc = Extension.Createpc();
                            delmodel.Cancelby = param.LoggedUserId;
                            delmodel.Cancelon = Extension.Today;

                            var delmdag = await _ctxOra.TMutationWiseDags.Where(x => x.MutationId == param.strId).ToListAsync();
                            foreach (var item in delmdag)
                            {
                                item.Iscancel = Extension.BoolVal(true);
                                item.Cancelpc = Extension.Createpc();
                                item.Cancelby = param.LoggedUserId;
                                item.Cancelon = Extension.Today;
                            }

                            var delmdeed = await _ctxOra.TMutationWiseDeeds.Where(x => x.MutationId == param.strId).ToListAsync();

                            foreach (var item in delmdeed)
                            {
                                item.Iscancel = Extension.BoolVal(true);
                                item.Cancelpc = Extension.Createpc();
                                item.Cancelby = param.LoggedUserId;
                                item.Cancelon = Extension.Today;
                            }

                            var delmcls = await _ctxOra.TMutationWiseLandClasses.Where(x => x.MutationId == param.strId).ToListAsync();

                            foreach (var item in delmcls)
                            {
                                item.Iscancel = Extension.BoolVal(true);
                                item.Cancelpc = Extension.Createpc();
                                item.Cancelby = param.LoggedUserId;
                                item.Cancelon = Extension.Today;
                            }
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

        /// <summary>
        /// Both insert and update can perform by CmnUserRole model in database using asynchronous operation. when id is more than 0 update is performed otherwise insert. it returns an object as status of success or failure.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<object> SaveUpdateFiles(IFormFileCollection allDocs, object[] datas, string rootPath)
        {
            object docSave = null; string message = string.Empty; bool resstate = false;
            dynamic data = JsonConvert.DeserializeObject(datas[1].ToString());
            string mutationId = data.mutationId;
            string filePath = data.basePath;
            string docPath = data.docPath;
            string docVPath = data.docVpath;
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

                    if (!string.IsNullOrEmpty(mutationId))
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
            string _JsonDataDeed = data[2].ToString();
            string _JsonDataLandClass = data[3].ToString();
            string _JsonDataDag = data[4].ToString();            
            string message = string.Empty; bool resstate = false;
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string result = string.Empty;
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("JsonData", OracleDbType.Clob).Value = _JsonData;
                ocmd.Parameters.Add("JsonData_Deed", OracleDbType.Clob).Value = _JsonDataDeed;
                ocmd.Parameters.Add("JsonData_Dag", OracleDbType.Clob).Value = _JsonDataDag;
                ocmd.Parameters.Add("JsonData_LandClass", OracleDbType.Clob).Value = _JsonDataLandClass;
                ocmd.Parameters.Add("mDocVrPath", OracleDbType.Varchar2).Value = docVrPath;
                ocmd.Parameters.Add("mDocPath", OracleDbType.Varchar2).Value = docPath;
                ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();

                result = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpSetPut_Mutation, ocmd, "gresult", StaticInfos.conStringOracle.ToString());
                if (!string.IsNullOrEmpty(result) && result != "0")
                {
                    message = result == "-1" ? "Mutation already exists!!!" : MessageConstants.Saved;
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
        #endregion
    }
}