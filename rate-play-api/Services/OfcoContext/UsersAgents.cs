using System;
using System.Collections.Generic;

namespace rate_play_api.Services.OfcoContext
{
    public partial class UsersAgents
    {
        public string UserId { get; set; }
        public string AgentId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Memo { get; set; }
        public string UpdManId { get; set; }
        public string UpdMan { get; set; }
        public DateTime? UpdTime { get; set; }
        public string SetManId { get; set; }
        public string SetMan { get; set; }
        public DateTime? SetTime { get; set; }
        public string CheckFlag { get; set; }
    }
}
