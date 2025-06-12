using Volo.Abp.Settings;

namespace AbpUserBasedSetting.Settings;

public class UserThemeSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(
            new SettingDefinition(
                UserSettings.PreferredTheme,
                defaultValue: "light",
                isVisibleToClients: true
            )
        );
    }
}
