using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using NLog;
using rate_play_api.DataModel;

namespace SmartEquipment.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        //log u r error here.
                        var error = contextFeature.Error.ToString();
                        int sl = error.Length;
                        string logS = "";
                        //資料表欄位開的大小為512，所以要判斷一下字數有沒有超過.超過的話取500個字就好，保險起見。
                        if (sl >= 512) logS = error.Substring(0, 500);
                        else logS = error;
                        //使用NLog紀錄到資料庫去。
                        logger.Error(logS);

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            //Message = $"Internal Server Error. {contextFeature.Error}"
                            Message = logS
                        }.ToString());
                    }
                });
            });
        }
    }
}
