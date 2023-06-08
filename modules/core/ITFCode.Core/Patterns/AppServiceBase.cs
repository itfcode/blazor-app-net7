using ITFCode.Core.Exceptions;
using Microsoft.Extensions.Logging;

namespace ITFCode.Core.Patterns
{
    public abstract class AppServiceBase : DisposableBaseCore
    {
        #region Private & Protected Fields 

        private readonly ILogger<AppServiceBase> _logger;

        #endregion

        #region Protected Properties 

        protected ILogger<AppServiceBase> Logger => _logger ?? throw new PropertyNotDefinedException(nameof(Logger));

        #endregion

        #region Constructors 

        public AppServiceBase(ILogger<AppServiceBase> logger)
        {
            _logger = logger;
        }

        #endregion
    }
}
