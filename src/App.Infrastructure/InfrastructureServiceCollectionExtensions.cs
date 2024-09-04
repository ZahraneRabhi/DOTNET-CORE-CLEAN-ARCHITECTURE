using App.Data;
using App.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace App.Infrastructure
{
    public static class InfrastructureServiceCollectionExtensions
    {
        /// <summary>
        /// Adds SQL Server services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        public static IServiceCollection AddSqlServer(this IServiceCollection services)
        {
            services.TryAddSingleton<IConfigureOptions<SqlServerOptions>, SqlServerConfigureOptions>();

            services.AddDbContext<AppDbContext>((serviceProvider, options) =>
            {
                var sqlOptions = serviceProvider.GetRequiredService<IOptions<SqlServerOptions>>().Value;
                options.UseSqlServer(sqlOptions.ConnectionString);
            });

            return services;
        }
    }
}
