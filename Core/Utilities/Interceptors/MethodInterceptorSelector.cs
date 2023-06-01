using Castle.Core.Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class MethodInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes= type.GetCustomAttributes<MethodInterceptorBaseAttribute>(true).ToList();
            var methodAttributes=type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptorBaseAttribute>(true).ToList();
            classAttributes.AddRange(methodAttributes);
            return classAttributes.OrderBy(x=>x.Priorty).ToArray();
        }
    }
}
