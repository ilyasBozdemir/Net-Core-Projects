﻿using IMS.Core.CrossCuttingConcerns.Caching;
using IMS.Core.CrossCuttingConcerns.Caching.Microsoft;
using IMS.Core.CrossCuttingConcerns.Logging;
using IMS.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILoggerService, DBLogger>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
