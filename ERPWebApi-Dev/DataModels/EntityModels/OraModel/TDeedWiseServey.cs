using System;
using System.Collections.Generic;

namespace DataModels.EntityModels.OraModel
{
    public partial class TDeedWiseServey
    {
        public string? DeedId { get; set; }
        public string? ServeyId { get; set; }
        public string? ServeyTypeId { get; set; }
        public string? ServeyNo { get; set; }
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
