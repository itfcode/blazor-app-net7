using ITFCode.Core.DTO.Identity.Base;

namespace ITFCode.Core.DTO.Identity
{
    public class ApplicationUserRoleDTO : IdentityDTO
    {
        public virtual ApplicationUserDTO User { get; set; }
        public virtual ApplicationRoleDTO Role { get; set; }
    }
}