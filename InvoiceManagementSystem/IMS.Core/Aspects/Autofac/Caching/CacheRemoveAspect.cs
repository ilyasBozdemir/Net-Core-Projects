using Castle.DynamicProxy;
using IMS.Core.CrossCuttingConcerns.Caching;
using IMS.Core.Utilities.Interceptors;
using IMS.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace IMS.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
