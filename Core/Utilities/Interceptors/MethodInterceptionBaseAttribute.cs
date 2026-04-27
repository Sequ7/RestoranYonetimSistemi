using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method,AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute
        : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {
            var isSuccess = true;

            try
            {
                OnBefore(invocation);
                invocation.Proceed();
            }
            catch
            {
                isSuccess = false;
                throw;
            }
            finally
            {
                if (isSuccess)
                    OnSuccess(invocation);
            }
        }

        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
    }
}
