using Volo.Abp.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace AbpUserBasedSetting.Data;

public class AbpUserBasedSettingDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public AbpUserBasedSettingDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        
        /* We intentionally resolving the AbpUserBasedSettingDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AbpUserBasedSettingDbContext>()
            .Database
            .MigrateAsync();

    }
}
