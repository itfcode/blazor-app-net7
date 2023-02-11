using Microsoft.AspNetCore.Identity;

namespace ITFCode.Core.Domain.Entities.Identity
{
    public class ApplicationUserToken : IdentityUserToken<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
