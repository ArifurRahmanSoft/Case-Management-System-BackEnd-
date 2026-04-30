//using DataModels.EntityModels.ERPModel;
using DataModels.ViewModels;
using DataUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFactory.BaseFactory;
using System.Collections;
using System.Data.SqlClient;
//using DataModels.ViewModels.ERPViewModel.NOC;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using DataModels.EntityModels.OraModel;
using DataModels.ViewModels.ERPViewModel.Common;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using Newtonsoft.Json;

namespace DataFactory.Infrastructure.common.menus
{
    public class MenuMgt
    {
        #region Variable declaration & initialization
        //dbRGLERPContext _ctx = null;
        ModelContext _ctxOra = null;
        OracleCommand ocmd = null;
        Hashtable ht = null; OracleParameter[] oprm = null;
        private IGenericFactoryOracle<vmCmnParameter> OraGeneric_vmCmnParameter = null;
        #endregion

        #region All Methods

        /// <summary>
        /// This method returns an object from database as object with pagination using asynchronous operation by vmCmnParameters class as parameter.
        /// </summary>
        /// <param name="cmnParam"></param>
        /// <returns></returns>
        public async Task<object> GetOraRoleWiseMenu(vmCmnParameter param)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listRoleMenu = string.Empty;
            object result = null; int recordsTotal = 0;
            try
            {
                ht = new Hashtable
                {
                    { "rresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "p_RoleId", (1, param.id) },
                    { "PageNumber", (2, Convert.ToDecimal(param.pageNumber))},
                    { "PageSize", (3, Convert.ToDecimal(param.pageSize)) }
                };

                listRoleMenu = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_Menu_By_RoleID, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex);
            }
            return result = new
            {
                listRoleMenu,
                recordsTotal
            };
        }

