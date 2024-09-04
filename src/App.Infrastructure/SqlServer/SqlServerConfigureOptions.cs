using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;


namespace App.Infrastructure.SqlServer
{
    /// <summary>
    /// Configures <see cref="SqlServerOptions"/> from the application settings.
    /// </summary>
    public class SqlServerConfigureOptions : IConfigureOptions<SqlServerOptions>
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerConfigureOptions"/> class.
        /// </summary>
        /// <param name="configuration">Application configuration.</param>
        public SqlServerConfigureOptions(IConfiguration configuration) =>
            _configuration = configuration;

        /// <summary>
        /// Configures the <see cref="SqlServerOptions"/> instance from the application settings.
        /// </summary>
        /// <param name="options"><see cref="SqlServerOptions"/> instance to configure.</param>
        public void Configure(SqlServerOptions options) =>
            options.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
    }
}
