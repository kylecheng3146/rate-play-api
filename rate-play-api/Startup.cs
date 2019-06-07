using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using NLog.Web;
using rate_play_api.Helpers;
using rate_play_api.Interfaces;
using rate_play_api.Repositories;
using rate_play_api.Services.RatePlayContext;
using Swashbuckle.AspNetCore.Swagger;

namespace rate_play_api {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            // services.AddScoped<SampleRepository>();
            services.AddScoped<ActivityRepository>();
            services.AddScoped<LoginRepository>();
            services.AddScoped<RateRepository>();
            services.AddScoped<CountriesRepository>();
            // services.AddScoped<WorkRepository>();
            // services.AddScoped<WireRepository>();
            // services.AddScoped<SendJobRepository>();
            services.AddScoped<MachineRepository>();
            services.AddDbContext<RatePlayContext>(opt =>
                opt.UseMySql(Configuration.GetConnectionString("NCKU")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //修正返回時間格式含有T，配置序列化時時間格式為yyyy-MM-dd HH:mm:ss.fff.
            services.AddMvc().AddJsonOptions(option => {
                option.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss.fff";
            });
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1.0.0", new Info {
                    Version = "v1.0.0",
                        Title = "sapido smart equipment",
                        Description = "water meter",
                        TermsOfService = "sapido Inc.",
                        Contact = new Contact {
                            Name = "Ant Chen",
                                Email = "j8821185@sapido.com.tw",
                                Url = string.Empty
                        },
                        // License = new License {
                        //     Name = "Use under LICX",
                        //         Url = "https://example.com/license"
                        // }
                });
            });

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x => {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x => {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            // configure DI for application services
            services.AddScoped<ILoginRepository, LoginRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            //使用驗證權限的 Middleware, global cors policy

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1.0.0/swagger.json", "sapido smart equipment v1.0.0");
            });

            //使用NLog作为日志记录工具
            loggerFactory.AddNLog();
            //引入Nlog配置文件
            env.ConfigureNLog("Nlog.config");
            // app.ConfigureExceptionHandler ();
            app.UseHttpsRedirection();
            /*
                url跳轉的寫法, 要先加入NuGet "Microsoft.AspNetCore.Rewrite":
                AddRewrite("^$", "index", true)意思為：
                把http://ip:port跳轉到http://ip:port/index
                AddRewrite的第1個參數（"^$"）是匹配重寫前的URL的正則表達式，
                第2個參數（"index"）是重寫後的URL，
                第3個參數（true）表示匹配成功1條規則後是否放棄後續規則的匹配。
                
                需要注意的是 app.UseRewriter() 要放在 app.UseMvc()，
                app.UseMvcWithDefaultRoute()，app.UseRouter() 之前。
             */
            app.UseRewriter(new RewriteOptions().AddRewrite("^$", "index", true));
            app.UseMvc();
        }
    }
}