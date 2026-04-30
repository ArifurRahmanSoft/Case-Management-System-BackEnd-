using DataFactory.BaseFactory;
using DataFactory.Infrastructure.common.menus;
using DataModels.EntityModels.OraModel;
using DataModels.ViewModels;
using DataUtilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFactory.Infrastructure.business
{
    public class TestReportMgt
    {

        #region Variable declaration & initialization
        ModelContext _ctxOr = null;
        OracleCommand ocmd = null;
        private IGenericFactoryOracle<vmCmnParameter> OraGeneric_vmCmnParameter = null;
        Hashtable ht = null;
        #endregion

        #region Daily Task Hazira

        public async Task<object> GetTestReport(string reportPath, string repType, vmCmnParameter cparam)
        {
            OraGeneric_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            object bytes = null; bool resstate = false;
            List<DataTable> listDataTable = new List<DataTable>();
            DataTable dataList = new DataTable();
            try
            {   
                var rm = new MenuMgt();
                dynamic objRes = await rm.GetOraRoleWiseMenu(cparam);
                dataList = Extension.GetReportDataTable(objRes.listRoleMenu.ToString());

                dataList = Extension.AddDataSetName(dataList, "DataSet1");
                listDataTable.Add(dataList);

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
