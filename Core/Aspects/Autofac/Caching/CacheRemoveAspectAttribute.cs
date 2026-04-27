using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspectAttribute(string pattern) : MethodInterceptionBaseAttribute
    {
        private readonly string _pattern = pattern ?? throw new ArgumentNullException(nameof(pattern));

        protected override void OnSuccess(IInvocation invocation)
        {
            var cacheManager =
                ServiceTool.ServiceProvider.GetRequiredService<ICacheManager>();

            cacheManager.RemoveByPattern(_pattern);
        }
    }
}
