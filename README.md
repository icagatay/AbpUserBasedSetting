# UserBasedSetting

**UserBasedSetting**, ABP Framework kullanarak **kullanıcıya özel ayarların** nasıl geliştirileceğini gösteren bir örnek projedir.  
Uygulama **Single Layer (Tek Katman)** mimarisi ve **Razor Pages** kullanılarak geliştirilmiştir.

---

## 🎯 Özellikler

- Açık / Koyu tema seçimi
- Tema tercihi kullanıcı bazlı olarak veritabanında saklanır
- Razor Pages ile sade kullanıcı arayüzü
- `SettingDefinitionProvider` ile özel ayar tanımı yapılır

---

## 📁 Proje Yapısı

UserBasedSetting.Web/
├── Pages/
│ ├── Index.cshtml / Index.cshtml.cs
│ └── Settings.cshtml / Settings.cshtml.cs
├── Settings/
│ ├── UserSettings.cs
│ └── UserThemeSettingDefinitionProvider.cs
└── UserBasedSettingWebModule.cs


---

## 🧠 Nasıl Çalışır?

1. `AbpUserBasedSetting.User.PreferredTheme` adlı özel bir ayar tanımlanır
2. `/Settings` sayfasında kullanıcı `light` (açık) veya `dark` (koyu) tema seçebilir
3. Seçilen tema `ISettingManager.SetForUserAsync(...)` ile kaydedilir
4. Ana sayfa `/Index` açıldığında kullanıcıya özel tema otomatik olarak yüklenir

---

## 🔧 Kurulum Adımları

### Repoyu Klonla

```bash
git clone https://github.com/icagatay/AbpUserBasedSetting.git
