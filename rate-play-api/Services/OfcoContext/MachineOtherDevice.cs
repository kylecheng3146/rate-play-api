using System;
using System.Collections.Generic;

namespace rate_play_api.Services.OfcoContext
{
    public partial class MachineOtherDevice
    {
        public string OMahId { get; set; }
        public string OMahType { get; set; }
        public string OMahTypeName { get; set; }
        public string OMahModel { get; set; }
        public decimal? CurWeight { get; set; }
        public decimal? CurWeightTime { get; set; }
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
