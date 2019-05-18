using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ofco_projects_api.Services.OfcoContext;

namespace ofco_projects_api.Interfaces
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
