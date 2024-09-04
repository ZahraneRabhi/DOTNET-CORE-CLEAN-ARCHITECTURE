using Microsoft.Extensions.Configuration;
using System.IO;

public class ConfigurationHelper
{
    /// <summary>
    /// Builds and returns an <see cref="IConfigurationRoot"/> instance.
    /// <returns>An <see cref="IConfigurationRoot"/> instance containing the configuration settings.</returns>
    public static IConfigurationRoot BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("<your appsettings.json path>")
            .Build();
    }
}
