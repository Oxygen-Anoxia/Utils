using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object TestDB(clsModel model)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }


    }

    public class clsModel
    {
        /// <summary>
        /// id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// age
        /// </summary>
        public int age { get; set; }
    }
}
