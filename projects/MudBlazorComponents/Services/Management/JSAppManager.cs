using Microsoft.JSInterop;
using ReturnApp.WebClient.Services.BrowserStorage.Interface;
using ReturnApp.WebClient.Services.Management.Interfaces;

namespace ReturnApp.WebClient.Services.Management
{
    public class JSAppManager : IJSAppManager
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly IAppLocalStorage _appLocalStorage;
        private readonly IAppSessionStorage _appSessionStorage;

        public JSAppManager(IJSRuntime jsRuntime, IAppLocalStorage appLocalStorage, IAppSessionStorage appSessionStorage)
        {
            _jsRuntime = jsRuntime;
            _appLocalStorage = appLocalStorage;
            _appSessionStorage = appSessionStorage;
        }

        public async Task<bool> IsDevelopeMode() => await _appLocalStorage.IsDevelopeMode();

        public async Task TurnOnDevelopeMode() => await _appLocalStorage.IsDevelopeMode(true);

        public async Task TurnOffDevelopeMode() => await _appLocalStorage.IsDevelopeMode(false);

        public async Task<int> GetScreenWidth() => await _jsRuntime.InvokeAsync<int>("eval", "(() => window.screen.width)()");

        public async Task<int> GetPageWidth() => await _jsRuntime.InvokeAsync<int>("eval", "(() => window.innerWidth)()");
    }
}