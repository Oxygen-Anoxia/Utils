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
            //��ȡ��ȫ��Կ
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
            //tokenҪ��֤�Ĳ�������
            var tokenValidationParameters = new TokenValidationParameters
            {
                //������֤��ȫ��Կ
                ValidateIssuerSigningKey = true,
                //��ֵ��ȫ��Կ
                IssuerSigningKey = signingKey,
                //������֤ǩ����
                ValidateIssuer = true,
                //��ֵǩ����
                ValidIssuer = audienceConfig["Issuer"],
                //������֤����
                ValidateAudience = true,
                //��ֵ����
                ValidAudience = audienceConfig["Audience"],
                //�Ƿ���֤Token��Ч�ڣ�ʹ�õ�ǰʱ����Token��Claims�е�NotBefore��Expires�Ա�
                ValidateLifetime = true,
                //����ķ�����ʱ��ƫ����
                ClockSkew = TimeSpan.Zero,
                //�Ƿ�Ҫ��Token��Claims�б������Expires
                RequireExpirationTime = true,
            };
            services.AddControllers();
            //��ӷ�����֤������ΪTestKey
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = "TestKey";
            })
                .AddJwtBearer("TestKey", x =>
                {
                    x.RequireHttpsMetadata = false;
                    //��JwtBearerOptions�����У�IssuerSigningKey(ǩ����Կ)��ValidIssuer(Token�䷢����)��ValidAudience(�䷢��˭)���������Ǳ���ġ�
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
            //���ÿ���������������Դ
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
                // ȫ���쳣���� ����־���
                ac.Filters.Add(typeof(GlobalExceptionsFilter));
                //ac.Filters.Add(typeof(ValidationFilter));
                //ac.Filters.Add(typeof(AuthorizationFilter));
            })
            //ȫ������Json���л����� Nuget���� NewtonsoftJson  �� Microsoft.AspNetCore.Mvc.NewtonsoftJson
            .AddNewtonsoftJson(options =>
            {

                //����ѭ������
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //��ʹ���շ���ʽ��key
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //����ʱ���ʽ
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });

            //���������ļ���ȡ�൥��
            services.AddSingleton(new Appsettings(Configuration));

            //services.AddSingleton<IHostedService, AccountDockService>();

            ApiName = Appsettings.app(new string[] { "ApiName" });
            //var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    // {ApiName} �����ȫ�ֱ����������޸�
                    Version = "V1",
                    Title = $"{ApiName} �ӿ��ĵ�",
                    //Description = $"{ApiName} HTTP API V1",
                    //Contact = new OpenApiContact { Name = ApiName, Email = "hhchen@in-road.com", Url = new Uri("https://platform.in-road.com") },
                    //License = new OpenApiLicense { Name = ApiName, Url = new Uri("https://platform.in-road.com") }
                });
                c.OrderActionsBy(o => o.RelativePath);

                if (Appsettings.app("TokenAuth").ToLower() == "true")
                {
                    c.OperationFilter<AddHeaderOperationFilter>("token", "Ӧ�ó���Խ�token", false);
                    c.OperationFilter<AddHeaderOperationFilter>("timestamp", "ʱ���", false);
                    c.OperationFilter<AddHeaderOperationFilter>("sign", "����ǩ��", false);
                }

                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "WebApplication2.xml");//������Ǹո����õ�xml�ļ���
                c.IncludeXmlComments(xmlPath, true);//Ĭ�ϵĵڶ���������false�������controller��ע�ͣ��ǵ��޸�


                var xmlModelPath = Path.Combine(basePath, "WebApplication2.xml");//�������Model���xml�ļ���
                c.IncludeXmlComments(xmlModelPath);
            });
            //ע�����ݿ�����
            BaseDBConfig.ConnectionString = Configuration.GetSection("ConnectionStrings:Default").Value;

            //��ʱ����
            services.AddJobSetup();
            //  services.AddHostedService<RiskAndHiddenDangerService>();

            //ע��httpcontext
            services.AddHttpContextAccessor();

            //ע�ὡ��������
            services.AddHealthChecks();

            #region request����У���Զ��巵��ֵ
            services.Configure<ApiBehaviorOptions>((opt) =>
            {
                opt.InvalidModelStateResponseFactory = actionContext =>
                {
                    //��ȡ��֤ʧ�ܵ�ģ���ֶ� 
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .Select(e => e.Value.Errors.First().ErrorMessage)
                        .ToList();
                    //���÷�������
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
        /// autofac  ֱ���ó������룬ʵ�ֽ���
        /// ������Ŀ��InroadLinkBasf.Core������������Service�㣬ֻ��IService
        /// ��Service�����������Repository�㣬ֻ��IRepository
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {

            var basePath = AppContext.BaseDirectory;//��ȡ��Ŀ·��

            var servicesDllFile = Path.Combine(basePath, "Service.dll");//��ȡע����Ŀ����·��
            var repositoryDllFile = Path.Combine(basePath, "Repository.dll");

            //if (!(File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
            if (!(File.Exists(servicesDllFile)))
            {
                var msg = "Repository.dll��service.dll ��ʧ����Ϊ��Ŀ�����ˣ�������Ҫ��F6���룬��F5���У����� bin �ļ��У���������";
                throw new Exception(msg);
            }

            var assemblysServices = Assembly.LoadFile(servicesDllFile);//ֱ�Ӳ��ü����ļ��ķ���


            builder.RegisterAssemblyTypes(assemblysServices)
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope()
                      .EnableInterfaceInterceptors();


            //// ��ȡ Repository.dll ���򼯷��񣬲�ע��
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
            //wwwroot��ʹ��Ĭ����ʼ�ļ� ��index.html
            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", $"{ApiName} V1");

                //·�����ã�����Ϊ�գ���ʾֱ���ڸ�������localhost:8001�����ʸ��ļ�,ע��localhost:8001/swagger�Ƿ��ʲ����ģ�ȥlaunchSettings.json��launchUrlȥ����������뻻һ��·����ֱ��д���ּ��ɣ�����ֱ��дc.RoutePrefix = "doc";
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

