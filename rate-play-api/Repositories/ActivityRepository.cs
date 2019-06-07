using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using rate_play_api.Interfaces;
using rate_play_api.Services;
using rate_play_api.Services.RatePlayContext;
using rate_play_api.Utilities;

namespace rate_play_api.Repositories
{
    public class ActivityRepository : IBaseRepository<Activity>
    {
        private readonly RatePlayContext _context;
        public ActivityRepository(RatePlayContext context)
        {
            _context = context;
        }

        #region
        /// <summary>
        /// 新增一筆資料.
        /// </summary>
        /// <param name="model">Activity資料表.</param>
        /// <returns>
        /// rowsAffected.
        /// </returns>
        ///
        public async Task<int> AddDataAsync(Activity model)
        {
            int rowsAffected = 0;
            _context.Activity.Add(model);
            rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
        #endregion

        #region
        /// <summary>
        /// 刪除特定一筆資料.
        /// </summary>
        /// <param name="Activity">Activity資料表.</param>
        /// <returns>
        /// rowsAffected.
        /// </returns>
        ///
        public async Task<int> DeleteDataAsync(Activity Activity)
        {
            int rowsAffected = 0;
            _context.Activity.Remove(Activity);
            rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
        #endregion

        #region
        /// <summary>
        /// 搜尋全部Activity資料
        /// </summary>
        /// <returns>
        /// data list.
        /// </returns>
        ///
        public IEnumerable<Activity> GetAllData()
        {
            return _context.Activity.ToList().OrderByDescending(x => x.ActSou);
        }
        #endregion

        #region
        /// <summary>
        /// 更新一筆資料
        /// </summary>
        /// <returns>The data async.</returns>
        /// <param name="oldData">Old data.</param>
        /// <param name="newData">New data.</param>
        public async Task<int> UpdateDataAsync(Activity oldData, Activity newData)
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
        /// 搜尋最後Activity資料
        /// </summary>
        /// <returns>
        /// data list.
        /// </returns>
        ///
        public Activity GetLastData()
        {
            // long maxId = _context.Activity.Max(x => x.No);
            // var q = _context.Activity.Where(x => x.No == maxId).First();
            var q = new Activity();
            return q;
        }
        #endregion

        #region
        /// <summary>
        /// 搜尋七天Activity資料
        /// </summary>
        /// <returns>
        /// data list.
        /// </returns>
        ///
        public object GetSevenDaysData()
        {
            var dateCriteria = DateTime.Now.Date.AddDays(-6); //建立日期範圍，今天～今天-6天
            var group = new object();
            // var group = (from a in _context.Activity where a.UpdTime >= dateCriteria && a.UpdTime < DateTime.Now.Date.AddDays(+1) select a)
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
        /// 從ID判斷Activity是否有值
        /// </summary>
        /// <param name="act_souper">ID.</param>
        /// <param name="model">Activity 資料表.</param>
        /// <returns>
        /// boolean.
        /// </returns>
        ///
        public bool TryGetByActivitySouper(string act_souper, out Object model)
        {
            model = _context.Activity.Where(m => act_souper.Equals(m.ActSouper)).ToList();

            return (model != null);
        }
        #endregion

        #region
        /// <summary>
        /// 從ID判斷Activity是否有值
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="model">Activity 資料表.</param>
        /// <returns>
        /// boolean.
        /// </returns>
        ///
        public bool TryGetDataById(int id, out Activity model)
        {
            model = _context.Activity.Find(id);
            return (model != null);
        }
        #endregion
    }
}
