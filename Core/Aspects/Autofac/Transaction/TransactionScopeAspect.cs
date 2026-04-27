using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspectAttribute : MethodInterceptionAttribute
    {
        public override void Intercept(IInvocation invocation)
        {
            using TransactionScope transactionScope = new();
            invocation.Proceed();
            transactionScope.Complete();
        }
    }
}
