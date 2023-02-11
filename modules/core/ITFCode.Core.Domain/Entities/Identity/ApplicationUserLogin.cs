using Microsoft.AspNetCore.Identity;

namespace ITFCode.Core.Domain.Entities.Identity
{
    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        public virtual ApplicationUser User { get; set; }
    }

}
