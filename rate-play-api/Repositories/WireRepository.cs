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
//     public class WireRepository : IBaseRepository<線材櫃>
//     {
//         private readonly OfcoContext _context;
//         public WireRepository(OfcoContext context)
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
//         public async Task<int> AddDataAsync(線材櫃 model)
//         {
//             int rowsAffected = 0;
//             _context.線材櫃.Add(model);
//             rowsAffected = await _context.SaveChangesAsync();
//             return rowsAffected;
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 刪除特定一筆資料.
//         /// </summary>
//         /// <param name="線材櫃">User資料表.</param>
//         /// <returns>
//         /// rowsAffected.
//         /// </returns>
//         ///
//         public async Task<int> DeleteDataAsync(線材櫃 線材櫃)
//         {
//             int rowsAffected = 0;
//             _context.線材櫃.Remove(線材櫃);
//             rowsAffected = await _context.SaveChangesAsync();
//             return rowsAffected;
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 搜尋全部線材櫃資料
//         /// </summary>
//         /// <returns>
//         /// data list.
//         /// </returns>
//         ///
//         public IEnumerable<線材櫃> GetAllData()
//         {
//             return _context.線材櫃.ToList().OrderByDescending(x => x.建檔日期);
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 更新一筆資料
//         /// </summary>
//         /// <returns>The data async.</returns>
//         /// <param name="oldData">Old data.</param>
//         /// <param name="newData">New data.</param>
//         public async Task<int> UpdateDataAsync(線材櫃 oldData, 線材櫃 newData)
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
//         /// 搜尋最後線材櫃資料
//         /// </summary>
//         /// <returns>
//         /// data list.
//         /// </returns>
//         ///
//         public 線材櫃 GetLastData()
//         {
//             // long maxId = _context.線材櫃.Max(x => x.No);
//             // var q = _context.線材櫃.Where(x => x.No == maxId).First();
//             var q = new 線材櫃();
//             return q;
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 搜尋七天線材櫃資料
//         /// </summary>
//         /// <returns>
//         /// data list.
//         /// </returns>
//         ///
//         public object GetSevenDaysData()
//         {
//             var dateCriteria = DateTime.Now.Date.AddDays(-6); //建立日期範圍，今天～今天-6天
//             var group = new object();
//             // var group = (from a in _context.線材櫃 where a.UpdTime >= dateCriteria && a.UpdTime < DateTime.Now.Date.AddDays(+1) select a)
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
//         /// 從固定倉庫存卡的爐號查出品號後判斷線材櫃是否有值
//         /// </summary>
//         /// <param name="stove_code">爐號.</param>
//         /// <param name="model">線材櫃 資料表.</param>
//         /// <returns>
//         /// boolean.
//         /// </returns>
//         ///
//         public bool TryGetByWire(string stove_code, out Object model)
//         {
//             model = _context.固定倉庫存卡.Where(
//                 guding => stove_code.Equals(guding.爐號) && guding.類別.Equals("線材")
//             ).Join(
//                 _context.線材櫃,
//                 guding => guding.品號,
//                 xiancai => xiancai.品號,
//                 (guding,xiancai) => new {
//                     品號 = guding.品號,
//                     品名 = xiancai.品名,
//                 }
//             ).Distinct().SingleOrDefault();
//             return (model != null);
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 從ID判斷線材櫃是否有值
//         /// </summary>
//         /// <param name="id">id.</param>
//         /// <param name="model">線材櫃 資料表.</param>
//         /// <returns>
//         /// boolean.
//         /// </returns>
//         ///
//         public bool TryGetDataById(long id, out 線材櫃 model)
//         {
//             model = _context.線材櫃.Find(id);
//             return (model != null);
//         }
//         #endregion
//     }
// }
