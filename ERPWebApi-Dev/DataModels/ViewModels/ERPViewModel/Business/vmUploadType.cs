using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.ViewModels.ERPViewModel.Business
{
    public class vmUploadType
    {
        public int? typeId { get; set; }
        public string typeName { get; set; }
        public int? parentTypeId { get; set; }
        public string roleIds { get; set; }
        public int typeSeq { get; set; }
        public bool isActive { get; set; }
    }
}
