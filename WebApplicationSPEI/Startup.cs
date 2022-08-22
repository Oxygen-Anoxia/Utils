//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace WebApplicationSPEI
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddControllers();
//        }
//        public string ApiName { get; set; } = "InroadLinkBasf.Core";



//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            app.UseHealthChecks("/health");

//            app.Use(next => httpContext =>
//            {
//                httpContext.Request.EnableBuffering();
//                return next(httpContext);
//            });


//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseDefaultFiles();

//            app.UseStaticFiles();

//            app.UseSwagger();
//            app.UseSwaggerUI(c =>
//            {
//                c.SwaggerEndpoint($"/swagger/V1/swagger.json", $"{ApiName} V1");

//                //·�����ã�����Ϊ�գ���ʾֱ���ڸ�������localhost:8001�����ʸ��ļ�,ע��localhost:8001/swagger�Ƿ��ʲ����ģ�ȥlaunchSettings.json��launchUrlȥ����������뻻һ��·����ֱ��д���ּ��ɣ�����ֱ��дc.RoutePrefix = "doc";
//                c.RoutePrefix = "doc";
//            });
//            app.UseRouting();
//            app.UseCors("cors");
//            app.UseAuthorization();

//            app.UseMiddleware<RequestResponseLoggingMiddleware>();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });

//        }
//    }
//}
