using Microsoft.AspNetCore.Mvc;
using Service.Dpc.ChuZhou;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPEIWebApplication.Controllers.Dpc.ChuZhou
{
    [Route("dpc/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DpcCzCommonServiceController : ControllerBase
    {

        IDpcCzCommonService _service;

        public DpcCzCommonServiceController(IDpcCzCommonService service)
        {
            _service = service;
        }


        /// <summary>
        /// 修改风险分析单元重大危险源标识
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> InitRikUnitisHazardValue()
        {
            return await _service.InitRikUnitisHazardValue();
        }


        /// <summary>
        /// 清空上传双预控数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> InitDpcData()
        {
            return await _service.InitDpcData();
        }


        /// <summary>
        /// 4.2 定时同步修改隐患排查任务数据
        /// Author：Joyce.ren 2022-02-23
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> SyncUpdateCheckTaskData()
        {
            return await _service.SyncUpdateCheckTaskData();
        }

        /// <summary>
        /// 6.2 定时同步删除隐患排查信息数据
        /// Author：Joyce.ren 2022-02-23
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> SyncDelCheckData(string res)
        {
            string ss = "";
            ss = await _service.SyncDelCheckData(ss);
            return ss;
        }

    }
}
