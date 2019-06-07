using System;
using System.Collections.Generic;

namespace rate_play_api.Services.OfcoContext
{
    public partial class 線材櫃
    {
        public string 品號 { get; set; }
        public string 品名 { get; set; }
        public string 材質碼 { get; set; }
        public string 線材線徑碼 { get; set; }
        public string 製造商碼 { get; set; }
        public string 加工狀態碼 { get; set; }
        public string 單位 { get; set; }
        public decimal? 技術抽線率 { get; set; }
        public decimal? 標準重量 { get; set; }
        public string 建檔日期 { get; set; }
        public string 建檔部門 { get; set; }
        public string 建檔人 { get; set; }
        public string 建檔單號 { get; set; }
        public string 修改單號 { get; set; }
        public string 異動日期 { get; set; }
    }
}
