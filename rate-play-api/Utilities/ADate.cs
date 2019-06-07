using System;
namespace rate_play_api.Utilities
{
    public class ADate
    {
        public ADate()
        {
        }

        #region
        /// <summary>
        /// 取得當前時間.
        /// </summary>
        /// <param name="time_format">"yyyy/MM/dd HH:mm:ss" 取得沒有毫秒的時間格式.</param>
        /// yyyy-MM-dd HH:mm:ss.fff" 取得有毫秒的時間格式, 注意斜線或是橫槓.
        /// yyyy/MM/dd HH:mm:ss.fff" 取得有毫秒的時間格式.
        /// <returns>
        /// string for current time
        /// </returns>
        /// 
        public static string fetchCurrentTime(string time_format)
        {
            return DateTime.Now.ToString(time_format);
        }
        #endregion

        #region
        /// <summary>
        /// 取得統一的當前時間，寫入資料庫使用。
        /// </summary>
        /// <returns>
        /// string.
        /// </returns>
        /// 
        public static string fetchCurrentTimeString()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
        #endregion

        #region
        /// <summary>
        /// 取得統一的當前時間，寫入資料庫使用。
        /// </summary>
        /// <returns>
        /// DateTime.
        /// </returns>
        /// 
        public static DateTime fetchCurrentTime()
        {
            return convertStringToDateTime(fetchCurrentTimeString(), "yyyy-MM-dd HH:mm:ss.fff");
        }
        #endregion

        #region
        /// <summary>
        /// 取得統一的當前時間到日期。
        /// </summary>
        /// <returns>
        /// string.
        /// </returns>
        /// 
        public static string fetchCurrentTimeyyyyMMddString()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }
        #endregion

        #region
        /// <summary>
        /// 將字串時間轉化為 DateTime 格式
        /// </summary>
        /// <param name="date_time">字串的時間格式.</param>
        /// <param name="time_format">"yyyy/MM/dd HH:mm:ss.fff" 取得有毫秒的時間格式.</param>
        /// <returns>
        /// DateTime格式的時間.
        /// </returns>
        ///
        public static DateTime convertStringToDateTime(string date_time, string time_format)
        {
            return DateTime.ParseExact(date_time, time_format, null);
        }
        #endregion

        #region
        /// <summary>
        /// 將字串時間轉化為 DateTime 格式
        /// </summary>
        /// <param name="date_time">字串的時間格式.</param>
        /// <returns>
        /// DateTime格式的時間.
        /// </returns>
        ///
        public static DateTime convertStringToDateTime(string date_time)
        {
            return DateTime.ParseExact(date_time, "yyyy-MM-dd HH:mm:ss.fff", null);
        }
        #endregion

        #region
        /// <summary>
        /// 將字串時間轉化為 DateTime 格式 yyyyMMdd
        /// </summary>
        /// <param name="date_time">字串的時間格式.</param>
        /// <returns>
        /// DateTime格式的時間.
        /// </returns>
        ///
        public static DateTime convertStringToDateTimeyyyyMMdd(string date_time)
        {
            return DateTime.ParseExact(date_time, "yyyyMMdd", null);
        }
        #endregion

        #region
        /// <summary>
        /// 將DateTime轉化為字串格式 yyyy-MM-dd hh:mm:ss
        /// </summary>
        /// <param name="date_time">DateTime的時間格式.</param>
        /// <returns>
        /// string格式的時間.
        /// </returns>
        ///
        public static string convertDateTimeToString(DateTime date_time)
        {
            return date_time.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion
    }
}
