using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoizen.Data
{
    public static class DataDependencyInjection
    {
        public static IServiceCollection ImplementDataInjection(this IServiceCollection services)
        {
            services.AddSingleton<DataStore>();      
            return services;
        }
    }
}
