using ITFCode.Core.DTO.Identity.Base;

namespace ITFCode.Core.DTO.Identity
{
    public class ApplicationRoleDTO : IdentityDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ApplicationUserRoleDTO> UserRoles { get; set; } = new List<ApplicationUserRoleDTO>();
        public virtual ICollection<ApplicationRoleClaimDTO> RoleClaims { get; set; } = new List<ApplicationRoleClaimDTO>();
    }
}