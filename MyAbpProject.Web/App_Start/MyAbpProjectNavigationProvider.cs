using Abp.Application.Navigation;
using Abp.Localization;
using MyAbpProject.Authorization;
using MyAbpProject.Localization.Dtos;
using MyAbpProject.Localization;
using Abp.Runtime.Session;

namespace MyAbpProject.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class MyAbpProjectNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            //var tem = _languageTextAppService.GetStringOrNull(GetStringOrNullInput("Barcodes"));
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                            "Home",
                            L("HomePage"),
                            url: "",
                            icon: "fa fa-home",
                            requiresAuthentication: true
                        )
                ).AddItem(
                    new MenuItemDefinition(
                            "Tenants",
                            L("Tenants"),
                            url: "Tenants",
                            icon: "fa fa-globe",
                            requiredPermissionName: PermissionNames.Pages_Tenants
                        )
                ).AddItem(
                    new MenuItemDefinition(
                            "Users",
                            L("Users"),
                            url: "Users",
                            icon: "fa fa-users",
                            requiredPermissionName: PermissionNames.Pages_Users
                        )
                ).AddItem(
                    new MenuItemDefinition(
                            "About",
                            L("About"),
                            url: "About",
                            icon: "fa fa-info"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                            "Barcodes",
                            L("Barcodes"),
                            icon: "fa fa-barcode"
                        ).AddItem
                        (
                            new MenuItemDefinition(
                                "Barcode",
                                L("Barcodes"),
                                url: "/Barcodes/Index",
                                icon: "fa fa-barcode"
                                )
                        ).AddItem
                        (
                            new MenuItemDefinition(
                                "GridBarcode",
                                L("Barcodes"),
                                url: "/Barcodes/GridIndex",
                                icon: "fa fa-barcode"
                                )
                        )
                ).AddItem(
                    new MenuItemDefinition(
                            "ApplicationLanguageTexts",
                            L("ApplicationLanguageTexts"),
                            url: "ApplicationLanguageTexts",
                            icon: "fa fa-language"
                        )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyAbpProjectConsts.LocalizationSourceName);
        }
    }
}
