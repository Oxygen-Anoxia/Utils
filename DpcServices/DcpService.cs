using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DpcServices
{
    public partial class DcpService : ServiceBase
    {
        public DcpService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            Utils.LogHelper.WriteLog("服务启动", "服务启动"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        protected override void OnStop()
        {
            Utils.LogHelper.WriteLog("服务停止", "服务停止" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
