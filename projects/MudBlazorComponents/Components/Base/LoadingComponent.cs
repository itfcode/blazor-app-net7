using Microsoft.AspNetCore.Components;
using ReturnApp.WebClient.Services.Management.Interfaces;

namespace MudBlazorComponents.Components.Base
{
    /// <summary>
    /// Base Component for working with component LoadingContent
    /// </summary>
    public abstract class LoadingComponent : ComponentBase
    {
        #region Private & Protected Fields 

        protected bool _isTestMode = false;

        protected bool _loading = true;
        protected bool _loadFailed = false;
        protected Exception? _error;

        #endregion

        #region Protected Properties: Option 

        protected bool IsTestMode => _isTestMode;

        #endregion

        #region Protected Properties: Inject

        [Inject]
        protected IJSAppManager JSAppManager { get; set; }

        #endregion

        #region Public Properties: Parameters

        [Parameter]
        public bool Loading { get => _loading; set => _loading = value; }

        [Parameter]
        public bool LoadFailed { get => _loadFailed; set => _loadFailed = value; }

        [Parameter]
        public Exception? LoadError { get => _error; set => _error = value; }

        #endregion

        #region Protected Methods: Parent Methods

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
                _isTestMode = await JSAppManager.IsDevelopeMode();
        }

        #endregion
    }
}