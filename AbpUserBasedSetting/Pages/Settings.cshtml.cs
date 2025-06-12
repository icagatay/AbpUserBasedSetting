using AbpUserBasedSetting.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.SettingManagement;
using Volo.Abp.Users;

namespace AbpUserBasedSetting.Pages
{
    [Authorize]
    public class SettingsModel : PageModel
    {
        private readonly ISettingManager _settingManager;
        private readonly ICurrentUser _currentUser;

        public SettingsModel(ISettingManager settingManager, ICurrentUser currentUser)
        {
            _settingManager = settingManager;
            _currentUser = currentUser;
        }

        [BindProperty]
        public string Theme { get; set; }


        public async Task OnGetAsync()
        {
            if (_currentUser.IsAuthenticated)
            {
                Theme = await _settingManager.GetOrNullForUserAsync(UserSettings.PreferredTheme, _currentUser.Id.Value);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (_currentUser.IsAuthenticated)
            {
                await _settingManager.SetForUserAsync(_currentUser.Id.Value, UserSettings.PreferredTheme, Theme);
            }

            return RedirectToPage("/Index");
        }
    }
}
