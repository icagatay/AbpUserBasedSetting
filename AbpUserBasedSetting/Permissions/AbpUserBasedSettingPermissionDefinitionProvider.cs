using AbpUserBasedSetting.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace AbpUserBasedSetting.Permissions;

public class AbpUserBasedSettingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpUserBasedSettingPermissions.GroupName);


        
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpUserBasedSettingPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpUserBasedSettingResource>(name);
    }
}
