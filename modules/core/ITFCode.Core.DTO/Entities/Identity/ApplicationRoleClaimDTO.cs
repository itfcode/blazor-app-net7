using ITFCode.Core.DTO.Identity.Base;

namespace ITFCode.Core.DTO.Identity
{
    public class ApplicationRoleClaimDTO : IdentityDTO
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual ApplicationRoleDTO Role { get; set; }
    }
}
