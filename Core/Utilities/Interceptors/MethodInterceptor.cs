using Castle.Core.Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class MethodInterceptor : MethodInterceptorBaseAttribute
    {
        protected virtual void OnBefore (IInvocation invocation){}
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        protected void OnException(IInvocation invocation,Exception ex) { }
        public override void Intercept(IInvocation invocation)
        {
            OnBefore(invocation);
            bool success = true;
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex )
            {
                success = false;
                OnException(invocation, ex);    
                throw;
            }
            finally
            {
                if(success)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
