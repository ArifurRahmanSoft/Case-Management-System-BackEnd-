using System;
using System.Collections.Generic;

namespace DataModels.EntityModels.OraModel
{
    public partial class TCaseLand
    {
        public string Oid { get; set; } = null!;
        public string? Caseno { get; set; }
        public string? RefCaseNo { get; set; }
        public string? CaseTypeId { get; set; }
        public string? CasePriorityId { get; set; }
        public string? CourtId { get; set; }
        public DateTime? CaseDate { get; set; }
        public string? Districtid { get; set; }
        public string? Thanaid { get; set; }
        public string? Mouzaid { get; set; }
        public string? Badi { get; set; }
        public string? Bibadi { get; set; }
        public string? CompanyId { get; set; }
        public string? Deedids { get; set; }
        public string? TotalLand { get; set; }
        public string? SurveyType { get; set; }
        public string? CaseDetails { get; set; }
        public string? CurrentStatus { get; set; }
        public string? Khatiancs { get; set; }
        public string? Khatiansa { get; set; }
        public string? Khatiandr { get; set; }
        public string? Khatianrs { get; set; }
        public string? Khatianbs { get; set; }
        public string? Dagcs { get; set; }
        public string? Dagsa { get; set; }
        public string? Dagdr { get; set; }
        public string? Dagrs { get; set; }
        public string? Dagbs { get; set; }
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
        public string? Deednos { get; set; }
    }
}
