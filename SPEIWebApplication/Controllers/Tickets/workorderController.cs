using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPEIWebApplication.Controllers.Tickets
{
    [Route("data/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class workorderController : ControllerBase
    {

        /// <summary>
        /// 2.上传作业票数据接口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<clsParkCommonResponse> workTicket(object body)
        {
            return new clsParkCommonResponse()
            {
                code = 200,
                msg = "请求成功",
                data = "作业票同步结束, 成功1条, 失败0条。作业票储存成功的作业票id有[12833a0c-54b3-48c2-86f7-96d0f195cc7e], 失败的作业票id有[]。错误原因为[]"
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<clsParkCommonResponse> ticketFile([FromForm] string wid, IFormFile file)
        {

            return new clsParkCommonResponse()
            {
                code = 200,
                msg = "请求成功",
                data = "作业票附件存储成功。"
            };
        }

    }

    /// <summary>
    /// 园区-作业票通用上传返回类
    /// </summary>
    public class clsParkCommonResponse
    {
        /// <summary>
        /// 成功200；认证失败401
        /// </summary>
        public int code { get; set; }
        public string msg { get; set; }
        public object data { get; set; }


    }
}