        /// <summary>
        /// This method returns an object from database using asynchronous operation by vmCmnParameters class as parameter.
        /// </summary>
        /// <param name="cmnParam"></param>
        /// <returns></returns>
        public async Task<object> GetMenu(vmCmnParameter param)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string menues = string.Empty;
            object result = null;
            try
            {
                ht = new Hashtable
                {
                    { "sresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "s_userid", (1, param.UserID) },
                    { "s_roleid", (2, param.id) }
                };

                menues = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGET_CmnMenu, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex);
            }
            return result = new
            {
                menues
            };
        }

        public async Task<object> GetSideMenu(vmCmnParameter param)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string mainMenues = string.Empty, childMenues = string.Empty, subChildMenues = string.Empty;
            object result = null;
            try
            {
                ht = new Hashtable
                {
                    { "sresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "s_UserId", (1, param.UserID) },
                    { "s_RoleId", (2, param.id) }
                };

                mainMenues = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGET_MainMenu, ht, StaticInfos.conStringOracle.ToString());
                childMenues = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGET_ChildMenu, ht, StaticInfos.conStringOracle.ToString());
                subChildMenues = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGET_SubChildMenu, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                //Logs.WriteBug(ex);
            }
            return result = new
            {
                mainMenues,
                childMenues,
                subChildMenues
            };
        }

        public async Task<object> CheckMenuIfExist(vmCmnParameter param)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            bool canNavigate = false;
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("g_UserId", OracleDbType.Varchar2).Value = param.UserID;
                ocmd.Parameters.Add("g_RoleId", OracleDbType.Decimal).Value = param.id;
                ocmd.Parameters.Add("g_SRoleId", OracleDbType.Decimal).Value = StaticInfos.SeedRoleID;
                ocmd.Parameters.Add("g_MenuPath", OracleDbType.Varchar2).Value = param.values;

                canNavigate = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.SpCheck_MenuIfExist, ocmd, "gresult", StaticInfos.conStringOracle.ToString()) == "1" ? true : false;
            }
            catch (Exception ex)
            {
                ex.ToString();
                Logs.Bug(ex);
            }
            return new
            {
                canNavigate
            };
        }

        public async Task<object> GetParentAndSubParentMenu(vmCmnParameter param)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listMenues = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "g_ParentId", (1, param.id) }
                };

                listMenues = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_ParentAndSubParentMenu, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                ex.ToString();
                Logs.Bug(ex);
            }
            return new
            {
                listMenues
            };
        }

        public async Task<object> GetByID(int id)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string objMenu = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "g_MenuId", (1, id) }
                };

                objMenu = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_MenuByID, ht, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                ex.ToString();
                Logs.Bug(ex);
            }
            return new
            {
                objMenu
            };
        }

        public async Task<object> SaveUpdate(string _JsonData, vmCmnParameter param)
        {
            string message = string.Empty; bool resstate = false;
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string result = string.Empty;
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("JsonData", OracleDbType.Clob).Value = _JsonData;
                ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
                ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();

                result = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSet_CmnMenu, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
                if (!string.IsNullOrEmpty(result) && result != "0")
                {
                    message = MessageConstants.Saved;
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
                message,
                resstate
            };
        }

        /// <summary>
        /// Delete can perform to CmnMenu table by int parameter in database using asynchronous operation. It returns an object as status of success or failure.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<object> Delete(vmCmnParameter param)
        {
            object result = null; string message = string.Empty; bool resstate = false;
            using (_ctxOra = new ModelContext())
            {
                using (var _ctxOraTran = await _ctxOra.Database.BeginTransactionAsync())
                {
                    try
                    {
                        if (param.id > 0)
                        {
                            var delperm = await _ctxOra.TCmnmenupermissions.Where(x => x.Menuid == param.id).ToListAsync();
                            foreach (var item in delperm)
                            {
                                item.Isdelete = Extension.BoolVal(true);
                                item.Deletepc = Extension.Createpc();
                                item.Deleteby = param.LoggedUserId;
                                item.Deleteon = Extension.Today;
                            }

                            var delmodel = await _ctxOra.TCmnmenus.Where(x => x.Menuid == param.id).FirstOrDefaultAsync();
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

        //public async Task<object> SaveUpdatePermission(string _JsonData, vmCmnParameter param)
        //{
        //    string message = string.Empty; bool resstate = false;
        //    OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
        //    string result = string.Empty;
        //    try
        //    {
        //        ocmd = new OracleCommand();
        //        ocmd.Parameters.Add("mresult", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
        //        ocmd.Parameters.Add("JsonData", OracleDbType.Clob).Value = _JsonData;
        //        ocmd.Parameters.Add("mCreateBy", OracleDbType.Varchar2).Value = param.LoggedUserId;
        //        ocmd.Parameters.Add("mCreatePC", OracleDbType.Varchar2).Value = Extension.Createpc();

        //        result = await OraGeneric_vmCmnParameter.ExecuteNonQueryOutString(StoredProcedure.Ora_SpSet_CmnMenuPermission, ocmd, "mresult", StaticInfos.conStringOracle.ToString());
        //        if (!string.IsNullOrEmpty(result) && result != "0")
        //        {
        //            message = MessageConstants.Saved;
        //            resstate = MessageConstants.SuccessState;
        //        }
        //        else
        //        {
        //            message = MessageConstants.SavedWarning;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.Bug(ex);
        //    }
        //    return new
        //    {
        //        message,
        //        resstate
        //    };
        //}

        #region Menu Permission
        public async Task<object> SaveUpdatePermission(List<vmRoleMenu> model, vmCmnParameter param)
        {
            object result = null; string message = string.Empty; bool resstate = false; List<CmnMenuPermission> cmPermision = new List<CmnMenuPermission>();
            List<vmRoleMenu> pr = new List<vmRoleMenu>();

            using (_ctxOra = new ModelContext())
            {
                using (var _ctxTransactionOra = _ctxOra.Database.BeginTransaction())
                {
                    try
                    {
                        //var smodelList = model.Where(x => x.HasChild == false && x.IsSubParent == false && x.ParentID == 0).ToList();

                        //Filter=> Filter only menu without parent and sub parent
                        model = model.Where(x => (x.ParentID > 0 && x.IsSubParent == false) || (x.HasChild == false && x.IsSubParent == false && x.ParentID == 0)).ToList();
                        //Filter

                        #region Set Put Sub-Menu/Menu
                        await SetPutMenuPermission(model, param);
                        #endregion Set Put Sub-Menu/Menu

                        #region Set Sub Parent
                        //Filter=> Filter and get only unique sub parent menu using 'GroubBy'
                        var nmodel = model.Where(x => x.SubParentID > 0).GroupBy(s => new { s.SubParentID }).Select(x => new vmRoleMenu { RoleID = x.FirstOrDefault().RoleID, SubParentID = x.FirstOrDefault().SubParentID, IsView = x.FirstOrDefault().IsView == true || x.FirstOrDefault().IsInsert == true || x.FirstOrDefault().IsUpdate == true || x.FirstOrDefault().IsDelete == true ? true : false }).ToList();
                        //Filter
                        if (nmodel.Count > 0)
                        {
                            await SetPutSubParentMenuPermission(nmodel, param);
                        }
                        #region Set Sub Parent Commented Code
                        //foreach (var nm in nmodel)
                        //{
                        //    int getval = 0; //bool IsBool = true;
                        //    var cm = _ctx.CmnMenu.Where(x => x.MenuId == nm.SubParentID).FirstOrDefault();
                        //    if (cm != null)
                        //    {
                        //        if (nm.IsView == false)
                        //        {
                        //            var mbyp = _ctx.CmnMenu.Where(x => x.SubParentId == cm.MenuId && x.IsSubParent != true).ToList();
                        //            if (mbyp.Count > 0)
                        //            {
                        //                foreach (var mb in mbyp)
                        //                {
                        //                    bool isTrue = _ctx.CmnMenuPermission.Where(x => x.UserRole == nm.RoleID && x.MenuId == mb.MenuId && (x.CanView == true || x.CanCreate == true || x.CanEdit == true || x.CanDelete == true)).FirstOrDefault() == null ? false : true;
                        //                    if (isTrue == true)
                        //                    {
                        //                        getval++;
                        //                        break;
                        //                    }
                        //                }

                        //                if (getval > 0)
                        //                {
                        //                    nm.IsView = true;
                        //                }
                        //                //else
                        //                //{
                        //                //IsBool = false;
                        //                //}
                        //            }
                        //        }

                        //        //var exm = model.Where(x => x.MenuId == cm.MenuId && (x.IsView == IsBool || x.IsInsert == IsBool || x.IsUpdate == IsBool || x.IsDelete == IsBool)).FirstOrDefault();
                        //        //if (exm == null)
                        //        //{
                        //        if (cm != null)
                        //        {
                        //            var nsubpr = new vmRoleMenu();
                        //            nsubpr.MenuId = cm.MenuId;
                        //            nsubpr.RoleID = nm.RoleID;
                        //            nsubpr.IsView = nm.IsView;
                        //            nsubpr.IsInsert = nm.IsView;
                        //            nsubpr.IsUpdate = nm.IsView;
                        //            nsubpr.IsDelete = nm.IsView;

                        //            subpr.Add(nsubpr);
                        //        }
                        //        //}
                        //    }
                        //}

                        //if (subpr.Count > 0)
                        //{
                        //    newModel = new List<vmRoleMenu>();
                        //    newModel.AddRange(subpr);
                        //    await SetPutMenuPermission(newModel, cmnParam);
                        //}
                        #endregion Set Sub Parent Commented Code
                        #endregion Set Sub Parent                        

                        #region Set Parent
                        //Filter=> Filter and get only unique parent menu using 'GroubBy'
                        var npmodel = model.Where(x => x.ParentID > 0).GroupBy(s => new { s.ParentID }).Select(x => new vmRoleMenu { RoleID = x.FirstOrDefault().RoleID, ParentID = x.FirstOrDefault().ParentID, IsView = x.FirstOrDefault().IsView == true || x.FirstOrDefault().IsInsert == true || x.FirstOrDefault().IsUpdate == true || x.FirstOrDefault().IsDelete == true ? true : false }).ToList();
                        //Filter
                        if (npmodel.Count > 0)
                        {
                            await SetPutParentMenuPermission(npmodel, param);
                        }
                        #region Set Parent Commented Code
                        //foreach (var npm in npmodel)
                        //{
                        //    int getval = 0; //bool IsBool = true;
                        //    var cpm = _ctx.CmnMenu.Where(x => x.MenuId == npm.ParentID).FirstOrDefault();
                        //    if (cpm != null)
                        //    {
                        //        if (npm.IsView == false)
                        //        {
                        //            var mbyp = _ctx.CmnMenu.Where(x => x.ParentId == cpm.MenuId).ToList();
                        //            if (mbyp.Count > 0)
                        //            {
                        //                foreach (var mb in mbyp)
                        //                {
                        //                    bool isTrue = _ctx.CmnMenuPermission.Where(x => x.UserRole == npm.RoleID && x.MenuId == mb.MenuId && (x.CanView == true || x.CanCreate == true || x.CanEdit == true || x.CanDelete == true)).FirstOrDefault() == null ? false : true;
                        //                    if (isTrue == true)
                        //                    {
                        //                        getval++;
                        //                        break;
                        //                    }
                        //                }

                        //                if (getval > 0)
                        //                {
                        //                    npm.IsView = true;
                        //                }
                        //                //else
                        //                //{
                        //                //IsBool = false;
                        //                //}
                        //            }
                        //        }

                        //        //var expm = model.Where(x => x.MenuId == cpm.MenuId && (x.IsView== IsBool || x.IsInsert == IsBool || x.IsUpdate == IsBool || x.IsDelete == IsBool)).FirstOrDefault();
                        //        //if (expm == null)
                        //        //{
                        //        if (cpm != null)
                        //        {
                        //            var npr = new vmRoleMenu();
                        //            npr.MenuId = cpm.MenuId;
                        //            npr.RoleID = npm.RoleID;
                        //            npr.IsView = npm.IsView;
                        //            npr.IsInsert = npm.IsView;
                        //            npr.IsUpdate = npm.IsView;
                        //            npr.IsDelete = npm.IsView;

                        //            pr.Add(npr);
                        //        }
                        //        //}
                        //    }
                        //}

                        //if (pr.Count > 0)
                        //{
                        //    newModel = new List<vmRoleMenu>();
                        //    newModel.AddRange(pr);
                        //    await SetPutMenuPermission(newModel, cmnParam);
                        //}
                        #endregion Set Parent Commented Code
                        #endregion Set Parent

                        _ctxTransactionOra.Commit();
                        message = MessageConstants.Saved;
                        resstate = MessageConstants.SuccessState;
                    }
                    catch (Exception ex)
                    {
                        _ctxTransactionOra.Rollback();
                        //Logs.WriteBug(ex);
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

        private async Task<int> SetPutMenuPermission(List<vmRoleMenu> model, vmCmnParameter param)
        {
            List<TCmnmenupermission> cmPermision = new List<TCmnmenupermission>();
            var exRoleMenu = await _ctxOra.TCmnmenupermissions.Where(x => x.Roleid == param.id).ToListAsync();
            var MaxID = _ctxOra.TCmnmenupermissions.DefaultIfEmpty().Max(x => x == null ? 0 : x.Menupermissionid) + 1;

            if (exRoleMenu.Count > 0)
            {
                foreach (var _RMenu in model)
                {
                    var _RM = exRoleMenu.Where(x => x.Menuid == _RMenu.MenuId).FirstOrDefault();
                    if (_RM != null)
                    {
                        _RM.Enableview = Extension.BoolVal(_RMenu.IsView);
                        _RM.Enableinsert = Extension.BoolVal(_RMenu.IsInsert);
                        _RM.Enableupdate = Extension.BoolVal(_RMenu.IsUpdate);
                        _RM.Enabledelete = Extension.BoolVal(_RMenu.IsDelete);
                        //Common
                        _RM.Updatepc = Extension.Createpc();
                        _RM.Updateby = param.LoggedUserId;
                        _RM.Updateon = Extension.Today;
                    }
                    else
                    {
                        var mPer = new TCmnmenupermission();
                        mPer.Menupermissionid = MaxID;
                        mPer.Roleid = Convert.ToDecimal(_RMenu.RoleID);
                        mPer.Menuid = _RMenu.MenuId;
                        mPer.Enableview = Extension.BoolVal(_RMenu.IsView);
                        mPer.Enableinsert = Extension.BoolVal(_RMenu.IsInsert);
                        mPer.Enableupdate = Extension.BoolVal(_RMenu.IsUpdate);
                        mPer.Enabledelete = Extension.BoolVal(_RMenu.IsDelete);

                        //Common
                        mPer.Createpc = Extension.Createpc();
                        mPer.Createby = param.LoggedUserId;
                        mPer.Createon = Extension.Today;
                        cmPermision.Add(mPer);
                        MaxID++;
                    }
                }
            }
            else
            {
                foreach (var _RMenu in model)
                {
                    var mPer = new TCmnmenupermission();
                    mPer.Menupermissionid = MaxID;
                    mPer.Roleid = Convert.ToDecimal(_RMenu.RoleID);
                    mPer.Menuid = _RMenu.MenuId;
                    mPer.Enableview = Extension.BoolVal(_RMenu.IsView);
                    mPer.Enableinsert = Extension.BoolVal(_RMenu.IsInsert);
                    mPer.Enableupdate = Extension.BoolVal(_RMenu.IsUpdate);
                    mPer.Enabledelete = Extension.BoolVal(_RMenu.IsDelete);

                    //Common
                    mPer.Createpc = Extension.Createpc();
                    mPer.Createby = param.LoggedUserId;
                    mPer.Createon = Extension.Today;
                    cmPermision.Add(mPer);
                    MaxID++;
                }
            }

            if (cmPermision.Count > 0)
            {
                await _ctxOra.TCmnmenupermissions.AddRangeAsync(cmPermision);
            }

            await _ctxOra.SaveChangesAsync();
            return 0;
        }
        
        private async Task<int> SetPutSubParentMenuPermission(List<vmRoleMenu> nmodel, vmCmnParameter param)
        {
            List<vmRoleMenu> subParentModel = new List<vmRoleMenu>();
            foreach (var nm in nmodel)
            {
                //Filter=> Filter and get sub parent menu
                var cm = _ctxOra.TCmnmenus.Where(x => x.Menuid == nm.SubParentID).FirstOrDefault();
                //Filter
                if (cm != null)
                {
                    if (nm.IsView == false)
                    {
                        //Filter=> Filter and check if any child menu remain permitted or not  in permission table.
                        nm.IsView = (from cnm in _ctxOra.TCmnmenus
                                     join cmp in _ctxOra.TCmnmenupermissions on cnm.Menuid equals cmp.Menuid
                                     where cnm.Subparentid == cm.Menuid && cmp.Roleid == nm.RoleID
                                     && (cmp.Enableview == Extension.BoolVal(true) || cmp.Enableinsert == Extension.BoolVal(true) || cmp.Enableupdate == Extension.BoolVal(true) || cmp.Enabledelete == Extension.BoolVal(true))
                                     select cnm).FirstOrDefault() == null ? false : true;
                        //Filter
                    }

                    if (cm != null)
                    {
                        var nsubpr = new vmRoleMenu
                        {
                            MenuId = (int)cm.Menuid,
                            RoleID = nm.RoleID,
                            IsView = nm.IsView,
                            IsInsert = false,
                            IsUpdate = false,
                            IsDelete = false
                        };

                        subParentModel.Add(nsubpr);
                    }
                }
            }

            if (subParentModel.Count > 0)
            {
                await SetPutMenuPermission(subParentModel, param);
            }

            return 1;
        }

        private async Task<int> SetPutParentMenuPermission(List<vmRoleMenu> nmodel, vmCmnParameter param)
        {
            List<vmRoleMenu> parentModel = new List<vmRoleMenu>();
            foreach (var npm in nmodel)
            {
                //Filter=> Filter and get parent menu
                var cpm = _ctxOra.TCmnmenus.Where(x => x.Menuid == npm.ParentID).FirstOrDefault();
                //Filter
                if (cpm != null)
                {
                    if (npm.IsView == false)
                    {
                        //Filter=> Filter and check if any child menu remain permitted or not  in permission table.
                        npm.IsView = (from cm in _ctxOra.TCmnmenus
                                      join cmp in _ctxOra.TCmnmenupermissions on cm.Menuid equals cmp.Menuid
                                      where cm.Parentid == cpm.Menuid && cmp.Roleid == npm.RoleID
                                      && (cmp.Enableview == Extension.BoolVal(true) || cmp.Enableinsert == Extension.BoolVal(true) || cmp.Enableupdate == Extension.BoolVal(true) || cmp.Enabledelete == Extension.BoolVal(true))
                                      select cm).FirstOrDefault() == null ? false : true;
                        //Filter
                    }

                    if (cpm != null)
                    {
                        var npr = new vmRoleMenu
                        {
                            MenuId = (int)cpm.Menuid,
                            RoleID = npm.RoleID,
                            IsView = npm.IsView,
                            IsInsert = false,
                            IsUpdate = false,
                            IsDelete = false
                        };

                        parentModel.Add(npr);
                    }
                }
            }

            if (parentModel.Count > 0)
            {
                await SetPutMenuPermission(parentModel, param);
            }

            return 1;
        }
        #endregion Menu Permission        
        #endregion
    }
}
