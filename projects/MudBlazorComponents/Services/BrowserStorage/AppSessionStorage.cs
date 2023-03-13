using Microsoft.JSInterop;
using ReturnApp.WebClient.Services.BrowserStorage.Base;
using ReturnApp.WebClient.Services.BrowserStorage.Interface;

namespace ReturnApp.WebClient.Services.BrowserStorage
{
    public class AppSessionStorage : AppBrowserStorage, IAppSessionStorage
    {
        protected override string StorageName => "sessionStorage";

        public AppSessionStorage(IJSRuntime jsRuntime) : base(jsRuntime)
        {
        }

        #region Public Methods : IAppSessionStorage Interface Implenemtation

        public async Task<string> SessionId()
        {
            return await GetItem<string>(SessionStorageKeys.SessionId);
        }

        public async Task<string> SessionId(string id)
        {
            await SetItem(SessionStorageKeys.SessionId, id);
            return await SessionId();
        }

        #endregion

        #region Additional Classes

        private static class SessionStorageKeys
        {
            public static readonly string SessionId = "app.sessionId";
        }

        #endregion
    }
}