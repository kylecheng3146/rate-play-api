using System;
using System.Collections.Generic;

namespace rate_play_api.Services.OfcoContext
{
    public partial class MachineWorkOrderKeg
    {
        public long No { get; set; }
        public string MahId { get; set; }
        public string WorkOrder { get; set; }
        public int? WorkKegCount { get; set; }
        public decimal? WorkKegWeight { get; set; }
        public string WorkKegUniqueCode { get; set; }
        public string SetManId { get; set; }
        public string SetMan { get; set; }
        public DateTime? SetTime { get; set; }
        public string CheckFlag { get; set; }
        public DateTime? UpdTime { get; set; }
        public string UpdManId { get; set; }
        public string UpdMan { get; set; }
    }
}
