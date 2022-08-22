﻿//using Google.Apis.Discovery;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.OpenApi.Models;
//using Swashbuckle.AspNetCore.SwaggerGen;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Threading.Tasks;

//namespace WebApplication2.Services
//{
//    public class HttpHeaderOperationFilter : IOperationFilter
//    {
//        public void Apply(OpenApiOperation operation, OperationFilterContext context)
//        {
//            #region 新方法
//            if (operation.Parameters == null)
//            {
//                operation.Parameters = new List<IParameter>();
//            }

//            if (context.ApiDescription.TryGetMethodInfo(out MethodInfo methodInfo))
//            {
//                if (!methodInfo.CustomAttributes.Any(t => t.AttributeType == typeof(AllowAnonymousAttribute))
//                        && !(methodInfo.ReflectedType.CustomAttributes.Any(t => t.AttributeType == typeof(AuthorizeAttribute))))
//                {
//                    operation.Parameters.Add(new NonBodyParameter
//                    {
//                        Name = "Authorization",
//                        In = "header",
//                        Type = "string",
//                        Required = true,
//                        Description = "请输入Token，格式为bearer XXX"
//                    });
//                }
//            }
//            #endregion

//            #region 已过时
//            //if (operation.Parameters == null)
//            //{
//            //    operation.Parameters = new List<IParameter>();
//            //}
//            //var actionAttrs = context.ApiDescription.ActionAttributes().ToList();
//            //var isAuthorized = actionAttrs.Any(a => a.GetType() == typeof(AuthorizeAttribute));
//            //if (isAuthorized == false)
//            //{
//            //    var controllerAttrs = context.ApiDescription.ControllerAttributes();
//            //    isAuthorized = controllerAttrs.Any(a => a.GetType() == typeof(AuthorizeAttribute));
//            //}
//            //var isAllowAnonymous = actionAttrs.Any(a => a.GetType() == typeof(AllowAnonymousAttribute));
//            //if (isAuthorized && isAllowAnonymous == false)
//            //{
//            //    operation.Parameters.Add(new NonBodyParameter
//            //    {
//            //        Name = "Authorization",
//            //        In = "header",
//            //        Type = "string",
//            //        Required = true,
//            //        Description = "请输入Token，格式为bearer XXX"
//            //    });
//            //}
//            #endregion

//        }
//    }
//}
