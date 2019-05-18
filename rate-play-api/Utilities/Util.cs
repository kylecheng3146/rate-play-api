using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;

namespace ofco_projects_api.Utilities
{
    public class Util
    {
        public Util()
        {
        }
        private Dictionary<string, string> myDictionary = new Dictionary<string, string>();
        private static readonly HttpClient client = new HttpClient();

        #region
        /// <summary>
        /// http post
        /// </summary>
        /// <param name="params_value">參數.</param>
        /// <param name="url">url</param>
        /// <returns>
        /// object
        /// </returns>
        /// 
        public static async Task<object> postAsync(Dictionary<string, string> params_value, string url)
        {
            var content = new FormUrlEncodedContent(params_value);
            var response = await client.PostAsync(url, content);
            return await response.Content.ReadAsAsync<object>();
        }
        #endregion

        #region
        /// <summary>
        /// 檢查字串是否為null或"".
        /// </summary>
        /// <returns><c>true</c>, 字串有值, <c>false</c> 字串為空.</returns>
        /// <param name="value">Value.</param>
        public static Boolean checkString(string value)
        {
            return value != null && !"".Equals(value) && !"01/01/0001 00:00:00".Equals(value);
        }
        #endregion

        #region
        /// <summary>
        /// Deserialize Json string to class model.
        /// </summary>
        /// <returns>The class.</returns>
        /// <param name="json">Json string.</param>
        /// <typeparam name="T">The 1st type parameter. class model type</typeparam>
        public static T json2Class<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        #endregion

        #region
        /// <summary>
        /// Serialize Class to json string.
        /// </summary>
        /// <returns>The json string.</returns>
        /// <param name="obj">Any class model.</param>
        public static string class2JsonString(Object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        #endregion

        #region
        /// <summary>
        /// get local ip address.
        /// </summary>
        /// <returns>string.</returns>
        public static string getLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        #endregion

        #region
        public static T ModelFromActionResult<T>(ActionResult actionResult)
        {
            object model;
            if (actionResult.GetType() == typeof(ViewResult))
            {
                ViewResult viewResult = (ViewResult)actionResult;
                model = viewResult.Model;
            }
            else if (actionResult.GetType() == typeof(PartialViewResult))
            {
                PartialViewResult partialViewResult = (PartialViewResult)actionResult;
                model = partialViewResult.Model;
            }
            else
            {
                throw new InvalidOperationException(string.Format("Actionresult of type {0} is not supported by ModelFromResult extractor.", actionResult.GetType()));
            }
            T typedModel = (T)model;
            return typedModel;
        }
        #endregion

    }
}
