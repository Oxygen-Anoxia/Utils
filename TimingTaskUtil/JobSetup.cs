using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace TimingTaskUtil
{
    /// <summary>
    /// 任务调度 启动服务
    /// </summary>
    public static class JobSetup
    {


        /// <summary>
        /// Create：Joyce.ren 2021-10-26 
        /// </summary>
        /// <param name="services"></param>
        public static void AddJobSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            
            var _Bulider = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var _ConfigRoot = _Bulider.Build();

            string IsOpenTimeJobSub_standard = _ConfigRoot.GetSection("Ldap").GetSection("IsOpenTimeJobSub").Value;

            if (!string.IsNullOrEmpty(IsOpenTimeJobSub_standard) && IsOpenTimeJobSub_standard == "1")
            {
                services.AddHostedService<JobAutomaticSyncADData>();//Joyce.ren 2021-10-26 Add 
            }
        }
    }
}
