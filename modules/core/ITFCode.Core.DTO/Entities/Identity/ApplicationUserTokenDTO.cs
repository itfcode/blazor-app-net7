using ITFCode.Core.DTO.Identity.Base;

namespace ITFCode.Core.DTO.Identity
{
    public class ApplicationUserTokenDTO : IdentityDTO
    {
        public virtual ApplicationUserDTO User { get; set; }
    }
}