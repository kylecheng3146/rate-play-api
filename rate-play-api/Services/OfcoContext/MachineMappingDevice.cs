using System;
using System.Collections.Generic;

namespace ofco_projects_api.Services.OfcoContext
{
    public partial class MachineMappingDevice
    {
        public string MahId { get; set; }
        public string OMahId { get; set; }
        public string CheckFlag { get; set; }
        public string Memo { get; set; }
        public string UpdManId { get; set; }
        public string UpdMan { get; set; }
        public DateTime? UpdTime { get; set; }
        public string SetManId { get; set; }
        public string SetMan { get; set; }
        public DateTime? SetTime { get; set; }
    }
}
