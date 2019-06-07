using System;
using System.Collections.Generic;

namespace rate_play_api.Services.OfcoContext
{
    public partial class Users
    {
        public string UserId { get; set; }
        public string Pwd { get; set; }
        public string Salt { get; set; }
        public string Name { get; set; }
        public string CheckFlag { get; set; }
        public string Memo { get; set; }
        public string UpdManId { get; set; }
        public string UpdMan { get; set; }
        public DateTime? UpdTime { get; set; }
        public string SetManId { get; set; }
        public string SetMan { get; set; }
        public DateTime? SetTime { get; set; }
        public string UniqueCode { get; set; }
        public string AuthToken { get; set; }
    }
}
