using Microsoft.JSInterop;
using ReturnApp.WebClient.Services.BrowserStorage.Interface;
using ReturnApp.WebClient.Services.BrowserStorage.Base;

namespace ReturnApp.WebClient.Services.BrowserStorage
{
    /// <summary>
    /// Service to work with LocalStorage
    /// </summary>
    public class AppLocalStorage : AppBrowserStorage, IAppLocalStorage
    {
        #region Protected Properties 

        protected override string StorageName => "localStorage";

        #endregion

        #region Constructors 

        public AppLocalStorage(IJSRuntime jsRuntime) : base(jsRuntime) { }

        #endregion

        #region Public Methods: IAppLocalStorage Interface Implementation

        public async Task<bool> IsDevelopeMode()
        {
            return (await GetItem<bool?>(LocalStorageKeys.IsDevelopMode)) ?? false;
        }

        public async Task<bool> IsDevelopeMode(bool flag)
        {
            await SetItem(LocalStorageKeys.IsDevelopMode, flag);
            return await IsDevelopeMode();
        }

        #endregion

        #region Additional Classes

        private static class LocalStorageKeys
        {
            public static readonly string IsDevelopMode = "dev.isDevelopeMode";
        }

        #endregion
    }
}