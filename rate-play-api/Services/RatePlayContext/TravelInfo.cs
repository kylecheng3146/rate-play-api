using System;
using System.Collections.Generic;

namespace rate_play_api.Services.RatePlayContext
{
    public partial class TravelInfo
    {
        public int Id { get; set; }
        public string CouId { get; set; }
        public string CityNo { get; set; }
        public string Weather { get; set; }
        public string Climate { get; set; }
        public string Wear { get; set; }
        public string ActId { get; set; }
        public string CurId { get; set; }
    }
}
