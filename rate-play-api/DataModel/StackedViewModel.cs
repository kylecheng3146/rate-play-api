using System;
using System.Collections.Generic;

namespace rate_play_api.DataModel {
    public class StackedViewModel {
        public string StackedDimensionOne { get; set; }
        public List<SimpleReportViewModel> LstData { get; set; }
    }
}