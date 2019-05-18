using System;
using System.Collections.Generic;

namespace ofco_projects_api.Services.OfcoContext
{
    public partial class MachineWorkOrder
    {
        public long No { get; set; }
        public string MahId { get; set; }
        public string WorkOrder { get; set; }
        public string SetManId { get; set; }
        public string SetMan { get; set; }
        public DateTime? SetTime { get; set; }
    }
}
