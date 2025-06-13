# User Based Setting

🎯 Amaç
Bu örnekte, Single Layer Razor Pages yapısında geliştirilmiş bir ABP projesinde **kullanıcıya özel ayarların** nasıl geliştirileceğini öğreneceğiz.

Her kullanıcı kendi temasını seçebilecek
Tercih veritabanında kullanıcıya özel olarak saklanacak
Ana sayfa yüklendiğinde, kullanıcıya özel tema otomatik olarak uygulanacak

---

## 📁 Proje Yapısı

```
UserBasedSetting.Web/
├── Pages/
│ ├── Index.cshtml / Index.cshtml.cs
│ └── Settings.cshtml / Settings.cshtml.cs
├── Settings/
│ ├── UserSettings.cs
│ └── UserThemeSettingDefinitionProvider.cs
└── UserBasedSettingWebModule.cs

```

📌 1. Ayar Anahtarının Tanımı
```csharp
public static class UserSettings
{
    public const string PreferredTheme = "AbpUserBasedSetting.User.PreferredTheme";
}
```
🧠 2. Ayar Tanımını Kaydet (UserThemeSettingDefinitionProvider)
```csharp
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
```

⚙️ 3. Ayar Sağlayıcısını Module Sınıfında Kaydet
```csharp
Configure<AbpSettingOptions>(options =>
{
    options.DefinitionProviders.Add<UserThemeSettingDefinitionProvider>();
});
```

💾 4. Tema Seçimi Sayfası (Settings.cshtml)

📄 Pages/Settings.cshtml

```csharp
@page
@model AbpUserBasedSetting.Pages.SettingsModel
@{
}

<h3>Theme Preferences</h3>

<form method="post">
    <select name="theme" asp-for="Theme">
        <option value="light">Light Theme</option>
        <option value="dark">Dark Theme</option>
    </select>
    <button type="submit">Save</button>
</form>
```

📄 Pages/Settings.cshtml.cs

```csharp
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
```

🏠 5. Tema Uygulaması (Ana Sayfa Index.cshtml)

📄 Pages/Index.cshtml

```csharp
@{
    var theme = Model.Theme ?? "light";
}
<a href="/settings" class="btn btn-primary mb-2 mt-2 ml-2 @theme">Settings</a>
```

📄 Pages/Index.cshtml.cs

```csharp
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
```

📄 Pages/Index.cshtml.css

```css
a.light {
    background-color: white;
    color: black;
}

a.dark {
    background-color: #121212;
    color: white;
}
```

## Nasıl Çalışır?

1. `AbpUserBasedSetting.User.PreferredTheme` adlı özel bir ayar tanımlanır
2. `/Settings` sayfasında kullanıcı `light` (açık) veya `dark` (koyu) tema seçebilir
3. Seçilen tema `ISettingManager.SetForUserAsync(...)` ile kaydedilir
4. Ana sayfa `/Index` açıldığında kullanıcıya özel tema otomatik olarak yüklenir

---

## 🔧 Kurulum Adımları

### Repoyu Klonla

```bash
git clone https://github.com/icagatay/AbpUserBasedSetting.git
