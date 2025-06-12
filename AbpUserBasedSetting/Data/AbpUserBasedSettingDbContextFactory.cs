using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AbpUserBasedSetting.Data;

public class AbpUserBasedSettingDbContextFactory : IDesignTimeDbContextFactory<AbpUserBasedSettingDbContext>
{
    public AbpUserBasedSettingDbContext CreateDbContext(string[] args)
    {
        AbpUserBasedSettingEfCoreEntityExtensionMappings.Configure();
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<AbpUserBasedSettingDbContext>()
            .UseSqlite(configuration.GetConnectionString("Default"));

        return new AbpUserBasedSettingDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}