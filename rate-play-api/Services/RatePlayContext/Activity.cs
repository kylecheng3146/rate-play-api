using System;
using System.Collections.Generic;

namespace rate_play_api.Services.RatePlayContext
{
    public partial class Activity
    {
        public int Id { get; set; }
        public string ActId { get; set; }
        public string ActMonth { get; set; }
        public string ActName { get; set; }
        public string ActCity { get; set; }
        public string ActLink { get; set; }
        public string ActSou { get; set; }
        public string ActSouper { get; set; }
    }
}
