using System;
using System.Collections.Generic;

namespace ofco_projects_api.DataModel {
    public class StackedViewModel {
        public string StackedDimensionOne { get; set; }
        public List<SimpleReportViewModel> LstData { get; set; }
    }
}