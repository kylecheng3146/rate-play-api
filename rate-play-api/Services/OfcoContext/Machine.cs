using System;
using System.Collections.Generic;

namespace ofco_projects_api.Services.OfcoContext
{
    public partial class Machine
    {
        public string MahId { get; set; }
        public string MahType { get; set; }
        public string MahTypeName { get; set; }
        public string MahModel { get; set; }
        public int? CurCount { get; set; }
        public DateTime? CurCountTime { get; set; }
        public int? CountSec { get; set; }
        public DateTime? CountSecTime { get; set; }
        public int? SetCount { get; set; }
        public DateTime? SetCountTime { get; set; }
        public string CheckFlag { get; set; }
        public string Memo { get; set; }
        public string UpdManId { get; set; }
        public string UpdMan { get; set; }
        public DateTime? UpdTime { get; set; }
        public string SetManId { get; set; }
        public string SetMan { get; set; }
        public DateTime? SetTime { get; set; }
        public string UniqueCode { get; set; }
    }
}
