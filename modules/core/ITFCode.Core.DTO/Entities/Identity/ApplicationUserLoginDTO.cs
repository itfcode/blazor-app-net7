using ITFCode.Core.DTO.Identity.Base;

namespace ITFCode.Core.DTO.Identity
{
    public class ApplicationUserLoginDTO : IdentityDTO
    {
        public virtual ApplicationUserDTO User { get; set; }
    }
}