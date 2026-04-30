using System;
using System.Collections.Generic;

namespace DataModels.EntityModels.OraModel
{
    public partial class TCaseDocument
    {
        public decimal Documentid { get; set; }
        public string? Referenceid { get; set; }
        public string? Documentname { get; set; }
        public string? Documenttype { get; set; }
        public decimal? Documentsize { get; set; }
        public string? Basepath { get; set; }
        public string? Originaldocname { get; set; }
        public string? Documentpath { get; set; }
        public string? Documentfullpath { get; set; }
        public string? Virtualpath { get; set; }
        public string? Remarks { get; set; }
        public string? Isactive { get; set; }
        public string? Iscancel { get; set; }
        public string? Createby { get; set; }
        public DateTime? Createon { get; set; }
        public string? Createpc { get; set; }
        public string? Updateby { get; set; }
        public DateTime? Updateon { get; set; }
        public string? Updatepc { get; set; }
        public string? Cancelby { get; set; }
        public DateTime? Cancelon { get; set; }
        public string? Cancelpc { get; set; }
        public string? Inputname { get; set; }
        public string? Inputnumber { get; set; }
        public string? InputtypeId { get; set; }
        public string? Inputtype { get; set; }
        public string? Inputothers { get; set; }
    }
}
