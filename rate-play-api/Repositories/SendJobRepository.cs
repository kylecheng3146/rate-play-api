// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using rate_play_api.Interfaces;
// using rate_play_api.Services.OfcoContext;
// using rate_play_api.Utilities;

// namespace rate_play_api.Repositories
// {
//     public class SendJobRepository : IBaseRepository<工令作業>
//     {
//         private readonly OfcoContext _context;
//         public SendJobRepository(OfcoContext context)
//         {
//             _context = context;
//         }

//         #region
//         /// <summary>
//         /// 新增一筆資料.
//         /// </summary>
//         /// <param name="model">User資料表.</param>
//         /// <returns>
//         /// rowsAffected.
//         /// </returns>
//         ///
//         public async Task<int> AddDataAsync(工令作業 model)
//         {
//             int rowsAffected = 0;
//             _context.工令作業.Add(model);
//             rowsAffected = await _context.SaveChangesAsync();
//             return rowsAffected;
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 刪除特定一筆資料.
//         /// </summary>
//         /// <param name="工令作業">User資料表.</param>
//         /// <returns>
//         /// rowsAffected.
//         /// </returns>
//         ///
//         public async Task<int> DeleteDataAsync(工令作業 工令作業)
//         {
//             int rowsAffected = 0;
//             _context.工令作業.Remove(工令作業);
//             rowsAffected = await _context.SaveChangesAsync();
//             return rowsAffected;
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 搜尋全部工令作業資料
//         /// </summary>
//         /// <returns>
//         /// data list.
//         /// </returns>
//         ///
//         public IEnumerable<工令作業> GetAllData()
//         {
//             return _context.工令作業.ToList().OrderByDescending(x => x.派工屬性);
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 更新一筆資料
//         /// </summary>
//         /// <returns>The data async.</returns>
//         /// <param name="oldData">Old data.</param>
//         /// <param name="newData">New data.</param>
//         public async Task<int> UpdateDataAsync(工令作業 oldData, 工令作業 newData)
//         {
//             int rowsAffected = 0;
//             // if (Util.checkString(newData.Time.ToString())) {
//             //     oldData.Time = newData.Time;
//             // }
//             // if (Util.checkString(newData.Ip)) {
//             //     oldData.Ip = newData.Ip;
//             // }
//             // if (newData.Flow > 0) {
//             //     oldData.Flow = newData.Flow;
//             // }
//             // if (newData.FlowRate > 0) {
//             //     oldData.FlowRate = newData.FlowRate;
//             // }
//             // if (newData.Percentage > 0) {
//             //     oldData.Percentage = newData.Percentage;
//             // }
//             // if (newData.ConductivityRatio > 0) {
//             //     oldData.ConductivityRatio = newData.ConductivityRatio;
//             // }
//             // if (newData.TotalFlow > 0) {
//             //     oldData.TotalFlow = newData.TotalFlow;
//             // }
//             rowsAffected = await _context.SaveChangesAsync();
//             return rowsAffected;
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 搜尋最後工令作業資料
//         /// </summary>
//         /// <returns>
//         /// data list.
//         /// </returns>
//         ///
//         public 工令作業 GetLastData()
//         {
//             // long maxId = _context.工令作業.Max(x => x.No);
//             // var q = _context.工令作業.Where(x => x.No == maxId).First();
//             var q = new 工令作業();
//             return q;
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 搜尋七天工令作業資料
//         /// </summary>
//         /// <returns>
//         /// data list.
//         /// </returns>
//         ///
//         public object GetSevenDaysData()
//         {
//             var dateCriteria = DateTime.Now.Date.AddDays(-6); //建立日期範圍，今天～今天-6天
//             var group = new object();
//             // var group = (from a in _context.工令作業 where a.UpdTime >= dateCriteria && a.UpdTime < DateTime.Now.Date.AddDays(+1) select a)
//             //     .GroupBy(x => x.UpdTime.Date) //x.Time.Date意思為把date time日期後面都變為0, ex:2019-03-12 12:34:567 -> 2019-03-12 00:00:00.000
//             //     .Select(g => new {
//             //         Date = g.Key.ToString("yyyy-MM-dd"), //將date time格式化成"yyyy-MM-dd".
//             //             Count = g.Count(),
//             //             TotalFlow = g.Max(a => a.TotalFlow) //取得group後最大的總流量
//             //     });
//             return group;

//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 從ID判斷工令作業是否有值
//         /// </summary>
//         /// <param name="id">id.</param>
//         /// <param name="model">工令作業 資料表.</param>
//         /// <returns>
//         /// boolean.
//         /// </returns>
//         ///
//         public bool TryGetBySendJob(string work_code, out Object model)
//         {
//             model = _context.工令作業.Where(x => work_code.Equals(x.派工單號)).Select( r => new {
//                 機台 = r.機台,
//                 派工單號 = r.派工單號,
//                 工令圖號 = r.工令圖號,
//                 標準單支重 = "沒有欄位",
//                 螺絲料號 = "沒有欄位",
//                 派工數量 = r.派工數量,
//                 標準重量 = r.標準重量,
//                 料名 = "沒有欄位",
//                 線材品號 = r.線材品號,
//                 線材品名 = r.線材品名,
//                 原料重量 = r.原料重量,
//                 線材重量 = r.線材重量,
//                 用料 = r.用料,
//                 模具編號 = r.模具編號,
//                 管制卡號 = "沒有欄位"
//             }).SingleOrDefault();
//             return (model != null);
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 從ID判斷工令作業是否有值
//         /// </summary>
//         /// <param name="id">id.</param>
//         /// <param name="model">工令作業 資料表.</param>
//         /// <returns>
//         /// boolean.
//         /// </returns>
//         ///
//         public bool TryGetDataById(long id, out 工令作業 model)
//         {
//             model = _context.工令作業.Find(id);
//             return (model != null);
//         }
//         #endregion
//     }
// }
