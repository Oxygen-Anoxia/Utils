using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public object TestDB()
        {
            return "TestDB";
        }

    }
}
