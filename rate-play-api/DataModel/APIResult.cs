using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ofco_projects_api.Model {
    /// <summary>
    /// 呼叫外部 API 要顯示的模型資料
    /// </summary>
    public class APIResult {
        /// <summary>
        /// http呼叫成功與否
        /// </summary>
        public Boolean callStatus { get; set; }
        /// <summary>
        /// 呼叫的url
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 來自url的response
        /// </summary>
        public string response { get; set; }
        /// <summary>
        /// 來自url的statusCode
        /// </summary>
        public int statusCode { get; set; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string errorMessage { get; set; }
    }
}