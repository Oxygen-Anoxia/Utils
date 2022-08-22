using AutoMapper;
using Model.Models;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.AutoMapper
{
    public class CustomProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile()
        {
            CreateMap<LogInfo, LogInfoDTO>();
            CreateMap<LogInfoDTO, LogInfo>();

        }
    }
}
