using ReturnApp.WebClient.Services.BrowserStorage.Base.Interface;

namespace ReturnApp.WebClient.Services.BrowserStorage.Interface
{
    public interface IAppSessionStorage : IAppBrowserStorage
    {
        Task<string> SessionId();
        Task<string> SessionId(string id);
    }
}
