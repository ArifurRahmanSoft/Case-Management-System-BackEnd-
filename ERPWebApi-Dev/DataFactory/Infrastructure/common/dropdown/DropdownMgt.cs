using DataFactory.BaseFactory;
//using DataModels.EntityModels.ERPModel;
using DataModels.EntityModels.OraModel;
//using DataModels.EntityModels.ISPModel;
using DataModels.ViewModels;
//using DataModels.ViewModels.ERPViewModel.Business.Cloud;
//using DataModels.ViewModels.ERPViewModel.SalesMarketing;
using DataUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFactory.Infrastructure.common.dropdown
{
    public class CommonDropdownMgt
    {

        #region Variable declaration & initialization
        //dbRGLERPContext _ctx = null;
        ModelContext _ctxOra = null;
        //radiusContext _ctxRad = null;
        //private IGenericFactory<vmCmnParameters> Generic_vmCmnParameters = null;
        private IGenericFactoryOracle<vmCmnParameter> OraGeneric_vmCmnParameter = null;
        Hashtable ht = null;
        #endregion

        #region security
        /// <summary>
        /// This method returns data from database as a list of Module object using asynchronous operation by an int parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public async Task<object> GetAllRoleBak()
        //{
        //    object listUsrRole = null; object result = null;
        //    try
        //    {
        //        using (_ctxOr = new ModelContext())
        //        {
        //            listUsrRole = await (from rs in _ctxOr.TRoleSetups
        //                                 where rs.Roleid != StaticInfos.SeedRoleID
        //                                 select new
        //                                 {
        //                                     roleId = rs.Roleid,
        //                                     roleName = rs.Rolename
        //                                 }
        //                              ).ToListAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.Bug(ex);
        //    }

        //    return result = new
        //    {
        //        listUsrRole
        //    };
        //}

        public async Task<object> GetAllRole()
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listUsrRole = string.Empty;
            object result = null;
            try
            {
                string query = "SELECT TO_CHAR(ROLEID) AS \"roleId\", ROLENAME AS \"roleName\" FROM T_ROLE_SETUP WHERE ROLEID<>" + StaticInfos.SeedRoleID.ToString();
                listUsrRole = await OraGeneric_vmCmnParameter.GetByQueryJsonString(query, StaticInfos.conStringOracle);

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listUsrRole
            };
        }

        public async Task<object> GetAllUserByCompany(vmCmnParameter param)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listUser = string.Empty;
            object result = null;
            try
            {
                ht = new Hashtable
                {
                    { "uresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "s_CompanyID", (1, param.values) }
                };

                listUser = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_UserByCompany, ht, StaticInfos.conStringOracle.ToString());

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listUser
            };
        }

        public async Task<object> GetAllCompanyUser(vmCmnParameter param)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listUser = string.Empty;
            object result = null;
            try
            {
                ht = new Hashtable
                {
                    { "uresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "s_CompanyID", (1, param.values) }
                };

                listUser = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_CompanyUser, ht, StaticInfos.conStringOracle.ToString());

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return result = new
            {
                listUser
            };
        }

        public async Task<object> GetAllCompany()
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listCompany = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) }
                };

                listCompany = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_AllCompany, ht, StaticInfos.conStringOracle.ToString());

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                listCompany
            };
        }

        public async Task<object> GetAllUploadType()
        {
            object listUploadType = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listUploadType = await (from cn in _ctxOra.TCmnUploadTypes
                                            where cn.Isactive == Extension.BoolVal(true)
                                            && cn.Isdelete == Extension.BoolVal(false)
                                            select new
                                            {
                                                typeId = cn.TypeId,
                                                typeName = cn.TypeName
                                            }).OrderBy(x => x.typeName).ToListAsync();


                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listUploadType
            };
        }

        public async Task<object> GetAllDivision()
        {
            object listDivisions = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listDivisions = await (from cn in _ctxOra.TDivisions
                                           where cn.Iscancel == Extension.BoolVal(false)
                                           select new
                                           {
                                               id = cn.Oid,
                                               nameEn = cn.NameEn,
                                               nameBn = cn.NameBn
                                           }).OrderBy(x => x.nameEn).ToListAsync();


                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listDivisions
            };
        }

        public async Task<object> GetAllDistrict()
        {
            object listDistricts = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listDistricts = await (from cn in _ctxOra.TDistricts
                                           where cn.Iscancel == Extension.BoolVal(false)
                                           select new
                                           {
                                               id = cn.Oid,
                                               divisionId = cn.DivisionId,
                                               nameEn = cn.NameEn,
                                               nameBn = cn.NameBn
                                           }).OrderBy(x => x.nameEn).ToListAsync();


                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listDistricts
            };
        }

        public async Task<object> GetDistrictById(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            object listDistricts = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listDistricts = await (from cn in _ctxOra.TDistricts
                                           where cn.DivisionId == param.strId &&
                                           cn.Iscancel == Extension.BoolVal(false)
                                           select new
                                           {
                                               id = cn.Oid,
                                               nameEn = cn.NameEn,
                                               nameBn = cn.NameBn
                                           }).OrderBy(x => x.nameEn).ToListAsync();


                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listDistricts
            };
        }

        public async Task<object> GetThanaById(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            object listThanas = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listThanas = await (from cn in _ctxOra.TThanas
                                        where cn.DistrictId == param.strId &&
                                        cn.Iscancel == Extension.BoolVal(false)
                                        select new
                                        {
                                            id = cn.Oid,
                                            nameEn = cn.NameEn,
                                            nameBn = cn.NameBn
                                        }).OrderBy(x => x.nameEn).ToListAsync();


                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listThanas
            };
        }

        public async Task<object> GetAllMouza(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            object listMouza = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listMouza = await (from cn in _ctxOra.TMouzas
                                       where //cn.ThanaId == param.strId &&
                                       cn.Iscancel == Extension.BoolVal(false)
                                       select new
                                       {
                                           id = cn.Oid,
                                           nameEn = cn.NameEn,
                                           nameBn = cn.NameBn
                                       }).OrderBy(x => x.nameEn).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listMouza
            };
        }

        public async Task<object> GetMouzaById(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            object listMouza = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listMouza = await (from cn in _ctxOra.TMouzas
                                       where cn.ThanaId == param.strId &&
                                       cn.Iscancel == Extension.BoolVal(false)
                                       select new
                                       {
                                           id = cn.Oid,
                                           nameEn = cn.NameEn,
                                           nameBn = cn.NameBn
                                       }).OrderBy(x => x.nameEn).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listMouza
            };
        }

        public async Task<object> GetRegistryOfficeById(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            object listRegistryOffice = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listRegistryOffice = await (from cn in _ctxOra.TRegistryOffices
                                                where cn.DistrictId == param.strId &&
                                                cn.Iscancel == Extension.BoolVal(false)
                                                select new
                                                {
                                                    id = cn.Oid,
                                                    nameEn = cn.NameEn,
                                                    nameBn = cn.NameBn
                                                }).OrderBy(x => x.id).ToListAsync();


                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listRegistryOffice
            };
        }

        public async Task<object> GetLandOfficeById(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            object listLandOffice = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listLandOffice = await (from cn in _ctxOra.TLandOffices
                                            where cn.DistrictId == param.strId &&
                                            cn.Iscancel == Extension.BoolVal(false)
                                            select new
                                            {
                                                id = cn.Oid,
                                                nameEn = cn.NameEn,
                                                nameBn = cn.NameBn
                                            }).OrderBy(x => x.id).ToListAsync();


                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listLandOffice
            };
        }

        public async Task<object> GetAllOwner()
        {
            object listOwner = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listOwner = await (from cn in _ctxOra.TPurchasers
                                       where cn.Iscancel == Extension.BoolVal(false)
                                       select new
                                       {
                                           id = cn.Oid,
                                           nameEn = cn.NameEn,
                                           nameBn = cn.NameBn,
                                           addressEn = cn.AddressEn,
                                           addressBn = cn.AddressBn,
                                           isGong = Extension.BoolVal(cn.Isgong),
                                           isChecked = false
                                       }).OrderBy(x => x.id).ToListAsync();


                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listOwner
            };
        }

        public async Task<object> GetAllSeller()
        {
            object listSeller = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listSeller = await (from cn in _ctxOra.TSellers
                                        where cn.Iscancel == Extension.BoolVal(false)
                                        select new
                                        {
                                            id = cn.Oid,
                                            nameEn = cn.NameEn,
                                            nameBn = cn.NameBn,
                                            fatherName=cn.FatherName,
                                            addressEn = cn.AddressEn,
                                            addressBn = cn.AddressBn,
                                            isGong = Extension.BoolVal(cn.Isgong),
                                            isChecked = false
                                        }).OrderBy(x => x.id).ToListAsync();


                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listSeller
            };
        }

        public async Task<object> GetAllSeller(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listSeller = string.Empty;
            try
            {
                string ispaging = Extension.BoolVal(param.IsPaging);
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "exRow", (1, param.pageNumber) },
                    { "nFetchRow", (2, param.pageSize) },
                    { "isPaging", (3, ispaging) }
                };

                listSeller = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_AllSeller, ht, StaticInfos.conStringOracle.ToString());

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                listSeller
            };
        }

        public async Task<object> GetAllDistrictSrc(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listDistricts = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "gId", (1, param.strId) }
                };

                listDistricts = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_Src_AllDistricts, ht, StaticInfos.conStringOracle.ToString());

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                listDistricts
            };
        }

        public async Task<object> GetThanaByIdSrc(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listThanas = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "gId", (1, param.strId) }
                };

                listThanas = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_Src_AllThanaById, ht, StaticInfos.conStringOracle.ToString());

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                listThanas
            };
        }

        public async Task<object> GetMouzaByIdSrc(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listMouza = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "gId", (1, param.strId) }
                };

                listMouza = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_Src_AllMouzaById, ht, StaticInfos.conStringOracle.ToString());

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

        public async Task<object> GetAllOwnerSrc(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listOwner = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "gId", (1, param.strId) }
                };

                listOwner = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_Src_AllOwner, ht, StaticInfos.conStringOracle.ToString());

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                listOwner
            };
        }

        public async Task<object> GetAllSellerSrc(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listSeller = string.Empty;
            try
            {
                ht = new Hashtable
                {
                    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                    { "gId", (1, param.strId) }
                };

                listSeller = await OraGeneric_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_Src_AllSeller, ht, StaticInfos.conStringOracle.ToString());

            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                listSeller
            };
        }

        public async Task<object> GetAllServey()
        {
            object listServey = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listServey = await (from cn in _ctxOra.TServeys
                                        where cn.Iscancel == Extension.BoolVal(false)
                                        select new
                                        {
                                            serveyId = cn.Oid,
                                            serveyName = cn.NameBn
                                        }).OrderBy(x => x.serveyId).ToListAsync();


                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listServey
            };
        }

        public async Task<object> GetAllLandClass()
        {
            object listLandClass = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listLandClass = await (from cn in _ctxOra.TLandClasses
                                           where cn.Iscancel == Extension.BoolVal(false)
                                           select new
                                           {
                                               classId = cn.Oid,
                                               className = cn.NameBn
                                           }).OrderBy(x => x.classId).ToListAsync();


                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listLandClass
            };
        }

        public async Task<object> GetAllLandDeed(object[] data)
        {
            object listLandDeed = null;
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listLandDeed = await (from cn in _ctxOra.TLandDeeds                                          
                                          where cn.Iscancel == Extension.BoolVal(false)
                                          && cn.MouzaId== param.strId
                                          select new
                                          {
                                              deedId = cn.Oid,
                                              deedNo = cn.DeedNo,
                                              deedDate = cn.DeedDate == null ? "" : cn.DeedDate.ToString("dd/MM/yyyy")
                                          }).OrderBy(x => x.deedId).ToListAsync();


                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listLandDeed
            };
        }

        public async Task<object> GetAllLandProject()
        {
            object listLandProject = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listLandProject = await (from cn in _ctxOra.TLandProjects
                                           where cn.Iscancel == Extension.BoolVal(false)
                                           select new
                                           {
                                               projectId = cn.Oid,
                                               projectName = cn.NameBn
                                           }).OrderBy(x => x.projectId).ToListAsync();


                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listLandProject
            };
        }

        public async Task<object> GetAllLandCategories()
        {
            object listLandCategories = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listLandCategories = await (from cn in _ctxOra.TLandCategories
                                                where cn.Iscancel == Extension.BoolVal(false)
                                             select new
                                             {
                                                 categoryId = cn.Oid,
                                                 categoryName = cn.NameBn
                                             }).OrderBy(x => x.categoryId).ToListAsync();


                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listLandCategories
            };
        }

        public async Task<object> GetAllLandSubCategories()
        {
            object listLandSubCategories = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listLandSubCategories = await (from cn in _ctxOra.TLandSubCategories
                                                where cn.Iscancel == Extension.BoolVal(false)
                                                select new
                                                {
                                                    subCategoryId = cn.Oid,
                                                    categoryId = cn.CatOid,
                                                    subCategoryName = cn.NameBn
                                                }).OrderBy(x => x.subCategoryId).ToListAsync();


                }
            }
            catch (Exception ex)
            {
                //Logs.Bug(ex);
            }

            return new
            {
                listLandSubCategories
            };
        }


        //CASE START FROM HERE ---------------------------------------
        public async Task<Object> GetAllCaseType()
        {
            object listCaseType = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listCaseType = await (from cs in _ctxOra.TCaseTypes
                                          where cs.Iscancel == Extension.BoolVal(false)
                                          select new
                                          {
                                              caseId = cs.Oid,
                                              caseEnName = cs.NameEn,
                                              caseBnName = cs.NameBn
                                          }).ToListAsync();
                }

            }
            catch(Exception ex)
            {

            }
            return new
            {
                listCaseType
            };
        }

        public async Task<Object> GetAllCourt()
        {
            object listCourt = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listCourt = await (from cs in _ctxOra.TCaseCourts
                                          where cs.Iscancel == Extension.BoolVal(false)
                                          select new
                                          {
                                              courtId = cs.Oid,
                                              courtEnName = cs.NameEn,
                                              courtBnName = cs.NameBn
                                          }).ToListAsync();
                }

            }
            catch (Exception ex)
            {

            }
            return new
            {
                listCourt
            };
        }


        public async Task<object> GetAllCaseStatus()
        {
            object listCaseStatus = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listCaseStatus = await (from ct in _ctxOra.TCaseStatuses
                                            where ct.Iscancel == Extension.BoolVal(false)
                                            select new
                                            {
                                                statusid = ct.Oid,
                                                statusEnName = ct.NameEn,
                                                statusBnName = ct.NameBn

                                            }).ToListAsync();
                }
            }
            catch(Exception ex)
            {

            }
            return new
            {
                listCaseStatus
            };
        }

        public async Task<object> GetAllCasePriority()
        {
            object listCasePriority = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listCasePriority = await (from ct in _ctxOra.TCasePriorities
                                            where ct.Iscancel == Extension.BoolVal(false)
                                            select new
                                            {
                                                priorityId = ct.Oid,
                                                priorityEnName = ct.NameEn,
                                                priorityBnName = ct.NameBn

                                            }).ToListAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return new
            {
                listCasePriority
            };
        }


        public async Task<object> GetAllAdvocate()
        {
            object listAdvocate = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listAdvocate = await (from ct in _ctxOra.TCaseAdvocates
                                              where ct.Iscancel == Extension.BoolVal(false)
                                              select new
                                              {
                                                  advocateOid = ct.Oid,
                                                  advocateEnName = ct.NameEn,
                                                  advocateBnName = ct.NameBn

                                              }).ToListAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return new
            {
                listAdvocate
            };
        }



        public async Task<object> GetAllHearingEvent()
        {
            object listHearingEvent = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listHearingEvent = await (from ct in _ctxOra.TCaseHearingEvents
                                          where ct.Iscancel == Extension.BoolVal(false)
                                          select new
                                          {
                                              hearingEventOid = ct.Oid,
                                              eventEnName = ct.NameEn,
                                              eventBnName = ct.NameBn

                                          }).ToListAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return new
            {
                listHearingEvent
            };
        }


        public async Task<object> GetAllPurchars()
        {
            object listPurcahrs = null;
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    listPurcahrs = await (from ct in _ctxOra.TPurchasers
                                              where ct.Iscancel == Extension.BoolVal(false)
                                              select new
                                              {
                                                  purcharsOid = ct.Oid,
                                                  purcharsEnName = ct.NameEn,
                                                  purcharsBnName = ct.NameBn

                                              }).ToListAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return new
            {
                listPurcahrs
            };
        }


        public async Task<object> SaveCaseHearingEvnt(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            string _JsonData = data[1].ToString();
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    var maxId=await _ctxOra.TCaseHearingEvents.MaxAsync(x => (int?)Convert.ToInt32(x.Oid)) ?? 0;
                    var newOid = maxId + 1;

                    var newCaseHearingEvent = new TCaseHearingEvent
                    {
                        Oid = newOid.ToString(),
                       // NameEn = hearingEvent.NameEn,
                        NameBn = _JsonData,//hearingEvent.NameBn,,
                        Isactive = "1",
                        Iscancel = "0",
                        Createby = param.LoggedUserId,
                        Createon = DateTime.Today,
                        Createpc = Extension.Createpc()
                    };
                    _ctxOra.TCaseHearingEvents.Add(newCaseHearingEvent);
                    await _ctxOra.SaveChangesAsync();

                    return new
                    {
                        status = "success",
                        message = "Data inserted successfully",
                        oid = newOid
                    };
                }
            }

            catch(Exception ex)
            {
                return new
                {
                    status = "error",
                    message = ex.Message
                };
            }
        }



        public async Task<object> SaveCaseCort(object[] data)
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            string _JsonData = data[1].ToString();
            try
            {
                using (_ctxOra = new ModelContext())
                {
                    var maxId = await _ctxOra.TCaseCourts.MaxAsync(x => (int?)Convert.ToInt32(x.Oid)) ?? 0;
                    var newOid = maxId + 1;

                    var newCaseCort = new TCaseCourt
                    {
                        Oid = newOid.ToString(),
                        // NameEn = hearingEvent.NameEn,
                        NameBn = _JsonData,//hearingEvent.NameBn,,
                        Isactive = "1",
                        Iscancel = "0",
                        Createby = param.LoggedUserId,
                        Createon = DateTime.Today,
                        Createpc = Extension.Createpc()
                    };
                    _ctxOra.TCaseCourts.Add(newCaseCort);
                    await _ctxOra.SaveChangesAsync();

                    return new
                    {
                        status = "success",
                        message = "Data inserted successfully",
                        oid = newOid
                    };
                }
            }

            catch (Exception ex)
            {
                return new
                {
                    status = "error",
                    message = ex.Message
                };
            }
        }

        //CASE END HERE

        #endregion        
    }
}
