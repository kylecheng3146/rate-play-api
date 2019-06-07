using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rate_play_api.Interfaces
{
    /// <summary>
    /// Base repository, 基本的資料庫操作方法CRUD。
    /// </summary>
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAllData();
        Task<int> AddDataAsync(T model);
        Task<int> UpdateDataAsync(T oldData, T newData);
        Task<int> DeleteDataAsync(T waterMeter);
        bool TryGetDataById(int id, out T model);
    }
}
