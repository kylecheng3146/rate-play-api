using System;
using System.Collections.Generic;

namespace rate_play_api.Services.OfcoContext
{
    public partial class MachineDetail
    {
        public long No { get; set; }
        public DateTime? Time { get; set; }
        public string MahType { get; set; }
        public string MahId { get; set; }
        public string MahName { get; set; }
        public string MahUniqe { get; set; }
        public string Value { get; set; }
        public string Man { get; set; }
        public string ManId { get; set; }
        public string OrderId { get; set; }
        public string Status { get; set; }
    }
}
