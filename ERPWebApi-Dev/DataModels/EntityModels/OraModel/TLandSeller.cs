using System;
using System.Collections.Generic;

namespace DataModels.EntityModels.OraModel
{
    public partial class TLandSeller
    {
        public string? DeedId { get; set; }
        public string? SellerId { get; set; }
        public string Isgong { get; set; } = null!;
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
