using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SPEIWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //���������
            ServicePointManager.DefaultConnectionLimit = 20;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        var _Bulider = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                        var _ConfigRoot = _Bulider.Build();
                        string APIURL = _ConfigRoot.GetSection("APIURL").Value;
                        webBuilder
                        //.UseUrls(APIURL)
                        .UseStartup<Startup>()
                        //����־���
                        .ConfigureLogging((hostingContext, builder) =>
                        {
                            //���˵�ϵͳĬ�ϵ�һЩ��־
                            builder.AddFilter("System", LogLevel.Error);
                            builder.AddFilter("Microsoft", LogLevel.Error);

                            //�������ļ�
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "Log4net.config");
                            //builder.AddLog4Net(path);

                            builder.AddEventLog();
                        });
                    });

    }
}
