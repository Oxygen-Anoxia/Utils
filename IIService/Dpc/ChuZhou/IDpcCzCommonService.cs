using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Dpc.ChuZhou
{
    public interface IDpcCzCommonService
    {

        /// <summary>
        /// 修改风险分析单元重大危险源标识
        /// </summary>
        /// <returns></returns>
        Task<string> InitRikUnitisHazardValue();

        /// <summary>
        /// 清空上传双预控数据
        /// </summary>
        /// <returns></returns>
        Task<string> InitDpcData();

        /// <summary>
        /// 4.2 定时同步修改隐患排查任务数据
        /// Author：Joyce.ren 2022-02-23
        /// </summary>
        /// <returns></returns>
        Task<string> SyncUpdateCheckTaskData();

        /// <summary>
        /// 6.2 定时同步删除隐患排查信息数据
        /// Author：Joyce.ren 2022-02-23
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        Task<string> SyncDelCheckData(string res);

    }
}
