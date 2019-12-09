using Microsoft.Extensions.Configuration;
using System.IO;

namespace Discount.Tests.Configurations
{
    public static class SettingsConfiguration
    {
        public static IConfigurationRoot GetConfigurationRoot =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(
                    path: "appsettings.Test.json",
                    optional: true,
                    reloadOnChange: true)
                .Build();
    }
}
