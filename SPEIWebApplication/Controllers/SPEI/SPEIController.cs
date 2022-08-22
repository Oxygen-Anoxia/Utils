using IService.SPEI;
using Microsoft.AspNetCore.Mvc;
using Model.SPEI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPEIWebApplication.Controllers.SPEI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SPEIController : ControllerBase
    {
        private readonly ISPEIService _service;

        public SPEIController(ISPEIService service)
        {
            _service = service;
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<clsPrintResult>> GetAllData()
        {
            return await _service.GetAllData();
        }


        /// <summary>
        /// 根据年份获取干旱烈度
        /// </summary>
        /// <param name="baseCode">基地代码</param>
        /// <param name="years">年份</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<clsPrintResult> GetdroughtIntensity(string baseCode = "51711", int years = 1957)
        {
            return await _service.GetdroughtIntensity(baseCode: baseCode, years: years);
        }



    }
}
