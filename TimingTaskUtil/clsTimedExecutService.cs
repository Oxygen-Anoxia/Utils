using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimingTaskUtil
{

    /// <summary>
    ///  定时程序执行的类
    ///  Add Joyce.ren 2021-12-08
    /// </summary>
    public class clsTimedExecutService : BackgroundService
    {
        //public ILogger<clsTimedExecutService> _logger;
        private readonly ILogger _logger;

        public clsTimedExecutService(ILogger<clsTimedExecutService> logger)
        {
            this._logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation(DateTime.Now.ToString() + "启动定时任务！");

                //bool flag = true;
                while (!stoppingToken.IsCancellationRequested)
                {

                    await Task.Delay(1000, stoppingToken); //启动后多久执行一次

                    var _Bulider = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                    var _ConfigRoot = _Bulider.Build();
                    //var _Value = _ConfigRoot.GetSection("Logging").GetSection("LogLevel").GetSection("Default");
                    string IsOpenTimeJob = _ConfigRoot.GetSection("IsOpenTimeJob").Value;

                    if (IsOpenTimeJob == "1")
                    {
                        int hour = int.Parse(_ConfigRoot.GetSection("SyncFrnquencyHour").Value);//读取同步频率 小时
                        int minute = int.Parse(_ConfigRoot.GetSection("SyncFrnquencyMinute").Value);//读取同步频率 分钟
                        int second = int.Parse(_ConfigRoot.GetSection("SyncFrnquencySecond").Value);//读取同步频率 秒钟

                        if (DateTime.Now.Hour == hour&& DateTime.Now.Minute == minute && DateTime.Now.Second == second)
                        {
                            //需要执行的业务代码
                           
                            LogHelper.LogHelper.WriteLog("***********************************************************");
                            LogHelper.LogHelper.WriteLog("开始执行" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            LogHelper.LogHelper.WriteLog("结束执行" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            LogHelper.LogHelper.WriteLog("***********************************************************");
                        }
                    }
                }
                _logger.LogInformation(DateTime.Now.ToString() + "自动任务停止！");
            }
            catch (Exception ex)
            {
                if (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation(DateTime.Now.ToString() + "自动任务异常！" + ex.Message + ex.StackTrace);
                }
                else
                {
                    _logger.LogInformation(DateTime.Now.ToString() + "自动任务异常停止！");
                }
            }
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
