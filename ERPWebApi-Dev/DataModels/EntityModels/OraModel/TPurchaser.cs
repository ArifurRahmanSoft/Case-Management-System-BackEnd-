using System;
using System.Collections.Generic;

namespace DataModels.EntityModels.OraModel
{
    public partial class TPurchaser
    {
        public string Oid { get; set; } = null!;
        public string? NameEn { get; set; }
        public string? NameBn { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? SpouseName { get; set; }
        public string? AddressEn { get; set; }
        public string? AddressBn { get; set; }
        public string? NidNo { get; set; }
        public string? RegistrationNo { get; set; }
        public string Isgong { get; set; } = null!;
        public string Iscom { get; set; } = null!;
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
    }
}
