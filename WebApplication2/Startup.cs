using Common.Helper;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimingTaskUtil;
using Inroad.Foundation.Ocelot.JWTAuthorizePolicy;
using Microsoft.Extensions.Logging;
using Common.AutoMapper;
using WebApplication2.Filter;
using Microsoft.AspNetCore.Mvc;
using Common.DB;
using Model;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Autofac;
using Autofac.Extras.DynamicProxy;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using WebApplication2.Middlewares;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApplication2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public string ApiName { get; set; } = "WebApplication2";



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var audienceConfig = Configuration.GetSection("Audience");
            //获取安全秘钥
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
            //token要验证的参数集合
            var tokenValidationParameters = new TokenValidationParameters
            {
                //必须验证安全秘钥
                ValidateIssuerSigningKey = true,
                //赋值安全秘钥
                IssuerSigningKey = signingKey,
                //必须验证签发人
                ValidateIssuer = true,
                //赋值签发人
                ValidIssuer = audienceConfig["Issuer"],
                //必须验证受众
                ValidateAudience = true,
                //赋值受众
                ValidAudience = audienceConfig["Audience"],
                //是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                ValidateLifetime = true,
                //允许的服务器时间偏移量
                ClockSkew = TimeSpan.Zero,
                //是否要求Token的Claims中必须包含Expires
                RequireExpirationTime = true,
            };
            services.AddControllers();
            //添加服务验证，方案为TestKey
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = "TestKey";
            })
                .AddJwtBearer("TestKey", x =>
                {
                    x.RequireHttpsMetadata = false;
                    //在JwtBearerOptions配置中，IssuerSigningKey(签名秘钥)、ValidIssuer(Token颁发机构)、ValidAudience(颁发给谁)三个参数是必须的。
                    x.TokenValidationParameters = tokenValidationParameters;
                });
            //services.AddOcelotPolicyJwtBearer(audienceConfig["Issuer"], audienceConfig["Issuer"], audienceConfig["Secret"], "GSWBearer", "Permission", "/demoapi/denied");

            var permission = new List<Permission>
            {
                new Permission{ Url = "/demoapi/values",Name = "system"},
                new Permission{ Url = "/",Name = "system"}
            };
            services.AddSingleton(permission);
            services.AddLogging(x =>
            {
                x.AddConfiguration(Configuration.GetSection("Logging"));
                x.AddConsole();
                x.AddDebug();
            });

            services.AddAutoMapperSetup();
            //services.AddSingleton<ILoggerHelper, LogHelper>();
            //配置跨域处理，允许所有来源
            services.AddCors(options =>
            {
                options.AddPolicy("cors",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                );
            });
            services.AddControllers(ac =>
            {
                // 全局异常过滤 （日志搭建）
                ac.Filters.Add(typeof(GlobalExceptionsFilter));
                //ac.Filters.Add(typeof(ValidationFilter));
                //ac.Filters.Add(typeof(AuthorizationFilter));
            })
            //全局配置Json序列化处理 Nuget引用 NewtonsoftJson  和 Microsoft.AspNetCore.Mvc.NewtonsoftJson
            .AddNewtonsoftJson(options =>
            {

                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //不使用驼峰样式的key
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });

            //设置配置文件读取类单例
            services.AddSingleton(new Appsettings(Configuration));

            //services.AddSingleton<IHostedService, AccountDockService>();

            ApiName = Appsettings.app(new string[] { "ApiName" });
            //var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    // {ApiName} 定义成全局变量，方便修改
                    Version = "V1",
                    Title = $"{ApiName} 接口文档",
                    //Description = $"{ApiName} HTTP API V1",
                    //Contact = new OpenApiContact { Name = ApiName, Email = "hhchen@in-road.com", Url = new Uri("https://platform.in-road.com") },
                    //License = new OpenApiLicense { Name = ApiName, Url = new Uri("https://platform.in-road.com") }
                });
                c.OrderActionsBy(o => o.RelativePath);

                if (Appsettings.app("TokenAuth").ToLower() == "true")
                {
                    c.OperationFilter<AddHeaderOperationFilter>("token", "应用程序对接token", false);
                    c.OperationFilter<AddHeaderOperationFilter>("timestamp", "时间戳", false);
                    c.OperationFilter<AddHeaderOperationFilter>("sign", "加密签名", false);
                }

                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "WebApplication2.xml");//这个就是刚刚配置的xml文件名
                c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改


                var xmlModelPath = Path.Combine(basePath, "WebApplication2.xml");//这个就是Model层的xml文件名
                c.IncludeXmlComments(xmlModelPath);
            });
            //注册数据库连接
            BaseDBConfig.ConnectionString = Configuration.GetSection("ConnectionStrings:Default").Value;

            //定时任务
            services.AddJobSetup();
            //  services.AddHostedService<RiskAndHiddenDangerService>();

            //注册httpcontext
            services.AddHttpContextAccessor();

            //注册健康检查服务
            services.AddHealthChecks();

            #region request参数校验自定义返回值
            services.Configure<ApiBehaviorOptions>((opt) =>
            {
                opt.InvalidModelStateResponseFactory = actionContext =>
                {
                    //获取验证失败的模型字段 
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .Select(e => e.Value.Errors.First().ErrorMessage)
                        .ToList();
                    //设置返回内容
                    var result = new ApiMessage
                    {
                        status = 0,
                        error = new ApiMessageError { code = 519, message = string.Join(',', errors.Distinct()) }
                    };

                    return new BadRequestObjectResult(result);
                };
            });
            #endregion

            services.Configure<KestrelServerOptions>(x => x.AllowSynchronousIO = true)
                .Configure<IISServerOptions>(x => x.AllowSynchronousIO = true);
        }
        /// <summary>
        /// autofac  直接用程序集引入，实现解耦
        /// 在主项目（InroadLinkBasf.Core）中无需引用Service层，只需IService
        /// 在Service层里，无需引入Repository层，只需IRepository
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {

            var basePath = AppContext.BaseDirectory;//获取项目路径

            var servicesDllFile = Path.Combine(basePath, "Service.dll");//获取注入项目绝对路径
            var repositoryDllFile = Path.Combine(basePath, "Repository.dll");

            //if (!(File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
            if (!(File.Exists(servicesDllFile)))
            {
                var msg = "Repository.dll和service.dll 丢失，因为项目解耦了，所以需要先F6编译，再F5运行，请检查 bin 文件夹，并拷贝。";
                throw new Exception(msg);
            }

            var assemblysServices = Assembly.LoadFile(servicesDllFile);//直接采用加载文件的方法


            builder.RegisterAssemblyTypes(assemblysServices)
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope()
                      .EnableInterfaceInterceptors();


            //// 获取 Repository.dll 程序集服务，并注册
            //var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            //builder.RegisterAssemblyTypes(assemblysRepository)
            //       .AsImplementedInterfaces()
            //       .InstancePerDependency();

            //builder.RegisterGeneric(typeof(Repository.Base.BaseRepository<>))
            //    .As(typeof(IRepository.Base.IBaseRepository<>))
            //    .InstancePerDependency();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHealthChecks("/health");

            app.Use(next => httpContext =>
            {
                httpContext.Request.EnableBuffering();
                return next(httpContext);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //wwwroot下使用默认起始文件 如index.html
            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", $"{ApiName} V1");

                //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉，如果你想换一个路径，直接写名字即可，比如直接写c.RoutePrefix = "doc";
                //c.RoutePrefix = "doc";
            });
            app.UseRouting();
            app.UseCors("cors");
            app.UseAuthorization();

            app.UseMiddleware<RequestResponseLoggingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

