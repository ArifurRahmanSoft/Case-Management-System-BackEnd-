using System;
using System.Collections.Generic;

namespace DataModels.EntityModels.OraModel
{
    public partial class TLandMutation
    {
        public string Oid { get; set; } = null!;
        public string KhatianNo { get; set; } = null!;
        public string JotNo { get; set; } = null!;
        public string? CaseNo { get; set; }
        public DateTime? MutationDate { get; set; }
        public string ServeyId { get; set; } = null!;
        public string DistrictId { get; set; } = null!;
        public string ThanaId { get; set; } = null!;
        public string MouzaId { get; set; } = null!;
        public string? DagNos { get; set; }
        public string? DeedNos { get; set; }
        public string? LandClass { get; set; }
        public string? TotalLand { get; set; }
        public decimal? DcrFee { get; set; }
        public string Isactive { get; set; } = null!;
        public string Iscancel { get; set; } = null!;
        public string Createby { get; set; } = null!;
        public DateTime Createon { get; set; }
        public string Createpc { get; set; } = null!;
        public string? Updateby { get; set; }
        public DateTime? Updateon { get; set; }
        public string? Updatepc { get; set; }
        public string? Cancelby { get; set; }
        public DateTime? Cancelon { get; set; }
        public string? Cancelpc { get; set; }
        public string? DocPath { get; set; }
        public string? DocVPath { get; set; }
        public long? LastPayYear { get; set; }
        public DateTime? LastPayDate { get; set; }
        public long? LastPayYearBn { get; set; }
        public string? LastPayDateBn { get; set; }
        public string? LastPayMonthBn { get; set; }
        public string? LastPayDateStrBn { get; set; }
        public decimal? TotalDue { get; set; }
        public decimal? PaymentUnit { get; set; }
    }
}
