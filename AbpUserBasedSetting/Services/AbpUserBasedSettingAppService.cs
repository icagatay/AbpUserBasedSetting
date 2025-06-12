using Volo.Abp.Application.Services;
using AbpUserBasedSetting.Localization;

namespace AbpUserBasedSetting.Services;

/* Inherit your application services from this class. */
public abstract class AbpUserBasedSettingAppService : ApplicationService
{
    protected AbpUserBasedSettingAppService()
    {
        LocalizationResource = typeof(AbpUserBasedSettingResource);
    }
}