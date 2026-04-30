using System;
using System.Collections.Generic;

namespace DataModels.EntityModels.OraModel
{
    public partial class TLandDeedBakA
    {
        public string Oid { get; set; } = null!;
        public string? DeedCode { get; set; }
        public string DeedNo { get; set; } = null!;
        public DateTime DeedDate { get; set; }
        public string? DeedNoVia { get; set; }
        public string? CaseNo { get; set; }
        public string? DivisionId { get; set; }
        public string DistrictId { get; set; } = null!;
        public string ThanaId { get; set; } = null!;
        public string? PostCodeNo { get; set; }
        public string MouzaId { get; set; } = null!;
        public string? RegistryOfficeId { get; set; }
        public string? LandOfficeId { get; set; }
        public string? HoldingNo { get; set; }
        public string? LandClass { get; set; }
        public string? KhatianCs { get; set; }
        public string? KhatianSa { get; set; }
        public string? KhatianDr { get; set; }
        public string? KhatianRs { get; set; }
        public string? KhatianBs { get; set; }
        public string? DagCs { get; set; }
        public string? DagSa { get; set; }
        public string? DagDr { get; set; }
        public string? DagRs { get; set; }
        public string? DagBs { get; set; }
        public string? TotalLandInDag { get; set; }
        public string? PurchasedLand { get; set; }
        public long? PurchaseAmount { get; set; }
        public string? MutatedLand { get; set; }
        public string? NotMutatedLand { get; set; }
        public string? MutationKhatianNo { get; set; }
        public string? MutationJotNo { get; set; }
        public decimal? LdTaxAmount { get; set; }
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
        public string? Isposted { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? DeedViaNoT { get; set; }
    }
}
