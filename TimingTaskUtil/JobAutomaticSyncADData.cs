using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimingTaskUtil
{
    public class JobAutomaticSyncADData : IHostedService, IDisposable
    {
        private Timer _timer;

        /// <summary>
        /// 构造函数-依赖注入
        /// </summary>
        public JobAutomaticSyncADData()
        {
          
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            Console.WriteLine("Job AutomaticSyncADData is starting.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var _Bulider = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var _ConfigRoot = _Bulider.Build();
            string IsOpenTimeJobSub_standard = _ConfigRoot.GetSection("Ldap").GetSection("IsOpenTimeJobSub").Value;

            try
            {
                int hour = int.Parse(_ConfigRoot.GetSection("Ldap").GetSection("hour").Value);//读取同步频率
                int minute = int.Parse(_ConfigRoot.GetSection("Ldap").GetSection("minute").Value);//读取同步频率
                int second = int.Parse(_ConfigRoot.GetSection("Ldap").GetSection("second").Value);//读取同步频率
                if (DateTime.Now.Hour == hour && DateTime.Now.Minute == minute && DateTime.Now.Second == second)
                {
                    string res = "";
                    //调用服务
                }
            }
            catch (Exception)
            {

            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Job AutomaticSyncADData is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
