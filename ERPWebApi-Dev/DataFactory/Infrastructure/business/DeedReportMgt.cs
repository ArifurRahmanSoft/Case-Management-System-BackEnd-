using DataFactory.AllServiceClasses;
using DataFactory.BaseFactory;
using DataFactory.Infrastructure.common.menus;
using DataModels.EntityModels.OraModel;
using DataModels.ViewModels;
using DataModels.ViewModels.ERPViewModel.Common;
using DataUtilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using MySqlX.XDevAPI.Common;
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
    public class DeedReportMgt
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
                ocmd = new OracleCommand();
                //ocmd.Parameters.Add("gresult", OracleDbType.Clob).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("gresult", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("PageNumber", OracleDbType.Decimal).Value = param.pageNumber;
                ocmd.Parameters.Add("PageSize", OracleDbType.Decimal).Value = param.pageSize;
                ocmd.Parameters.Add("SearchJSON", OracleDbType.Clob).Value = param.Query;
                ocmd.Parameters.Add("IsPage", OracleDbType.Varchar2).Value = Extension.BoolVal(param.IsPage);
                if (param.IsPage)
                {
                    listDeed = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_DeedReportByPage, ocmd, StaticInfos.conStringOracle.ToString());
                }
                else
                {
                    listDeed = await Ora_Generic_vmCmnParameter.ExecuteCommandStrings(StoredProcedure.SpGet_DeedReportByPageNew, ocmd, StaticInfos.conStringOracle.ToString());
                }

                //listDeed = await Ora_Generic_vmCmnParameter.ExecuteNonQueryOutClob(StoredProcedure.SpGet_DeedReportByPageNew, ocmd, "gresult", StaticInfos.conStringOracle.ToString());

                //ht = new Hashtable
                //{
                //    { "gresult", (0, OracleDbType.RefCursor, ParameterDirection.Output) },
                //    { "PageNumber", (1, Convert.ToDecimal(param.pageNumber))},
                //    { "PageSize", (2, Convert.ToDecimal(param.pageSize)) },
                //    { "SearchJSON", (3, param.Query) },
                //    { "IsPage", (4, Extension.BoolVal(param.IsPage)) }
                //};

                //listDeed = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.SpGet_DeedReportByPage, ht, StaticInfos.conStringOracle.ToString());
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

        public async Task<object> GetDeedReports(object[] datas, string reportPath, string repType)
        {
            string param = "[" + datas[1].ToString() + "]";
            object[] data = JsonConvert.DeserializeObject<object[]>(param);
            object bytes = null; bool resstate = false;
            List<DataTable> listDataTable = new List<DataTable>();

            try
            {
                dynamic objRes = await GetByPage(data);
                var dataListDeed = Extension.GetReportDataTable(objRes.listDeed.ToString());

                dataListDeed = Extension.AddDataSetName(dataListDeed, "DataSet1");
                listDataTable.Add(dataListDeed);

                bytes = ReportingService.Report(listDataTable, reportPath, repType);

                if (bytes != null)
                {
                    resstate = true;
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                bytes,
                resstate
            };
        }

        public async Task<object> GetDeedReport(object[] data, string reportPath, string repType)
        {
            object bytes = null; bool resstate = false;
            List<DataTable> listDataTable = new List<DataTable>();

            try
            {
                DeedMgt deed = new DeedMgt();
                dynamic objRes = await deed.GetReportDataByID(data);
                var dataListDeed = Extension.GetReportDataTable(objRes.objDeed.ToString());

                string jsonViaDeed = objRes.objViaDeed.ToString();
                //DataTable viaDeed = Extension.GetReportDataTable(objRes.objViaDeed.ToString());
                //var list = viaDeed.AsEnumerable().Select(r => r["deedNoVia"].ToString());
                //string viaDeedStr= string.Join(",", list);
                if (!string.IsNullOrEmpty(jsonViaDeed))
                {
                    var objects = JsonConvert.DeserializeObject<List<dynamic>>(jsonViaDeed);
                    var viaDeedArray = objects.Select(obj => JsonConvert.SerializeObject(obj.deedNoVia)).ToArray();
                    string viaDeedStr = string.Join(", ", viaDeedArray);

                    dataListDeed.Rows[0]["deedNoVia"] = viaDeedStr;
                }

                var dataListOwner = Extension.GetReportDataTable(objRes.objOwner.ToString());
                var dataListSelle = Extension.GetReportDataTable(objRes.objSeller.ToString());
                var dataListDoc = Extension.GetReportDataTable(objRes.objDoc.ToString());

                dataListDeed = Extension.AddDataSetName(dataListDeed, "DataSet1");
                listDataTable.Add(dataListDeed);

                dataListOwner = Extension.AddDataSetName(dataListOwner, "DataSet2");
                listDataTable.Add(dataListOwner);

                dataListSelle = Extension.AddDataSetName(dataListSelle, "DataSet3");
                listDataTable.Add(dataListSelle);

                dataListDoc = Extension.AddDataSetName(dataListDoc, "DataSet4");
                listDataTable.Add(dataListDoc);

                bytes = ReportingService.Report(listDataTable, reportPath, repType);

                if (bytes != null)
                {
                    resstate = true;
                }
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                bytes,
                resstate
            };
        }

        #endregion
    }
}