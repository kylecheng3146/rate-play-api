using System;
using System.Collections.Generic;

namespace rate_play_api.Services.OfcoContext
{
    public partial class 工令作業
    {
        public string 單據編號 { get; set; }
        public string 單據日期 { get; set; }
        public string 派工屬性 { get; set; }
        public string 派工單號 { get; set; }
        public string 舊系統工單 { get; set; }
        public string 工令產生時間 { get; set; }
        public string 派工週期 { get; set; }
        public decimal? Lot { get; set; }
        public string 排工日期 { get; set; }
        public string 月份 { get; set; }
        public string 機型 { get; set; }
        public string 機台 { get; set; }
        public string 委外商 { get; set; }
        public string 品號 { get; set; }
        public string 異動前品號 { get; set; }
        public string 品名 { get; set; }
        public decimal? 訂單總需求量 { get; set; }
        public decimal? 生產備品數量 { get; set; }
        public decimal? 生產通知數量 { get; set; }
        public decimal? 使用庫存量 { get; set; }
        public decimal? 使用庫存量白皮 { get; set; }
        public decimal? 使用庫存量電鍍 { get; set; }
        public decimal? 應派工數量 { get; set; }
        public decimal? 派工數量 { get; set; }
        public string 線材品號 { get; set; }
        public string 線材品名 { get; set; }
        public decimal? 標準重量 { get; set; }
        public decimal? 原料重量 { get; set; }
        public decimal? 線材重量 { get; set; }
        public string 原料重量有調整 { get; set; }
        public string 模具編號 { get; set; }
        public string 模具說明 { get; set; }
        public string 工令圖號 { get; set; }
        public string 管製卡號 { get; set; }
        public string 最先製程 { get; set; }
        public string 製作對象 { get; set; }
        public string 用料 { get; set; }
        public string 發料 { get; set; }
        public string 打頭 { get; set; }
        public string 輾牙 { get; set; }
        public string 熱處理 { get; set; }
        public string 電鍍 { get; set; }
        public string 門檻 { get; set; }
        public string 備註 { get; set; }
        public string 作廢 { get; set; }
        public string 作廢原因 { get; set; }
        public string 功能表名稱作廢 { get; set; }
        public string 來源單號作廢 { get; set; }
        public string 規劃預排序號 { get; set; }
        public int? 工單列印次數 { get; set; }
        public int? 管制卡列印次數 { get; set; }
        public int? 嘜頭列印次數 { get; set; }
        public string 關聯工單 { get; set; }
        public decimal? 線材重量Old { get; set; }
        public string 品號0525 { get; set; }
        public decimal? 派工數量0809 { get; set; }
        public decimal? 原料重量Old { get; set; }
        public string 機型0810 { get; set; }
        public string 機台0810 { get; set; }
        public string 線材品號0905 { get; set; }
        public string 線材品名0905 { get; set; }
        public decimal? 標準重量Old { get; set; }
        public string 品號異動說明 { get; set; }
        public string 舊系統工單異動說明 { get; set; }
        public string 月份old { get; set; }
        public string 派工異動檢核 { get; set; }
        public string 派工異動說明 { get; set; }
        public string 補單 { get; set; }
        public string 派工特殊要求 { get; set; }
        public decimal? 計劃總成本 { get; set; }
        public decimal? 實際總金額 { get; set; }
        public decimal? 工單計劃加權 { get; set; }
    }
}
