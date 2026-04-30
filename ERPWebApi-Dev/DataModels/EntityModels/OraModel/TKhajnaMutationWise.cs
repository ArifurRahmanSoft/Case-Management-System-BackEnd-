using System;
using System.Collections.Generic;

namespace DataModels.EntityModels.OraModel
{
    public partial class TKhajnaMutationWise
    {
        public string Oid { get; set; } = null!;
        public string? MutationId { get; set; }
        public long? KhajnaYear { get; set; }
        public DateTime? KhajnaDate { get; set; }
        public long? KhajnaYearBn { get; set; }
        public string? KhajnaDateBn { get; set; }
        public string? KhajnaMonthBn { get; set; }
        public string? KhajnaDateStrBn { get; set; }
        public long? TotalDueYear { get; set; }
        public long? LastDueYear { get; set; }
        public decimal? KhajnaAmount { get; set; }
        public decimal? FineAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public long? LastPayYear { get; set; }
        public DateTime? LastPayDate { get; set; }
        public long? LastPayYearBn { get; set; }
        public string? LastPayDateBn { get; set; }
        public string? LastPayMonthBn { get; set; }
        public string? LastPayDateStrBn { get; set; }
        public decimal? LastDue { get; set; }
        public decimal? LastPayUnit { get; set; }
        public string? DocPath { get; set; }
        public string? DocVPath { get; set; }
        public string? Remarks { get; set; }
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
        public string? FiscalYearEng { get; set; }
    }
}
