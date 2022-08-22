using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPEIWebApplication.Controllers.Tickets
{

    [Route("[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class authController : ControllerBase
    {

        /// <summary>
        /// 登录接口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<clsLoginResponse> login(clsLoginParamModelYtwh body)
        {
            return new clsLoginResponse()
            {
                code = 200,
                msg = "请求成功",
                data = new clsLoginResponseData()
                {
                    username = "textaccount",
                    token = "BqO2EHpdGyiIWMXjsjCxtf4HVTfGAEFEEoWHoZa2qrg="
                }
            };
        }

    }


    /// <summary>
    /// 山东作业票通用——登录接口body参数
    /// </summary>
    public class clsLoginParamModelYtwh
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
    }

    /// <summary>
    /// 烟台万华——登录返回对象
    /// </summary>
    public class clsLoginResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 请求成功
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public clsLoginResponseData data { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class clsLoginResponseData
    {
        /// <summary>
        /// 
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string token { get; set; }
    }



}
