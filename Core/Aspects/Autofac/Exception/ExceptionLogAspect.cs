using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using Castle.DynamicProxy;
using Core.Constants.Messages;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.CrossCuttingConcerns.Logging;
using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Service;
using Newtonsoft.Json;
using Microsoft.Extensions.Primitives;
using Entities.Concrete.Enums;

namespace Core.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        private IHttpContextAccessor _httpContextAccessor;
        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);
            logDetailWithException.ExceptionMessage = e.ToString();
            var serviceName = invocation.Method.DeclaringType.Name;
            var exists = Enum.IsDefined(typeof(NviServiceEnum), serviceName);
            _loggerServiceBase.Error(logDetailWithException, exists);
        }
        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();

            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name,
                });
            }

            var isUserRecordNumberExist = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("UserRecordNumber", out StringValues userRecordNumber);
            if (!isUserRecordNumberExist)
            {
                userRecordNumber = "";
            }

            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            var remoteIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            var logDetailWithException = new LogDetailWithException
            {
                MethodName = $"{invocation.Method.DeclaringType.Name}.{invocation.Method.Name}",
                LogParameters = logParameters,
                Date = DateTime.UtcNow,
                RemoteIpAddress = remoteIpAddress,
                UserName = userName,
                UserRecordNumber = userRecordNumber,
                Response = JsonConvert.SerializeObject(invocation.ReturnValue, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        })
        };

            return logDetailWithException;
        }










    }
}
