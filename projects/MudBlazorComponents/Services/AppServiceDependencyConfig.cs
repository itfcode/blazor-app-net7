using ReturnApp.WebClient.Services.BrowserStorage;
using ReturnApp.WebClient.Services.BrowserStorage.Interface;
using ReturnApp.WebClient.Services.Management;
using ReturnApp.WebClient.Services.Management.Interfaces;

namespace MudBlazorComponents.Services
{
    public static class AppServiceDependencyConfig
    {
        public static void Register(IServiceCollection services)
        {
            // services registration of Identity Entities
            services.AddScoped<IAppLocalStorage, AppLocalStorage>();
            services.AddScoped<IAppSessionStorage, AppSessionStorage>();
            services.AddScoped<IJSAppManager, JSAppManager>();
        }
    }
}
