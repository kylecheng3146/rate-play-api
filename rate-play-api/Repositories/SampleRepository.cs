using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ofco_projects_api.Interfaces;
using ofco_projects_api.Services.OfcoContext;
using ofco_projects_api.Utilities;

namespace ofco_projects_api.Repositories {
    public class SampleRepository : ISampleRepository<Users> {
        private readonly OfcoContext _context;
        public SampleRepository(OfcoContext context) {
            _context = context;
        }

        #region
        /// <summary>
        /// 新增一筆資料.
        /// </summary>
        /// <param name="model">User資料表.</param>
        /// <returns>
        /// rowsAffected.
        /// </returns>
        ///
        public async Task<int> AddDataAsync(Users model) {
            int rowsAffected = 0;
            _context.Users.Add(model);
            rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
        #endregion

        #region
        /// <summary>
        /// 刪除特定一筆資料.
        /// </summary>
        /// <param name="users">User資料表.</param>
        /// <returns>
        /// rowsAffected.
        /// </returns>
        ///
        public async Task<int> DeleteDataAsync(Users users) {
            int rowsAffected = 0;
            _context.Users.Remove(users);
            rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
        #endregion

        #region
        /// <summary>
        /// 搜尋全部Users資料
        /// </summary>
        /// <returns>
        /// data list.
        /// </returns>
        ///
        public IEnumerable<Users> GetAllData() {
            return _context.Users.ToList().OrderByDescending(x => x.UpdTime);
        }
        #endregion

        #region
        /// <summary>
        /// 更新一筆資料
        /// </summary>
        /// <returns>The data async.</returns>
        /// <param name="oldData">Old data.</param>
        /// <param name="newData">New data.</param>
        public async Task<int> UpdateDataAsync(Users oldData, Users newData) {
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
        /// 搜尋最後Users資料
        /// </summary>
        /// <returns>
        /// data list.
        /// </returns>
        ///
        public Users GetLastData() {
            string maxId = _context.Users.Max(x => x.UserId);
            var q = _context.Users.Where(x => x.UserId == maxId).First();
            return q;
        }
        #endregion

        #region
        /// <summary>
        /// 搜尋七天Users資料
        /// </summary>
        /// <returns>
        /// data list.
        /// </returns>
        ///
        public object GetSevenDaysData() {
            var dateCriteria = DateTime.Now.Date.AddDays(-6); //建立日期範圍，今天～今天-6天
            var group = new object();
            // var group = (from a in _context.Users where a.UpdTime >= dateCriteria && a.UpdTime < DateTime.Now.Date.AddDays(+1) select a)
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
        /// 從ID判斷Users是否有值
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="model">Users 資料表.</param>
        /// <returns>
        /// boolean.
        /// </returns>
        ///
        public bool TryGetDataById(long id, out Users model) {
            model = _context.Users.Find(id);
            return (model != null);
        }
        #endregion

    }
}