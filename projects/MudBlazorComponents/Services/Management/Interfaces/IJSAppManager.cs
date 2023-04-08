namespace ReturnApp.WebClient.Services.Management.Interfaces
{
    public interface IJSAppManager
    {
        Task<bool> IsDevelopeMode();

        Task TurnOnDevelopeMode();
        Task TurnOffDevelopeMode();

        Task<int> GetScreenWidth();
        Task<int> GetPageWidth();
    }
}
