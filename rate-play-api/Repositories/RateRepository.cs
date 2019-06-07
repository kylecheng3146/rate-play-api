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
    public class RateRepository : IBaseRepository<Exrate>
    {
        private readonly RatePlayContext _context;
        public RateRepository(RatePlayContext context)
        {
            _context = context;
        }

        #region
        /// <summary>
        /// 新增一筆資料.
        /// </summary>
        /// <param name="model">Rate資料表.</param>
        /// <returns>
        /// rowsAffected.
        /// </returns>
        ///
        public async Task<int> AddDataAsync(Exrate model)
        {
            int rowsAffected = 0;
            _context.Exrate.Add(model);
            rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
        #endregion

        #region
        /// <summary>
        /// 刪除特定一筆資料.
        /// </summary>
        /// <param name="Exrate">Exrate資料表.</param>
        /// <returns>
        /// rowsAffected.
        /// </returns>
        ///
        public async Task<int> DeleteDataAsync(Exrate Exrate)
        {
            int rowsAffected = 0;
            _context.Exrate.Remove(Exrate);
            rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
        #endregion

        #region
        /// <summary>
        /// 搜尋全部Exrate資料
        /// </summary>
        /// <returns>
        /// data list.
        /// </returns>
        ///
        public IEnumerable<Object> GetAllData()
        {
            return _context.Exrate.Select(r => new
            {
                exrate = r.Exrate1,
                utc = r.Utc
            }).ToList().OrderByDescending(r => r.utc);
        }
        #endregion

        #region
        /// <summary>
        /// 更新一筆資料
        /// </summary>
        /// <returns>The data async.</returns>
        /// <param name="oldData">Old data.</param>
        /// <param name="newData">New data.</param>
        public async Task<int> UpdateDataAsync(Exrate oldData, Exrate newData)
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
            // if (newData.FlowExrate > 0) {
            //     oldData.FlowExrate = newData.FlowExrate;
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
        /// 搜尋最後Exrate資料
        /// </summary>
        /// <returns>
        /// data list.
        /// </returns>
        ///
        public Exrate GetLastData()
        {
            // long maxId = _context.Exrate.Max(x => x.No);
            // var q = _context.Exrate.Where(x => x.No == maxId).First();
            var q = new Exrate();
            return q;
        }
        #endregion

        #region
        /// <summary>
        /// 搜尋七天Rate資料
        /// </summary>
        /// <returns>
        /// data list.
        /// </returns>
        ///
        public object GetSevenDaysData()
        {
            var dateCriteria = DateTime.Now.Date.AddDays(-6); //建立日期範圍，今天～今天-6天
            var group = new object();
            // var group = (from a in _context.Rate where a.UpdTime >= dateCriteria && a.UpdTime < DateTime.Now.Date.AddDays(+1) select a)
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
        /// 從匯率名稱判斷Exrate是否有值
        /// </summary>
        /// <param name="rate_name">ID.</param>
        /// <param name="model">Exrate 資料表.</param>
        /// <returns>
        /// boolean.
        /// </returns>
        ///
        public bool TryGetHistoryRate(string rate_name, out Object model)
        {
            model = _context.Exrate.Where(m => rate_name.Equals(m.RateName)).ToList().OrderByDescending(r => r.Utc);
            return (model != null);
        }
        #endregion

        #region
        /// <summary>
        /// 從匯率名稱判斷Exrate是否有值
        /// </summary>
        /// <param name="rate_name">ID.</param>
        /// <param name="model">Exrate 資料表.</param>
        /// <returns>
        /// boolean.
        /// </returns>
        ///
        public bool TryGetByExrate(string rate_name, out Object model)
        {
            model = _context.Exrate.Where(m => rate_name.Equals(m.RateName) && m.Utc.Contains("2019-06-07")).SingleOrDefault();

            return (model != null);
        }
        #endregion

        #region
        /// <summary>
        /// 從ID判斷Rate是否有值
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="model">Rate 資料表.</param>
        /// <returns>
        /// boolean.
        /// </returns>
        ///
        public bool TryGetDataById(int id, out Exrate model)
        {
            model = _context.Exrate.Find(id);
            return (model != null);
        }

        IEnumerable<Exrate> IBaseRepository<Exrate>.GetAllData()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
