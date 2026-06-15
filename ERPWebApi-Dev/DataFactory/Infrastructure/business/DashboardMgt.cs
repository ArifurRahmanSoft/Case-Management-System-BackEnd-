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
    public class DashboardMgt
    {
        #region Variable declaration & initialization
        Hashtable ht = null;
        OracleCommand ocmd = null;
        IGenericFactoryOracle<vmCmnParameter> Ora_Generic_vmCmnParameter = null;
        ModelContext _ctxOra = null;
        #endregion

        #region All Methods



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