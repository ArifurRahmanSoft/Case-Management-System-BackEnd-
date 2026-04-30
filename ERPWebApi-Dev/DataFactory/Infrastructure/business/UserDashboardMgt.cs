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
    public class UserDashboardMgt
    {
        #region Variable declaration & initialization
        Hashtable ht = null;
        OracleCommand ocmd = null;
        IGenericFactoryOracle<vmCmnParameter> Ora_Generic_vmCmnParameter = null;
        ModelContext _ctxOra = null;
        #endregion

        #region All Methods

        public async Task<object> GetAllEntryUserByTable(object[] data) //vmCmnParameters cmnParam
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listEntryUser = string.Empty;
            try
            {
                ocmd = new OracleCommand();
                ocmd.Parameters.Add("gresult", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("tableName", OracleDbType.Varchar2).Value = param.strId;
                listEntryUser = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_Menu_Wise_Entry_User, ocmd, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                listEntryUser
            };
        }

        public async Task<object> GetAllEntryUserActivity(object[] data) //vmCmnParameters cmnParam
        {
            vmCmnParameter param = JsonConvert.DeserializeObject<vmCmnParameter>(data[0].ToString());
            Ora_Generic_vmCmnParameter = new GenericFactoryOracle<vmCmnParameter>();
            string listUserActivity = string.Empty;
            try
            {
                ocmd = new OracleCommand();
                //ocmd.Parameters.Add("gresult", OracleDbType.Clob).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("gresult", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                ocmd.Parameters.Add("tableName", OracleDbType.Varchar2).Value = param.strId;
                ocmd.Parameters.Add("creatorId", OracleDbType.Varchar2).Value = param.strId2;
                ocmd.Parameters.Add("entryDate", OracleDbType.Varchar2).Value = param.strId3;
                listUserActivity = await Ora_Generic_vmCmnParameter.ExecuteCommandString(StoredProcedure.Ora_SpGet_All_User_Activity, ocmd, StaticInfos.conStringOracle.ToString());
            }
            catch (Exception ex)
            {
                Logs.Bug(ex);
            }
            return new
            {
                listUserActivity
            };
        }

        #endregion
    }
}