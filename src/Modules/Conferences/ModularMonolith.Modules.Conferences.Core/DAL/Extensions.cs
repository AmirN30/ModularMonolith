using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Modules.Conferences.Core.DAL.EF;
using ModularMonolith.Modules.Conferences.Core.DAL.Repositories;
using ModularMonolith.Modules.Conferences.Core.Repositories;
using ModularMonolith.Shared.Infrastructure.Postgres;

namespace ModularMonolith.Modules.Conferences.Core.DAL
{
    internal static class Extensions
    {
        internal static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            // services.AddSingleton<IHostRepository, InMemoryHostRepository>();
            // services.AddSingleton<IConferenceRepository, InMemoryConferenceRepository>();
            
            services.AddPostgres<ConferencesDbContext>();
            services.AddScoped<IConferenceRepository, ConferenceDatabaseRepository>();
            services.AddScoped<IHostRepository, HostDatabaseRepository>();
            return services;
        } 
    }
}