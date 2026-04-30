using DataFactory.BaseFactory;
using DataModels.EntityModels.OraModel;
using DataModels.ViewModels;
using DataModels.ViewModels.ERPViewModel.Business;
using DataUtilities;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace DataFactory.Infrastructure.business
{
    public class UploadTypeSetupMgt
    {
        #region Variable declaration & initialization
        ModelContext _ctxOra = null;
        private IGenericFactoryOracle<vmCmnParameter> OraGeneric_vmCmnParameter = null;
        Hashtable ht = null; OracleParameter[] oprm = null;
        #endregion

        #region All Methods
        #region Start Upload Type Setup
        /// <summary>
        /// This method returns an object from database as object with pagination using asynchronous operation by vmCmnParameters class as parameter.
        /// </summary>
        /// <param name="cmnParam"></param>
        /// <returns></returns>
        public async Task<object> GetByPage(object[] data) //vmCmnParameters cmnParam
        {
            vmCmnParameter cmnParam = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            int recordsTotal = 0; object listUploadType = null, result = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    recordsTotal = await _ctxOra.TCmnUploadTypes.Where(x => x.Isactive == Extension.BoolVal(true) && x.Isdelete == Extension.BoolVal(false)).CountAsync();
                    var UploadTypeList = await (from cn in _ctxOra.TCmnUploadTypes
                                                where cn.Isactive == Extension.BoolVal(true) && cn.Isdelete == Extension.BoolVal(false)
                                                select new
                                                {
                                                    typeId = cn.TypeId,
                                                    typeName = cn.TypeName,
                                                    isActive = Extension.BoolVal(cn.Isactive),
                                                    recordsTotal = recordsTotal
                                                }).OrderByDescending(x => x.typeId).Skip(Conversions.Skip(cmnParam)).Take((int)cmnParam.pageSize).ToListAsync();
                    listUploadType = JsonConvert.SerializeObject(UploadTypeList).ToString();

                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            result = new
            {
                listUploadType,
                recordsTotal
            };

            return result;
        }

        /// <summary>
        /// This method returns data from database as an object using asynchronous operation by an int parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<object> GetByID(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            object result = null, objUploadType = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    objUploadType = await (from cn in _ctxOra.TCmnUploadTypes
                                           where cn.TypeId == param.id
                                           select new
                                           {
                                               typeId = cn.TypeId,
                                               typeName = cn.TypeName,
                                               isActive = Extension.BoolVal(cn.Isactive)
                                           }).FirstOrDefaultAsync();
                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }
            result = new
            {
                objUploadType
            };
            return result;
        }

        /// <summary>
        /// Both insert and update can perform by view model in database using asynchronous operation. when id is more than 0 update is performed otherwise insert. it returns an object as status of success or failure.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<object> SaveUpdate(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            vmUploadType _uploadType = JsonConvert.DeserializeObject<vmUploadType>(data[1].ToString());
            object result = null; string message = string.Empty; bool resstate = false;
            using (_ctxOra = new ModelContext())
            {
                using (var _ctxOraTransaction = _ctxOra.Database.BeginTransaction())
                {
                    try
                    {
                        var uploadType = new TCmnUploadType();
                        if (_uploadType.typeId > 0)
                        {
                            uploadType = await _ctxOra.TCmnUploadTypes.FirstOrDefaultAsync(x => x.TypeId == _uploadType.typeId);
                            uploadType.TypeName = _uploadType.typeName;
                            uploadType.Isactive = Extension.BoolVal(_uploadType .isActive);
                            //Common
                            uploadType.Updatepc = Extension.Createpc();
                            uploadType.Updateby = param.LoggedUserId;
                            uploadType.Updateon = Extension.Today;

                            message = MessageConstants.Updated;
                        }
                        else
                        {
                            var MaxID = _ctxOra.TCmnUploadTypes.DefaultIfEmpty().Max(x => x == null ? 0 : x.TypeId) + 1;

                            uploadType.TypeId = MaxID;
                            uploadType.TypeName = _uploadType.typeName;
                            uploadType.Isactive = Extension.BoolVal(_uploadType.isActive);

                            //Common
                            uploadType.Createpc = Extension.Createpc();
                            uploadType.Createby = param.LoggedUserId;
                            uploadType.Createon = Extension.Today;

                            await _ctxOra.TCmnUploadTypes.AddAsync(uploadType);
                            message = MessageConstants.Saved;
                        }

                        await _ctxOra.SaveChangesAsync();

                        _ctxOraTransaction.Commit();
                        resstate = MessageConstants.SuccessState;
                    }
                    catch (Exception ex)
                    {
                        _ctxOraTransaction.Rollback();
                        //Logs.Bug(ex);
                        message = MessageConstants.SavedWarning;
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
        /// Delete can perform to CmnUserRole table by int parameter in database using asynchronous operation. It returns an object as status of success or failure.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                            var delmodel = await _ctxOra.TCmnUploadTypes.Where(x => x.TypeId == param.id).FirstOrDefaultAsync();
                            delmodel.Isdelete = Extension.BoolVal(true);
                            delmodel.Deletepc = Extension.Createpc();
                            delmodel.Deleteby = param.LoggedUserId;
                            delmodel.Deleteon = Extension.Today;
                        }

                        await _ctxOra.SaveChangesAsync();
                        _ctxOraTran.Commit();
                        message = MessageConstants.Deleted;
                        resstate = MessageConstants.SuccessState;
                    }
                    catch (Exception ex)
                    {
                        _ctxOraTran.Rollback();
                        //Logs.Bug(ex);
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
        #endregion End Upload Type Setup
        #endregion
    }
}
