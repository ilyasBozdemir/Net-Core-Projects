﻿using Castle.DynamicProxy;
using IMS.Core.Utilities.Interceptors;
using IMS.Core.Utilities.IoC;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace IMS.Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopWacth;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopWacth = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        protected override void OnBefore(IInvocation invocation)
        {
            _stopWacth.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopWacth.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}--->{_stopWacth.Elapsed.TotalSeconds}");
            }
            _stopWacth.Reset();
        }
    }
}
