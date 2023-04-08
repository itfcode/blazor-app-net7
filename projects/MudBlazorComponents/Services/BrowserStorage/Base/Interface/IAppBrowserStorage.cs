namespace ReturnApp.WebClient.Services.BrowserStorage.Base.Interface
{
    public interface IAppBrowserStorage
    {
        Task<T> GetItem<T>(string key);
        Task SetItem(string key, object value);
    }
}
