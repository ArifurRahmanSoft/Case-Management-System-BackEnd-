using System;
using System.Collections.Generic;

namespace DataModels.EntityModels.OraModel
{
    public partial class TCaseHearingAdvocate
    {
        public string Oid { get; set; } = null!;
        public string? CaseOid { get; set; }
        public string? AdvocateId { get; set; }
        public string? CaseStatus { get; set; }
        public string? HearingNoteDetails { get; set; }
        public decimal? Expense { get; set; }
        public string? RowNum { get; set; }
        public string? Column2 { get; set; }
        public string? Column3 { get; set; }
        public string? Column4 { get; set; }
        public string? Column5 { get; set; }
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
