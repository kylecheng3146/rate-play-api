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
//     public class WorkRepository : IBaseRepository<MachineWorkOrder>
//     {
//         private readonly OfcoContext _context;
//         public WorkRepository(OfcoContext context)
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
//         public async Task<int> AddDataAsync(MachineWorkOrder model)
//         {
//             int rowsAffected = 0;
//             _context.MachineWorkOrder.Add(model);
//             rowsAffected = await _context.SaveChangesAsync();
//             return rowsAffected;
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 刪除特定一筆資料.
//         /// </summary>
//         /// <param name="MachineWorkOrder">User資料表.</param>
//         /// <returns>
//         /// rowsAffected.
//         /// </returns>
//         ///
//         public async Task<int> DeleteDataAsync(MachineWorkOrder MachineWorkOrder)
//         {
//             int rowsAffected = 0;
//             _context.MachineWorkOrder.Remove(MachineWorkOrder);
//             rowsAffected = await _context.SaveChangesAsync();
//             return rowsAffected;
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 搜尋全部MachineWorkOrder資料
//         /// </summary>
//         /// <returns>
//         /// data list.
//         /// </returns>
//         ///
//         public IEnumerable<MachineWorkOrder> GetAllData()
//         {
//             return _context.MachineWorkOrder.ToList().OrderByDescending(x => x.SetTime);
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 更新一筆資料
//         /// </summary>
//         /// <returns>The data async.</returns>
//         /// <param name="oldData">Old data.</param>
//         /// <param name="newData">New data.</param>
//         public async Task<int> UpdateDataAsync(MachineWorkOrder oldData, MachineWorkOrder newData)
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
//         /// 搜尋最後MachineWorkOrder資料
//         /// </summary>
//         /// <returns>
//         /// data list.
//         /// </returns>
//         ///
//         public MachineWorkOrder GetLastData()
//         {
//             long maxId = _context.MachineWorkOrder.Max(x => x.No);
//             var q = _context.MachineWorkOrder.Where(x => x.No == maxId).First();
//             return q;
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 搜尋七天MachineWorkOrder資料
//         /// </summary>
//         /// <returns>
//         /// data list.
//         /// </returns>
//         ///
//         public object GetSevenDaysData()
//         {
//             var dateCriteria = DateTime.Now.Date.AddDays(-6); //建立日期範圍，今天～今天-6天
//             var group = new object();
//             // var group = (from a in _context.MachineWorkOrder where a.UpdTime >= dateCriteria && a.UpdTime < DateTime.Now.Date.AddDays(+1) select a)
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
//         /// 從ID判斷MachineWorkOrder是否有值
//         /// </summary>
//         /// <param name="id">id.</param>
//         /// <param name="model">MachineWorkOrder 資料表.</param>
//         /// <returns>
//         /// boolean.
//         /// </returns>
//         ///
//         public bool TryGetByMachineWorkCode(string work_code, out MachineWorkOrder model)
//         {
//             model = _context.MachineWorkOrder.SingleOrDefault(x => work_code.Equals(x.WorkOrder));
//             return (model != null);
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 從ID判斷MachineWorkOrder是否有值
//         /// </summary>
//         /// <param name="id">id.</param>
//         /// <param name="model">MachineWorkOrder 資料表.</param>
//         /// <returns>
//         /// boolean.
//         /// </returns>
//         ///
//         public bool TryGetDataById(long id, out MachineWorkOrder model)
//         {
//             model = _context.MachineWorkOrder.Find(id);
//             return (model != null);
//         }
//         #endregion
//     }
// }
