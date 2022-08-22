using Model.SPEI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IService.SPEI
{
    public interface ISPEIService
    {
        /// <summary>
        /// 根据年份获取干旱烈度
        /// </summary>
        /// <param name="baseCode"></param>
        /// <param name="years"></param>
        /// <returns></returns>
        Task<clsPrintResult> GetdroughtIntensity(string baseCode = "51711", int years = 1957);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        Task<List<clsPrintResult>> GetAllData();


    }
}
