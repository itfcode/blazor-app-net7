using ReturnApp.WebClient.Services.BrowserStorage.Base.Interface;

namespace ReturnApp.WebClient.Services.BrowserStorage.Interface
{
    public interface IAppLocalStorage : IAppBrowserStorage
    {
        Task<bool> IsDevelopeMode();
        Task<bool> IsDevelopeMode(bool flag);
    }
}
