using Microsoft.JSInterop;
using Newtonsoft.Json;
using ReturnApp.WebClient.Services.BrowserStorage.Base.Interface;

namespace ReturnApp.WebClient.Services.BrowserStorage.Base
{
    public abstract class AppBrowserStorage : IAppBrowserStorage
    {
        protected readonly IJSRuntime _jsRuntime;

        protected abstract string StorageName { get; }

        public AppBrowserStorage(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<T> GetItem<T>(string key)
        {
            var json = await _jsRuntime.InvokeAsync<string>($"{StorageName}.getItem", key);

            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                return default;
            }
        }

        public async Task SetItem(string key, object value)
        {
            string json = JsonConvert.SerializeObject(value);
            await _jsRuntime.InvokeAsync<object>($"{StorageName}.setItem", key, json);
        }
    }
}