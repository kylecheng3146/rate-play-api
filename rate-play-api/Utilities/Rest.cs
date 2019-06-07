using System;
using RestSharp;
using rate_play_api.Model;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace rate_play_api.Utilities
{
    /// <summary>
    /// HttpClient json param use RestSharp include get, post, delete, put method.
    /// </summary>
    public class Rest
    {
        #region httpGet
        /// <summary>
        /// Http Get function
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static APIResult httpGet(string url, Dictionary<string, string> header = null, int timeout = 15 * 1000)
        {
            APIResult apiResult = new APIResult();
            try
            {
                var client = new RestClient(url)
                {
                    Timeout = timeout
                };
                var request = new RestRequest(Method.GET);
                if (header != null)
                {
                    foreach (var h in header)
                    {
                        request.AddHeader(h.Key, h.Value);
                    }
                }
                IRestResponse response = client.Execute(request);
                apiResult.response = response.Content.ToString();
                apiResult.statusCode = Convert.ToInt32(response.StatusCode);

                apiResult.callStatus = true;
                apiResult.url = url;
                apiResult.errorMessage = "";
            }
            catch (Exception ex)
            {
                apiResult.callStatus = false;
                apiResult.url = url;
                apiResult.response = "";
                apiResult.errorMessage = ex.Message;
            }
            return apiResult;
        }
        #endregion

        #region httpPost
        /// <summary>
        /// http post function
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postdata"></param>
        /// <returns></returns>
        public static APIResult httpPost(string url, object postdata, Dictionary<string, string> header = null, int timeout = 15 * 1000)
        {
            APIResult apiResult = new APIResult();
            try
            {
                var client = new RestClient(url)
                {
                    Timeout = timeout
                };
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json");
                if (header != null)
                {
                    foreach (var h in header)
                    {
                        request.AddHeader(h.Key, h.Value);
                    }
                }
                if (postdata != null)
                {
                    //always post as json.
                    postdata = JsonConvert.SerializeObject(postdata);
                    request.AddParameter("application/json", postdata, ParameterType.RequestBody);
                }
                IRestResponse response = client.Execute(request);
                apiResult.response = response.Content;
                apiResult.statusCode = Convert.ToInt32(response.StatusCode);

                apiResult.callStatus = true;
                apiResult.url = url;
                apiResult.errorMessage = "";
            }
            catch (Exception ex)
            {
                apiResult.callStatus = false;
                apiResult.url = url;
                apiResult.response = "";
                apiResult.errorMessage = ex.Message;
            }
            return apiResult;
        }
        #endregion

        #region httpDelete
        /// <summary>
        /// http delete function
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postdata"></param>
        /// <returns></returns>
        public static APIResult httpDelete(string url, object postdata, Dictionary<string, string> header = null, int timeout = 15 * 1000)
        {
            APIResult apiResult = new APIResult();
            try
            {
                var client = new RestClient(url)
                {
                    Timeout = timeout
                };
                var request = new RestRequest(Method.DELETE);
                request.AddHeader("content-type", "application/json");
                if (header != null)
                {
                    foreach (var h in header)
                    {
                        request.AddHeader(h.Key, h.Value);
                    }
                }
                if (postdata != null)
                {
                    //always post as json.
                    postdata = JsonConvert.SerializeObject(postdata);
                    request.AddParameter("application/json", postdata, ParameterType.RequestBody);
                }
                IRestResponse response = client.Execute(request);
                apiResult.response = response.Content.ToString();
                apiResult.statusCode = Convert.ToInt32(response.StatusCode);

                apiResult.callStatus = true;
                apiResult.url = url;
                apiResult.errorMessage = "";
            }
            catch (Exception ex)
            {
                apiResult.callStatus = false;
                apiResult.url = url;
                apiResult.response = "";
                apiResult.errorMessage = ex.Message;
            }
            return apiResult;
        }
        #endregion

        #region httpPut
        /// <summary>
        /// http put function
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postdata"></param>
        /// <returns></returns>
        public static APIResult httpPut(string url, object postdata, Dictionary<string, string> header = null, int timeout = 15 * 1000)
        {
            APIResult apiResult = new APIResult();
            try
            {
                var client = new RestClient(url)
                {
                    Timeout = timeout
                };
                var request = new RestRequest(Method.PUT);
                request.AddHeader("content-type", "application/json");
                if (header != null)
                {
                    foreach (var h in header)
                    {
                        request.AddHeader(h.Key, h.Value);
                    }
                }
                if (postdata != null)
                {
                    //always post as json.
                    postdata = JsonConvert.SerializeObject(postdata);
                    request.AddParameter("application/json", postdata, ParameterType.RequestBody);
                }
                IRestResponse response = client.Execute(request);
                apiResult.response = response.Content.ToString();
                apiResult.statusCode = Convert.ToInt32(response.StatusCode);

                apiResult.callStatus = true;
                apiResult.url = url;
                apiResult.errorMessage = "";
            }
            catch (Exception ex)
            {
                apiResult.callStatus = false;
                apiResult.url = url;
                apiResult.response = "";
                apiResult.errorMessage = ex.Message;
            }
            return apiResult;
        }
        #endregion
    }
}
