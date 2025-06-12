using AbpUserBasedSetting.Settings;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.SettingManagement;
using Volo.Abp.Users;

namespace AbpUserBasedSetting.Pages;

public class IndexModel : AbpPageModel
{
    private readonly ISettingManager _settingManager;
    private readonly ICurrentUser _currentUser;

    public IndexModel(ISettingManager settingManager, ICurrentUser currentUser)
    {
        _settingManager = settingManager;
        _currentUser = currentUser;
    }

    public string Theme { get; set; }

    public async Task OnGetAsync()
    {
        if (_currentUser.IsAuthenticated)
        {
            Theme = await _settingManager.GetOrNullForUserAsync(UserSettings.PreferredTheme, _currentUser.Id.Value);
        }

        Theme ??= "light";
    }
}