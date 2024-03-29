﻿using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Modules.Conferences.Core.DAL;
using ModularMonolith.Modules.Conferences.Core.DAL.Repositories;
using ModularMonolith.Modules.Conferences.Core.Repositories;
using ModularMonolith.Modules.Conferences.Core.Services;

namespace ModularMonolith.Modules.Conferences.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IHostService, HostService>();
            services.AddScoped<IConferenceService, ConferenceService>();
            services.AddDatabase();
            
            return services;
        }
    }
}