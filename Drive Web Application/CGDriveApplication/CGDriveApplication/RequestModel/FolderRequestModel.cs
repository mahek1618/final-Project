using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGDriveApplication.RequestModel
{
    public class FolderRequestModel
    {
        public string FolderName { get; set; }
        public int? FCreatedBy { get; set; }
        public DateTime? FCreatedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
