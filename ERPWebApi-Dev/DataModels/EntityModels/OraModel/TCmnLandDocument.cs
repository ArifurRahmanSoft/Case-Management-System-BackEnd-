using System;
using System.Collections.Generic;

namespace DataModels.EntityModels.OraModel
{
    public partial class TCmnLandDocument
    {
        public int DocumentId { get; set; }
        public int UpTypeId { get; set; }
        public string UpTypeName { get; set; } = null!;
        public string UpTypeNo { get; set; } = null!;
        public string UpTypeOthers { get; set; } = null!;
        public string Remarks { get; set; } = null!;
        public int? UpParentTypeId { get; set; }
        public string? DeedOid { get; set; }
        public string? RoleIds { get; set; }
        public int? UpTypeSeq { get; set; }
        public string? DocPath { get; set; }
        public string? DocVPath { get; set; }
        public string Isactive { get; set; } = null!;
        public string Isdelete { get; set; } = null!;
        public string Createby { get; set; } = null!;
        public DateTime Createon { get; set; }
        public string Createpc { get; set; } = null!;
        public string? Updateby { get; set; }
        public DateTime? Updateon { get; set; }
        public string? Updatepc { get; set; }
        public string? Deleteby { get; set; }
        public DateTime? Deleteon { get; set; }
        public string? Deletepc { get; set; }
    }
}
