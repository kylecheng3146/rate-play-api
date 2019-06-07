using System;
using System.Collections.Generic;

namespace rate_play_api.Services.RatePlayContext
{
    public partial class Member
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string MemSex { get; set; }
        public string Token { get; set; }
    }
}
