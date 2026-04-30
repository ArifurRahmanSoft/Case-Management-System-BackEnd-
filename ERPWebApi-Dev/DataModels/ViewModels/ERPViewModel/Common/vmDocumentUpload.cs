using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ViewModels
{
    public class vmCmnDocument
    {
        public decimal? documentId { get; set; }
        public string? referenceId { get; set; }
        public string? inputName { get; set; }
        public string? inputNumber { get; set; }
        public string? inputTypeId { get; set; }
        public string? inputType { get; set; }
        public string? inputOthers { get; set; }
        public string? documentName { get; set; }
        public string? documentType { get; set; }
        public decimal? documentSize { get; set; }
        public string? basePath { get; set; }
        public string? originalDocName { get; set; }
        public string? documentPath { get; set; }
        public string? documentFullPath { get; set; }
        public string? virtualPath { get; set; }
        public string? remarks { get; set; }
        public bool isActive { get; set; }
        public bool isCancel { get; set; }
        public string createBy { get; set; }
    }    
}
