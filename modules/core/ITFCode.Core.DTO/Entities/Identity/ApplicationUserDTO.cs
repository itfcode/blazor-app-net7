using ITFCode.Core.DTO.Identity.Base;

namespace ITFCode.Core.DTO.Identity
{
    public class ApplicationUserDTO : IdentityDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<ApplicationUserClaimDTO> Claims { get; set; } = new List<ApplicationUserClaimDTO>();
        public virtual ICollection<ApplicationUserLoginDTO> Logins { get; set; } = new List<ApplicationUserLoginDTO>();
        public virtual ICollection<ApplicationUserTokenDTO> Tokens { get; set; } = new List<ApplicationUserTokenDTO>();
        public virtual ICollection<ApplicationUserRoleDTO> UserRoles { get; set; } = new List<ApplicationUserRoleDTO>();
    }
}