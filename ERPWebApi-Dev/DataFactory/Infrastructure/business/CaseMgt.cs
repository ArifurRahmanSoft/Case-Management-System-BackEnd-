using DataFactory.AllServiceClasses;
using DataFactory.BaseFactory;
using DataModels.EntityModels.OraModel;
using DataModels.ViewModels;
using DataModels.ViewModels.ERPViewModel.Common;
using DataUtilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataFactory.Infrastructure.business.operation
{
    public class CaseMgt
    {
        #region Variable declaration & initialization
        Hashtable ht = null;
        OracleCommand ocmd = null;
        IGenericFactoryOracle<vmCmnParameter> Ora_Generic_vmCmnParameter = null;
        ModelContext _ctxOra = null;
        #endregion

        #region All Methods

        public async Task<object> GetDeedByID(vmCmnParameter param)
        {
            string refr = string.Empty; object deedList = null;
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            try
            {
                //string Todats = Extension.Today.ToString("MMM/yyyy").ToUpper();
                string Todats = Extension.Today.ToString("ddMMyy").ToUpper();
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("gDistrictId", OracleDbType.Varchar2).Value = param.strId;
                ocmd.Parameters.Add("gThanaId", OracleDbType.Varchar2).Value = param.strId2;
                ocmd.Parameters.Add("gMouzaId", OracleDbType.Varchar2).Value = param.strId3;
                ocmd.Parameters.Add("gDag", OracleDbType.Varchar2).Value = param.strId4;
                ocmd.Parameters.Add("gDagName", OracleDbType.Varchar2).Value = param.strId5;

                //deedList = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpGet_AllDeedById, ocmd, "gresult", StaticInfos.conStringOracle.ToString());
                deedList = await Ora_Generic_vmCmnParameter.ExecuteDataTableToJSON(StoredProcedure.SpGet_AllDeedById, ocmd, StaticInfos.conStringOracle.ToString());



            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }

            return new
            {

                deedList
            };
        }

        public async Task<object> GetByID(vmCmnParameter cparam)
        {
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string caseMaster = string.Empty, objDoc = string.Empty, hearingDairy = string.Empty, AdvhearingDairy = string.Empty, termsCondition = string.Empty, documentList = string.Empty, objFlowDetail = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.Clob, ParameterDirection.Output) },
                    { "gCaseID", (1, OracleDbType.Varchar2, cparam.strId)}
                };
                caseMaster = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.SpGet_CaseGetById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                hearingDairy = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.SpGet_HearingGetById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                AdvhearingDairy = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.SpGet_AdvHearingGetById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                objDoc = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.SpGet_DocGetById, ht, "gresult", StaticInfos.conStringOracle.ToString());
                //objDoc = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_DocumentById, ocmd, StaticInfos.conStringOracle.ToString());


            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                caseMaster,
                hearingDairy,
                AdvhearingDairy,
                objDoc
            };
        }

        public async Task<object> GetByPage(object[] data) //vmCmnParameters cmnParam
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listCase = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "PageNumber", (1, Convert.ToDecimal(param.pageNumber))},
                    { "PageSize", (2, Convert.ToDecimal(param.pageSize)) },
                    { "SearchValue", (3, param.SearchVal) },
                    { "District", (4, param.strId) },
                    { "Thana", (5, param.strId2) },
                    { "Mouza", (6, param.strId3) },
                    { "Court", (7, param.strId4) },
                    { "caseCstatus", (8, param.strId5) },
                    { "CasePriority", (9, param.strId6) }

                };

                listCase = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_CaseListByPage, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                listCase
            };
        }

        public async Task<object> SaveUpdate(object[] data)
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
                ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();

                result = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpSet_CaseMster, ocmd, "gresult", StaticInfos.conStringOracle.ToString());
                if (!string.IsNullOrEmpty(result) && result != "0")
                {
                    message = result == "-1" ? "RegistryOffice already exists!!!" : MessageConstants.Saved;
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




   /*     public async Task<object> SaveUpdateForm(string _mJsonData, string jsonData_Hearing, string jsonData_Adv_Hearing, IFormFileCollection allDocs, vmCmnParameter param)
        {
    
            string message = string.Empty; bool resstate = false;
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string result = string.Empty; string hearing = string.Empty; string adv_hearing = string.Empty;
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("JsonData", OracleDbType.Clob).Value = _mJsonData;
                ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();

                result = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpSet_CaseMster, ocmd, "gresult", StaticInfos.conStringOracle.ToString());
               if (!string.IsNullOrEmpty(result) && result != "0")
                {
                    ocmd = new OracleCommand();
                    ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                    ocmd.Parameters.Add("Mstr_OID", OracleDbType.Varchar2).Value = result;
                    ocmd.Parameters.Add("JsonData_Dtl", OracleDbType.Clob).Value = jsonData_Hearing;
                    ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                    ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();

                    hearing = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpSet_CaseHearing, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                }
                if (!string.IsNullOrEmpty(result) && result != "0")
                {
                    ocmd = new OracleCommand();
                    ocmd.Parameters.Add("gresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                    ocmd.Parameters.Add("Mstr_OID", OracleDbType.Varchar2).Value = result;
                    ocmd.Parameters.Add("JsonData_Dtl", OracleDbType.Clob).Value = jsonData_Adv_Hearing;
                    ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                    ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();

                    adv_hearing = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpSet_CaseHearingAdvoacate, ocmd, "gresult", StaticInfos.conStringOracle.ToString());
                }
                if (!string.IsNullOrEmpty(result) && result != "0")
                {
                    message = result == "-1" ? " already exists!!!" : MessageConstants.Saved;
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
        } */
        
        public async Task<object> SaveUpdateForm(string _mJsonData, string jsonData_Hearing, string jsonData_Adv_Hearing, IFormFileCollection allDocs, vmCmnParameter param)
        { 
            string message = string.Empty; bool resstate = false;
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string result = string.Empty; string hearing = string.Empty; string adv_hearing = string.Empty; string upCase= string.Empty;
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("JsonData", OracleDbType.Clob).Value = _mJsonData;
                ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();
                result = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpSet_CaseMster, ocmd, "gresult", StaticInfos.conStringOracle.ToString());
                //result = "TLC000007";
               if (!string.IsNullOrEmpty(result) && result != "0")
                {
                    ocmd = new OracleCommand();
                    ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                    ocmd.Parameters.Add("Mstr_OID", OracleDbType.Varchar2).Value = result;
                    ocmd.Parameters.Add("JsonData_Dtl", OracleDbType.Clob).Value = jsonData_Hearing;
                    ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                    ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();
                    hearing = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpSet_CaseHearing, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                }
                if (!string.IsNullOrEmpty(result) && result != "0")
                {
                    ocmd = new OracleCommand();
                    ocmd.Parameters.Add("gresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                    ocmd.Parameters.Add("Mstr_OID", OracleDbType.Varchar2).Value = result;
                    ocmd.Parameters.Add("JsonData_Dtl", OracleDbType.Clob).Value = jsonData_Adv_Hearing;
                    ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                    ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();
                    adv_hearing = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpSet_CaseHearingAdvoacate, ocmd, "gresult", StaticInfos.conStringOracle.ToString());
                    //adv_hearing = "TLC000007";
                }

                if (!string.IsNullOrEmpty(adv_hearing) && adv_hearing != "0")
                {
                    ocmd = new OracleCommand();
                    ocmd.Parameters.Add("gresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                    ocmd.Parameters.Add("gCaseID", OracleDbType.Varchar2).Value = adv_hearing;

                    upCase = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpPut_CaseStatus, ocmd, "gresult", StaticInfos.conStringOracle.ToString());
                }



                    if (!string.IsNullOrEmpty(adv_hearing) && allDocs.Count > 0)
                {
                    var advHearingList = await getAdvHearingDetails(adv_hearing);
                    if (advHearingList != null && advHearingList.Count > 0)
                    {
                        await SaveUpdateFiles(allDocs, result, advHearingList);
                    }
                }

                if (!string.IsNullOrEmpty(result) && result != "0")
                {
                    message = result == "-1" ? " already exists!!!" : MessageConstants.Saved;
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


        public async Task<List<TCaseHearingAdvocate>> getAdvHearingDetails(string mstrOid)
        {
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    return await (from hearing in _ctxOra.TCaseHearingAdvocates
                                  where hearing.CaseOid == mstrOid
                                        && hearing.Iscancel == Extension.BoolVal(false)
                                  select new TCaseHearingAdvocate
                                  {
                                      Oid = hearing.Oid,
                                      RowNum = hearing.RowNum,
                                      CaseStatus=hearing.CaseStatus,
                                      CaseOid=hearing.CaseOid
                                  }).ToListAsync();
                }
            }
            catch
            {
                return new List<TCaseHearingAdvocate>();
            }
        }






        public async Task<object> SaveUpdateFiles(
                IFormFileCollection fileCollection, string caseOid,  List<TCaseHearingAdvocate> datas)
        {
            //ApiResponse response = new ApiResponse();

            int passcount = 0;
            int errorCount = 0;
            _ctxOra = new ModelContext();
            dynamic responses = "";
            List<decimal> documentIds = new List<decimal>();

            string basePath = "E:/DMS/CITYLAND/";
            string _newPath = basePath.Replace(@"\", @"/");
            string caseId = caseOid;

            string vIpAdd = StaticInfos.IsLive ? "https://app.citygroupbd.com/uploadFiles" : "http://192.168.64.72";
            string vPort = StaticInfos.IsLive ? "/CITYLAND/" : "84";
            string vPath = StaticInfos.IsLive ? vIpAdd + vPort : vIpAdd + ":" + vPort;
         
            var MaxID = (_ctxOra.TCaseHearingDocs.Any()? _ctxOra.TCaseHearingDocs.Max(x => x.Documentid): 0) + 1;

            try
            {
                if (!Directory.Exists(_newPath))
                {
                    Directory.CreateDirectory(_newPath);
                }
                if (fileCollection.Count > 0)
                {
                    foreach (var file in fileCollection)
                    {
                        if (file == null || file.Length == 0)
                            continue;

                        if (!int.TryParse(file.Name, out int fileIndex))
                            continue;

                        var matchData = datas
                          .FirstOrDefault(x => int.Parse(x.RowNum) == fileIndex);

                        if (matchData == null)
                            continue;
                        //NOW MATCH DATA SHOULD CHECK EXIST IN DOC TABLE. IF EXIST THEN UPDATE ELSE INSERT

                        string referenceOid = matchData.Oid;
                        var existingDocs = await _ctxOra.TCaseHearingDocs.FirstOrDefaultAsync(x => x.AdvHearingId == referenceOid);

                        if (file != null && file.Length > 0)
                        {
                            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                            string filePath = Path.Combine(_newPath, uniqueFileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }


                            if (existingDocs == null)
                            {
                                //INSERT DATA HERE 
                                var document = new TCaseHearingDoc
                                {
                                    Documentid = MaxID,
                                    CaseId = caseId,
                                    AdvHearingId = referenceOid,
                                    IndexNo = file.Name,
                                    Documentfullpath = filePath,
                                    Documentname = uniqueFileName,//file.Name, // original name
                                    Documenttype = file.ContentType,
                                    Documentsize = file.Length,
                                    Basepath = basePath,
                                    Documentpath = _newPath,
                                    Virtualpath = vPath + uniqueFileName
                                };

                                this._ctxOra.TCaseHearingDocs.Add(document);
                                await this._ctxOra.SaveChangesAsync();

                                 documentIds.Add(document.Documentid);
                                MaxID++;

                            }
                            else
                            {
                                //UPDATE DATA HERE
                                var existingDoc = await this._ctxOra.TCaseHearingDocs
                                        .FirstOrDefaultAsync(d => d.AdvHearingId == existingDocs.AdvHearingId);
                                //start delete
                                if (!string.IsNullOrEmpty(existingDoc.Virtualpath) && System.IO.File.Exists(existingDoc.Virtualpath))
                                {
                                    try
                                    {
                                        System.IO.File.Delete(existingDoc.Virtualpath);//Virtualpath Documentfullpath
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Failed to delete old file: {ex.Message}");
                                    }
                                }
                                //end delete 

                                existingDoc.Documentfullpath = filePath;
                                existingDoc.Documentname = uniqueFileName;// file.Name; 
                                existingDoc.Documenttype = file.ContentType;
                                existingDoc.Documentsize = file.Length;
                                existingDoc.Basepath = basePath;
                                existingDoc.Documentpath = _newPath;
                                existingDoc.Virtualpath = vPath + uniqueFileName;



                                this._ctxOra.TCaseHearingDocs.Update(existingDoc);
                                await this._ctxOra.SaveChangesAsync();

                                documentIds.Add(existingDoc.Documentid);
                            }
                        }


                        

                    }
                }
            }

            catch (Exception ex)
            {
                errorCount++;
                //response.Message = ex.Message;
            }

            //response.ResponseCode = 200;
            //response.Data = documentIds;
            //response.Result = passcount + " File(s) Uploaded & " + errorCount + " File(s) Failed";

            return new
            {
                responses

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
            string basePath = "E:/DMS/casedoc/";
            string newPath = basePath + filePath;
            string _newPath = newPath.ToString().Replace(@"\", @"/");

            //Virtual Directory
            string vIpAdd = StaticInfos.IsLive ? "https://app.citygroupbd.com/uploadFiles" : "http://192.168.61.246";
            string vPort = StaticInfos.IsLive ? "/casedoc" : "84";
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
                        List<TCaseDocument> ndocList = new List<TCaseDocument>();
                        List<TCaseDocument> udocList = new List<TCaseDocument>();
                        var MaxID = _ctxOra.TCaseDocuments.DefaultIfEmpty().Max(x => x == null ? 0 : x.Documentid) + 1;
                        foreach (var docFile in docList)
                        {
                            if (docFile.documentId > 0)
                            {
                                var udoc = await _ctxOra.TCaseDocuments.FirstOrDefaultAsync(x => x.Documentid == docFile.documentId);
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
                                var ndoc = new TCaseDocument();
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
                            await _ctxOra.TCaseDocuments.AddRangeAsync(ndocList);
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





        //DAHSBORD START FROM HERE 
        public async Task<object> GetDashbordData()
        {
            string refr = string.Empty; object caseList = null;
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                caseList = await Ora_Generic_vmCmnParameter.ExecuteDataTableToJSON(StoredProcedure.SpGet_Dashbord, ocmd, StaticInfos.conStringOracle.ToString());



            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }

            return new
            {

                caseList
            };
        }




        public async Task<object> GetDashbordByDistThnaMouza()
        {
            string refr = string.Empty; object caseList = null;
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                caseList = await Ora_Generic_vmCmnParameter.ExecuteDataTableToJSON(StoredProcedure.SpGet_DashbordByDistThnaMouza, ocmd, StaticInfos.conStringOracle.ToString());



            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }

            return new
            {

                caseList
            };
        }
        


        public async Task<object> GetDeedDashbord()
        {
            string refr = string.Empty; object deedDashbordList = null;
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                deedDashbordList = await Ora_Generic_vmCmnParameter.ExecuteDataTableToJSON(StoredProcedure.SpGet_DeedDashbord, ocmd, StaticInfos.conStringOracle.ToString());



            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }

            return new
            {

                deedDashbordList
            };
        }








        #endregion
    }
}