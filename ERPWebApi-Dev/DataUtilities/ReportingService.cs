//using DataModels.EntityModels.ERPModel;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

using Microsoft.AspNetCore.Http;
//using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.Reporting.NETCore;
//using AspNetCore.Reporting;
//using DataModels.ViewModels;

namespace DataUtilities
{
    public class ReportingService
    {
        public static object Report19(List<DataTable> dataList, string paramList, string filePath, string repType)
        {
            object bytes = null; string mimeType = string.Empty, paramSetName = "ParamSet", dataSetName = string.Empty; int extension = 1;
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    //Initialize local report with path
                    AspNetCore.Reporting.LocalReport localReport = new AspNetCore.Reporting.LocalReport(filePath);

                    //Set Parameters
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    DataTable parameterList = Extension.GetDataTable(paramList);

                    //Add DataSource
                    foreach (var dt in dataList)
                    {
                        dataSetName = dt.Rows[0].Field<string>(Extension.dataColumn);
                        localReport.AddDataSource(dataSetName, dt);
                    }

                    localReport.AddDataSource(paramSetName, parameterList);

                    //Get values by type
                    dynamic bites = localReport.Execute(renderType(repType), extension, parameters, mimeType);
                    if (bites != null)
                    {
                        bytes = bites.MainStream;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return bytes;
        }

        public static object Report19(List<DataTable> dataList, string filePath, string repType)
        {
            object bytes = null; string mimeType = string.Empty, paramSetName = "ParamSet", dataSetName = string.Empty; int extension = 1;
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    //Initialize local report with path
                    AspNetCore.Reporting.LocalReport localReport = new AspNetCore.Reporting.LocalReport(filePath);

                    //Set Parameters
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    DataTable parameterList = new DataTable();

                    //Add DataSource
                    foreach (var dt in dataList)
                    {
                        dataSetName = dt.Rows[0].Field<string>(Extension.dataColumn);
                        localReport.AddDataSource(dataSetName, dt);
                    }

                    localReport.AddDataSource(paramSetName, parameterList);

                    //Get values by type
                    dynamic bites = localReport.Execute(renderType(repType), extension, parameters, mimeType);
                    if (bites != null)
                    {
                        bytes = bites.MainStream;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return bytes;
        }

        private static AspNetCore.Reporting.RenderType renderType(string type)
        {
            AspNetCore.Reporting.RenderType rndrTyp = new AspNetCore.Reporting.RenderType();
            switch (type.ToLower())
            {
                case "doc":
                    rndrTyp = AspNetCore.Reporting.RenderType.Word;
                    break;
                case "docx":
                    rndrTyp = AspNetCore.Reporting.RenderType.WordOpenXml;
                    break;
                case "xls":
                    rndrTyp = AspNetCore.Reporting.RenderType.Excel;
                    break;
                case "xlsx":
                    rndrTyp = AspNetCore.Reporting.RenderType.ExcelOpenXml;
                    break;
                case "pdf":
                    rndrTyp = AspNetCore.Reporting.RenderType.Pdf;
                    break;
                case "image":
                    rndrTyp = AspNetCore.Reporting.RenderType.Image;
                    break;
                case "html":
                    rndrTyp = AspNetCore.Reporting.RenderType.Html;
                    break;
                default:
                    rndrTyp = AspNetCore.Reporting.RenderType.Pdf;
                    break;
            }

            return rndrTyp;
        }

        public static object Report(List<DataTable> dataList, string paramList, string filePath, string repType)
        {
            object bytes = null; string mimeType = string.Empty, paramSetName = "ParamSet", dataSetName = string.Empty; int extension = 1;
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    //Initialize local report with path
                    LocalReport localReport = new LocalReport();
                    localReport.ReportPath = filePath;

                    //Set Parameters
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    DataTable parameterList = Extension.GetDataTable(paramList);

                    //Add DataSource
                    foreach (var dt in dataList)
                    {
                        dataSetName = dt.Rows[0].Field<string>(Extension.dataColumn);
                        localReport.DataSources.Add(new ReportDataSource(dataSetName, dt));
                    }

                    localReport.DataSources.Add(new ReportDataSource(paramSetName, parameterList));

                    //Get values by type
                    bytes = localReport.Render(repType);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return bytes;
        }

        public static object Report(List<DataTable> dataList, string filePath, string repType)
        {
            object bytes = null; string mimeType = string.Empty, paramSetName = "ParamSet", dataSetName = string.Empty; int extension = 1;
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    //Initialize local report with path
                    LocalReport localReport = new LocalReport();
                    localReport.ReportPath = filePath;
                    localReport.EnableHyperlinks = true;                    

                    //Set Parameters
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    DataTable parameterList = new DataTable();

                    //Add DataSource
                    foreach (var dt in dataList)
                    {
                        dataSetName = dt.Rows[0].Field<string>(Extension.dataColumn);
                        localReport.DataSources.Add(new ReportDataSource(dataSetName, dt));
                    }

                    localReport.DataSources.Add(new ReportDataSource(paramSetName, parameterList));

                    //Get values by type
                    bytes = localReport.Render(repType);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return bytes;
        }
    }
}