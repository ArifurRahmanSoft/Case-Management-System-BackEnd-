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
    public class DeedMgt
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
            string listDeed = string.Empty;
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
                    { "IsPosted", (6, param.strId4) },
                    { "SearchValue", (7, param.SearchVal) }
                };

                listDeed = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_DeedByPage, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                listDeed
            };
        }

        public async Task<object> GetByID(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            string objDeed = string.Empty, objDoc = string.Empty, objViaDeed = string.Empty, objOwner = string.Empty, objSeller = string.Empty, objSubCat = string.Empty;
            try
            {
                Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();

                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("gId", OracleDbType.Varchar2).Value = param.strId;

                objDeed = await Ora_Generic_vmCmnParameter.ExecuteDataTableToJSON(StoredProcedure.SpGet_DeedByIds, ocmd, StaticInfos.conStringOracle.ToString());
                objViaDeed = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_ViaDeedById, ocmd, StaticInfos.conStringOracle.ToString());
                objDoc = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_DocumentById, ocmd, StaticInfos.conStringOracle.ToString());
                objOwner = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_OwnerByDeedId, ocmd, StaticInfos.conStringOracle.ToString());
                objSeller = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_SellerByDeedId, ocmd, StaticInfos.conStringOracle.ToString());
                objSubCat = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_SubCategoryByDeedId, ocmd, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex);
            }

            return new
            {
                objDeed,
                objViaDeed,
                objDoc,
                objOwner,
                objSeller,
                objSubCat
            };
        }

        public async Task<object> GetByIDForSetLocation(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            string objDeed = string.Empty, objDoc = string.Empty, objViaDeed = string.Empty, objOwner = string.Empty, objSeller = string.Empty, objSubCat = string.Empty;
            try
            {
                Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();

                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("gId", OracleDbType.Varchar2).Value = param.strId;

                objDeed = await Ora_Generic_vmCmnParameter.ExecuteDataTableToJSON(StoredProcedure.SpGet_DeedByIdForLoc, ocmd, StaticInfos.conStringOracle.ToString());
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

        public async Task<object> GetReportDataByID(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[1].ToString());
            string objDeed = string.Empty, objViaDeed=string.Empty, objDoc = string.Empty, objOwner = string.Empty, objSeller = string.Empty;
            try
            {
                Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("gId", OracleDbType.Varchar2).Value = param.strId;

                objDeed = await Ora_Generic_vmCmnParameter.ExecuteDataTableToJSON(StoredProcedure.SpGet_DeedReportsById, ocmd, StaticInfos.conStringOracle.ToString());
                objViaDeed = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_ViaDeedById, ocmd, StaticInfos.conStringOracle.ToString());
                objDoc = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_DocumentReportById, ocmd, StaticInfos.conStringOracle.ToString());
                objOwner = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_OwnerReportByDeedId, ocmd, StaticInfos.conStringOracle.ToString());
                objSeller = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_SellerReportByDeedId, ocmd, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex);
            }

            return new
            {
                objDeed,
                objViaDeed,
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

        public async Task<object> DeleteBak(object[] data)
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
                            var delmodel = await _ctxOra.TLandDeeds.Where(x => x.Oid == param.strId).FirstOrDefaultAsync();
                            delmodel.Iscancel = Extension.BoolVal(true);
                            delmodel.Cancelpc = Extension.Createpc();
                            delmodel.Cancelby = param.LoggedUserId;
                            delmodel.Cancelon = Extension.Today;

                            var delOwnerList = await _ctxOra.TLandPurchasers.Where(x => x.DeedId == param.strId).ToArrayAsync();
                            _ctxOra.TLandPurchasers.RemoveRange(delOwnerList);

                            var delSellerList = await _ctxOra.TLandSellers.Where(x => x.DeedId == param.strId).ToArrayAsync();
                            _ctxOra.TLandSellers.RemoveRange(delSellerList);

                            var delDocumentList = await _ctxOra.TCmndocuments.Where(x => x.Referenceid == param.strId).ToArrayAsync();

                            foreach (var delDoc in delDocumentList)
                            {
                                delDoc.Iscancel = Extension.BoolVal(true);
                                delDoc.Cancelpc = Extension.Createpc();
                                delDoc.Cancelby = param.LoggedUserId;
                                delDoc.Cancelon = Extension.Today;

                                if (File.Exists(delDoc.Documentfullpath))
                                {
                                    File.Delete(delDoc.Documentfullpath);
                                }
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

        public async Task<object> Delete(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            string message = string.Empty; bool resstate = false;
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string result = string.Empty;
            try
            {
                List<TCmndocument> delDocumentList = new();
                using (_ctxOra = new ModelContext())
                {
                    delDocumentList = await _ctxOra.TCmndocuments.Where(x => x.Referenceid == param.strId).ToListAsync();
                }

                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("gId", OracleDbType.Varchar2).Value = param.strId;
                ocmd.Parameters.Add("mCancelBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                ocmd.Parameters.Add("mCancelPC", OracleDbType.Varchar2).Value = Extension.Createpc();

                result = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpGet_DeedCancelByDeedId, ocmd, "gresult", StaticInfos.conStringOracle.ToString());
                if (!string.IsNullOrEmpty(result) && result != "0")
                {
                    message = MessageConstants.Saved;
                    resstate = MessageConstants.SuccessState;

                    foreach (var delDoc in delDocumentList)
                    {
                        if (File.Exists(delDoc.Documentfullpath))
                        {
                            File.Delete(delDoc.Documentfullpath);
                        }
                    }
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

        /// <summary>
        /// Both insert and update can perform by CmnUserRole model in database using asynchronous operation. when id is more than 0 update is performed otherwise insert. it returns an object as status of success or failure.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<object> SaveUpdate(IFormFileCollection allDocs, object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            string _JsonDataDeed = data[1].ToString();
            string _JsonDataReceiver = data[3].ToString();
            string _JsonDataSender = data[4].ToString();
            string _JsonDataBayaDeed = data[5].ToString();
            string _JsonDataServeyNo = data[6].ToString();
            string message = string.Empty; bool resstate = false;
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string result = string.Empty; object docSave = null; bool isDocUp = false;
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("JsonData", OracleDbType.Clob).Value = _JsonDataDeed;
                ocmd.Parameters.Add("JsonData_Owner", OracleDbType.Clob).Value = _JsonDataReceiver;
                ocmd.Parameters.Add("JsonData_Seller", OracleDbType.Clob).Value = _JsonDataSender;
                ocmd.Parameters.Add("JsonData_BayaDeed", OracleDbType.Clob).Value = _JsonDataBayaDeed;
                ocmd.Parameters.Add("JsonData_ServeyNo", OracleDbType.Clob).Value = _JsonDataServeyNo;
                ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();

                result = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpSetPut_Deed, ocmd, "gresult", StaticInfos.conStringOracle.ToString());
                if (!string.IsNullOrEmpty(result) && result != "0")
                {
                    message = result == "-1" ? "Deed already exists!!!" : MessageConstants.Saved;
                    resstate = MessageConstants.SuccessState;
                    if (result != "-1")
                    {
                        docSave = await SaveUpdateFiles(allDocs, data, result);
                        dynamic res = docSave;
                        isDocUp = res.resstate;
                    }
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

        public async Task<object> SetDeedLocation(object[] data)
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
                            var setmodel = await _ctxOra.TLandDeeds.Where(x => x.Oid == param.strId).FirstOrDefaultAsync();
                            setmodel.Latitude = param.strId2;
                            setmodel.Longitude = param.strId3;

                            await _ctxOra.SaveChangesAsync();
                            _ctxOraTran.Commit();
                            message = MessageConstants.Updated;
                            resstate = MessageConstants.SuccessState;
                        }
                    }
                    catch (Exception ex)
                    {
                        _ctxOraTran.Rollback();
                        //Logs.WriteBug(ex);
                        message = MessageConstants.UpdateWarning;
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

        public async Task<object> SaveUpdateN(IFormFileCollection allDocs, object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            string _JsonDataDeed = data[1].ToString();
            string _JsonDataReceiver = data[3].ToString();
            string _JsonDataSender = data[4].ToString();
            string _JsonDataBayaDeed = data[5].ToString();
            string _JsonDataServeyNo = data[6].ToString();
            string _JsonDataViaDeed = data[7].ToString();
            string message = string.Empty; bool resstate = false;
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string result = string.Empty; object docSave = null; bool isDocUp = false;
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("JsonData", OracleDbType.Clob).Value = _JsonDataDeed;
                ocmd.Parameters.Add("JsonData_ViaDeed", OracleDbType.Clob).Value = _JsonDataViaDeed;
                ocmd.Parameters.Add("JsonData_Owner", OracleDbType.Clob).Value = _JsonDataReceiver;
                ocmd.Parameters.Add("JsonData_Seller", OracleDbType.Clob).Value = _JsonDataSender;
                ocmd.Parameters.Add("JsonData_BayaDeed", OracleDbType.Clob).Value = _JsonDataBayaDeed;
                ocmd.Parameters.Add("JsonData_ServeyNo", OracleDbType.Clob).Value = _JsonDataServeyNo;
                ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();

                result = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpSetPut_Deed_New, ocmd, "gresult", StaticInfos.conStringOracle.ToString());
                if (!string.IsNullOrEmpty(result) && result != "0")
                {
                    message = result == "-1" ? "Deed already exists!!!" : MessageConstants.Saved;
                    resstate = MessageConstants.SuccessState;
                    if (result != "-1")
                    {
                        docSave = await SaveUpdateFiles(allDocs, data, result);
                        dynamic res = docSave;
                        isDocUp = res.resstate;
                    }
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

        public async Task<object> SaveUpdateFiles(IFormFileCollection allDocs, object[] data, string deedId)
        {
            object result = null, docSave = null; string message = string.Empty; bool resstate = false;
            List<vmCmnDocument> documentList = JsonConvert.DeserializeObject<List<vmCmnDocument>>(data[2].ToString());
            List<vmCmnDocument> ndocList = new List<vmCmnDocument>();
            vmCmnDocument ndoc = null;

            string referenceId = deedId;
            string filePath = documentList[0].documentPath;
            string basePath = "E:/DMS/landdoc/";
            string newPath = basePath + filePath;
            string _newPath = newPath.ToString().Replace(@"\", @"/");

            //Virtual Directory
            string vIpAdd = StaticInfos.IsLive ? "https://app.citygroupbd.com/uploadFiles" : "http://192.168.61.246";
            string vPort = StaticInfos.IsLive ? "/landdoc" : "84";
            string vPath = StaticInfos.IsLive ? vIpAdd + vPort : vIpAdd + ":" + vPort;
            //Virtual Directory

            int totalfile = allDocs.Count;
            foreach (var docInfo in documentList)
            {
                IFormFile docFile = null;
                if (totalfile > 0)
                {
                    docFile = allDocs.Where(x => x.FileName == docInfo.originalDocName).FirstOrDefault();
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
                        fileName = fileName.Replace("/", "_");
                        string fullPath = Path.Combine(_newPath, fileName);

                        if (docInfo.documentId == 0)
                        {
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                docFile.CopyTo(stream);

                                ndoc = new vmCmnDocument();
                                ndoc.documentId = docInfo.documentId;
                                ndoc.referenceId = referenceId;
                                ndoc.inputName = docInfo.inputName;
                                ndoc.inputNumber = docInfo.inputNumber;
                                ndoc.inputTypeId = docInfo.inputTypeId;
                                ndoc.inputType = docInfo.inputType;
                                ndoc.inputOthers = docInfo.inputOthers;
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
                        else
                        {
                            if (docInfo.isCancel)
                            {
                                if (File.Exists(docInfo.documentFullPath))
                                {
                                    File.Delete(docInfo.documentFullPath);
                                }
                            }
                        }
                    }
                }
                else
                {
                    ndoc = new vmCmnDocument();
                    ndoc.documentId = docInfo.documentId;
                    ndoc.referenceId = referenceId;
                    ndoc.inputName = docInfo.inputName;
                    ndoc.inputNumber = docInfo.inputNumber;
                    ndoc.inputTypeId = docInfo.inputTypeId;
                    ndoc.inputType = docInfo.inputType;
                    ndoc.inputOthers = docInfo.inputOthers;
                    ndoc.originalDocName = docInfo.originalDocName;
                    ndoc.documentName = docInfo.documentName;
                    ndoc.documentType = docInfo.documentType;
                    ndoc.documentSize = docInfo.documentSize;
                    ndoc.basePath = docInfo.basePath;
                    ndoc.documentPath = docInfo.documentPath;
                    ndoc.documentFullPath = docInfo.documentFullPath;
                    ndoc.virtualPath = docInfo.virtualPath;
                    ndoc.remarks = docInfo.remarks;
                    ndoc.isActive = docInfo.isActive;
                    ndoc.isCancel = docInfo.isCancel;
                    ndoc.createBy = docInfo.createBy;
                    ndocList.Add(ndoc);

                    if (docInfo.isCancel)
                    {
                        if (File.Exists(docInfo.documentFullPath))
                        {
                            File.Delete(docInfo.documentFullPath);
                        }
                    }
                }
            }

            if (ndocList.Count > 0)
            {
                docSave = await SaveUpdateDoc(ndocList);
                dynamic res = docSave;
                message = res.message;
                resstate = res.resstate;
            }

            return result = new
            {
                message,
                resstate
            };
        }

        public async Task<object> SaveUpdateDoc(List<vmCmnDocument> docList)
        {
            object result = null; string message = string.Empty; bool resstate = false;
            using (_ctxOra = new ModelContext())
            {
                using (var _ctxOraTransaction = _ctxOra.Database.BeginTransaction())
                {
                    try
                    {
                        List<TCmndocument> ndocList = new List<TCmndocument>();
                        List<TCmndocument> udocList = new List<TCmndocument>();
                        var MaxID = _ctxOra.TCmndocuments.DefaultIfEmpty().Max(x => x == null ? 0 : x.Documentid) + 1;
                        foreach (var docFile in docList)
                        {
                            if (docFile.documentId > 0)
                            {
                                var udoc = await _ctxOra.TCmndocuments.FirstOrDefaultAsync(x => x.Documentid == docFile.documentId);
                                //docFile.DocumentId = Convert.ToInt32(udoc.Documentid);

                                udoc.Referenceid = docFile.referenceId;
                                udoc.Inputname = docFile.inputName;
                                udoc.Inputnumber = docFile.inputNumber;
                                udoc.InputtypeId = docFile.inputTypeId;
                                udoc.Inputtype = docFile.inputType;
                                udoc.Inputothers = docFile.inputOthers;
                                udoc.Originaldocname = docFile.originalDocName;
                                udoc.Documentname = docFile.documentName;
                                udoc.Documenttype = docFile.documentType;
                                udoc.Documentsize = docFile.documentSize;

                                udoc.Documentpath = docFile.documentPath;
                                udoc.Basepath = docFile.basePath;
                                udoc.Documentfullpath = docFile.documentFullPath;
                                udoc.Virtualpath = docFile.virtualPath;
                                udoc.Remarks = docFile.remarks;

                                udoc.Isactive = Extension.BoolVal(docFile.isActive);
                                udoc.Iscancel = Extension.BoolVal(docFile.isCancel);
                                //Common
                                udoc.Updatepc = Extension.Createpc();
                                udoc.Updateby = docFile.createBy;
                                udoc.Updateon = Extension.Today;

                                udocList.Add(udoc);
                            }
                            else
                            {
                                //docFile.DocumentId = Convert.ToInt32(MaxID);
                                var ndoc = new TCmndocument();
                                ndoc.Documentid = MaxID;
                                ndoc.Referenceid = docFile.referenceId;
                                ndoc.Inputname = docFile.inputName;
                                ndoc.Inputnumber = docFile.inputNumber;
                                ndoc.InputtypeId = docFile.inputTypeId;
                                ndoc.Inputtype = docFile.inputType;
                                ndoc.Inputothers = docFile.inputOthers;
                                ndoc.Originaldocname = docFile.originalDocName;
                                ndoc.Documentname = docFile.documentName;
                                ndoc.Documenttype = docFile.documentType;
                                ndoc.Documentsize = docFile.documentSize;

                                ndoc.Documentpath = docFile.documentPath;
                                ndoc.Basepath = docFile.basePath;
                                ndoc.Documentfullpath = docFile.documentFullPath;
                                ndoc.Virtualpath = docFile.virtualPath;
                                ndoc.Remarks = docFile.remarks;

                                ndoc.Isactive = Extension.BoolVal(docFile.isActive);
                                ndoc.Iscancel = Extension.BoolVal(docFile.isCancel);

                                //Common
                                ndoc.Createpc = Extension.Createpc();
                                ndoc.Createby = docFile.createBy;
                                ndoc.Createon = Extension.Today;

                                ndocList.Add(ndoc);

                                MaxID++;
                            }
                        }

                        if (ndocList.Count > 0)
                        {
                            await _ctxOra.TCmndocuments.AddRangeAsync(ndocList);
                        }

                        await _ctxOra.SaveChangesAsync();
                        message = MessageConstants.FileSuccess;

                        _ctxOraTransaction.Commit();
                        resstate = MessageConstants.SuccessState;
                    }
                    catch (Exception ex)
                    {
                        _ctxOraTransaction.Rollback();
                        //Logs.WriteBug(ex);
                        message = MessageConstants.FileError;
                        resstate = MessageConstants.ErrorState;
                    }
                }
            }
            return result = new
            {
                //docList,
                message,
                resstate
            };
        }

        public async Task<object> InsertJsonData(object[] data)
        {
            string _JsonData = data[0].ToString();
            string message = string.Empty; bool resstate = false;
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string result = string.Empty;
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("JsonData", OracleDbType.Clob).Value = _JsonData;

                result = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpInsert_JSON_DATA, ocmd, "gresult", StaticInfos.conStringOracle.ToString());
                if (!string.IsNullOrEmpty(result) && result != "0")
                {
                    message = result == "-1" ? "Deed already exists!!!" : MessageConstants.Saved;
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