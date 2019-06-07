using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using rate_play_api.Services.OfcoContext;

namespace rate_play_api.Interfaces
{
    public interface ISampleRepository<T> : IBaseRepository<T>
    {
        /// <summary>
        /// 搜尋最後WaterMeter資料
        /// </summary>
        /// <returns>
        /// data list.
        /// </returns>
        T GetLastData();
        /// <summary>
        /// 搜尋七天WaterMeter資料
        /// </summary>
        /// <returns>
        /// data list.
        /// </returns>
        object GetSevenDaysData();
    }

}
