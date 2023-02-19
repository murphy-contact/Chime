using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Chime.Shared.Infrastructure.Modules;

internal static class Extensions
{
    public static IHostBuilder ConfigureModules(this IHostBuilder builder)
    {
        return builder.ConfigureAppConfiguration((ctx, cfg) =>
        {
            var enumerable = GetSettings("*");
            foreach (var settings in enumerable)
                cfg.AddJsonFile(settings);

            IEnumerable<string> GetSettings(string pattern)
            {
                return Directory.EnumerateFiles(ctx.HostingEnvironment.ContentRootPath,
                    $"modules.{pattern}.json", SearchOption.AllDirectories);
            }
        });
    }
}