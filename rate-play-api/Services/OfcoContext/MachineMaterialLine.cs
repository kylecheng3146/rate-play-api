using System;
using System.Collections.Generic;

namespace rate_play_api.Services.OfcoContext
{
    public partial class MachineMaterialLine
    {
        public long No { get; set; }
        public string MahId { get; set; }
        public string Material { get; set; }
        public string MaterialName { get; set; }
        public string MaterialId { get; set; }
        public string MaterialUniqe { get; set; }
        public string SetManId { get; set; }
        public string SetMan { get; set; }
        public DateTime? SetTime { get; set; }
        public string CheckFlag { get; set; }
        public DateTime? UpdTime { get; set; }
        public string UpdManId { get; set; }
        public string UpdMan { get; set; }
    }
}
