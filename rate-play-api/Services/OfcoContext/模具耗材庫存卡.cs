using System;
using System.Collections.Generic;

namespace rate_play_api.Services.OfcoContext
{
    public partial class 模具耗材庫存卡
    {
        public int 流水號 { get; set; }
        public string 時間 { get; set; }
        public string 類別 { get; set; }
        public string 品號 { get; set; }
        public decimal? 增量數量 { get; set; }
        public decimal? 減量數量 { get; set; }
        public string 入庫日期 { get; set; }
        public string 屬性 { get; set; }
        public string 來源功能表 { get; set; }
        public string 來源單號 { get; set; }
        public string 入庫採購單 { get; set; }
        public string 入庫請購單 { get; set; }
        public string 入庫請購需求日 { get; set; }
        public decimal? 入庫單價 { get; set; }
        public string 購買幣別 { get; set; }
        public string 購買單價 { get; set; }
        public decimal? 轉台幣匯率 { get; set; }
        public decimal? 轉台幣單價 { get; set; }
        public decimal? 加權成本 { get; set; }
        public decimal? 移倉成本 { get; set; }
    }
}
