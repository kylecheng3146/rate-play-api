using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using rate_play_api.Interfaces;
using rate_play_api.Services.OfcoContext;
using rate_play_api.Utilities;

namespace rate_play_api.Repositories
{
    public class MachineRepository : IBaseRepository<Machine>
    {
        private readonly OfcoContext _context;
        public MachineRepository(OfcoContext context)
        {
            _context = context;
        }

        #region
        /// <summary>
        /// 新增一筆資料.
        /// </summary>
        /// <param name="model">Machine資料表.</param>
        /// <returns>
        /// rowsAffected.
        /// </returns>
        ///
        public async Task<int> AddDataAsync(Machine model)
        {
            int rowsAffected = 0;
            _context.Machine.Add(model);
            rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
        #endregion

        #region
        /// <summary>
        /// 刪除特定一筆資料.
        /// </summary>
        /// <param name="Machine">Machine資料表.</param>
        /// <returns>
        /// rowsAffected.
        /// </returns>
        ///
        public async Task<int> DeleteDataAsync(Machine Machine)
        {
            int rowsAffected = 0;
            _context.Machine.Remove(Machine);
            rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
        #endregion

        #region
        /// <summary>
        /// 搜尋全部Machine資料
        /// </summary>
        /// <returns>
        /// data list.
        /// </returns>
        ///
        public IEnumerable<Machine> GetAllData()
        {
            return _context.Machine.ToList().OrderByDescending(x => x.SetTime);
        }
        #endregion

        #region
        /// <summary>
        /// 更新一筆資料
        /// </summary>
        /// <returns>The data async.</returns>
        /// <param name="oldData">Old data.</param>
        /// <param name="newData">New data.</param>
        public async Task<int> UpdateDataAsync(Machine oldData, Machine newData)
        {
            int rowsAffected = 0;
            // if (Util.checkString(newData.Time.ToString())) {
            //     oldData.Time = newData.Time;
            // }
            // if (Util.checkString(newData.Ip)) {
            //     oldData.Ip = newData.Ip;
            // }
            // if (newData.Flow > 0) {
            //     oldData.Flow = newData.Flow;
            // }
            // if (newData.FlowRate > 0) {
            //     oldData.FlowRate = newData.FlowRate;
            // }
            // if (newData.Percentage > 0) {
            //     oldData.Percentage = newData.Percentage;
            // }
            // if (newData.ConductivityRatio > 0) {
            //     oldData.ConductivityRatio = newData.ConductivityRatio;
            // }
            // if (newData.TotalFlow > 0) {
            //     oldData.TotalFlow = newData.TotalFlow;
            // }
            rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
        #endregion

        #region
        /// <summary>
        /// 搜尋最後Machine資料
        /// </summary>
        /// <returns>
        /// data list.
        /// </returns>
        ///
        public Machine GetLastData()
        {
            // long maxId = _context.Machine.Max(x => x.No);
            // var q = _context.Machine.Where(x => x.No == maxId).First();
            var q = new Machine();
            return q;
        }
        #endregion

        #region
        /// <summary>
        /// 搜尋七天Machine資料
        /// </summary>
        /// <returns>
        /// data list.
        /// </returns>
        ///
        public object GetSevenDaysData()
        {
            var dateCriteria = DateTime.Now.Date.AddDays(-6); //建立日期範圍，今天～今天-6天
            var group = new object();
            // var group = (from a in _context.Machine where a.UpdTime >= dateCriteria && a.UpdTime < DateTime.Now.Date.AddDays(+1) select a)
            //     .GroupBy(x => x.UpdTime.Date) //x.Time.Date意思為把date time日期後面都變為0, ex:2019-03-12 12:34:567 -> 2019-03-12 00:00:00.000
            //     .Select(g => new {
            //         Date = g.Key.ToString("yyyy-MM-dd"), //將date time格式化成"yyyy-MM-dd".
            //             Count = g.Count(),
            //             TotalFlow = g.Max(a => a.TotalFlow) //取得group後最大的總流量
            //     });
            return group;

        }
        #endregion

        #region
        /// <summary>
        /// 從機台號碼判斷Machine是否有值
        /// </summary>
        /// <param name="machine_code">機台號碼.</param>
        /// <param name="model">Machine 資料表.</param>
        /// <returns>
        /// boolean.
        /// </returns>
        ///
        public bool TryGetByMachineCode(string machine_code, out Object model)
        {
            model = _context.Machine.Where(m => machine_code.Equals(m.UniqueCode)).Select(m => new {
                機台號碼 = m.UniqueCode
            }).SingleOrDefault();

            return (model != null);
        }
        #endregion

        #region
        /// <summary>
        /// 從ID判斷Machine是否有值
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="model">Machine 資料表.</param>
        /// <returns>
        /// boolean.
        /// </returns>
        ///
        public bool TryGetDataById(int id, out Machine model)
        {
            model = _context.Machine.Find(id);
            return (model != null);
        }
        #endregion
    }
}
