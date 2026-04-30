using System;
using System.Collections.Generic;

namespace DataModels.EntityModels.OraModel
{
    public partial class TCaseAdvocate
    {
        public string Oid { get; set; } = null!;
        public string? NameEn { get; set; }
        public string? NameBn { get; set; }
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
    }
}
