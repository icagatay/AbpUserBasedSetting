using Microsoft.Extensions.Localization;
using AbpUserBasedSetting.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpUserBasedSetting;

[Dependency(ReplaceServices = true)]
public class AbpUserBasedSettingBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AbpUserBasedSettingResource> _localizer;

    public AbpUserBasedSettingBrandingProvider(IStringLocalizer<AbpUserBasedSettingResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}