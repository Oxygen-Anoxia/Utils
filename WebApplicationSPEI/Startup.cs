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

//                //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉，如果你想换一个路径，直接写名字即可，比如直接写c.RoutePrefix = "doc";
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
