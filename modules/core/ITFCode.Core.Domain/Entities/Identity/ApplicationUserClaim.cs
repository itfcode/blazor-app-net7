using Microsoft.AspNetCore.Identity;

namespace ITFCode.Core.Domain.Entities.Identity
{
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
