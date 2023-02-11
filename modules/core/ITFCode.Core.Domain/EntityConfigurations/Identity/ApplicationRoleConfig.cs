using Microsoft.EntityFrameworkCore;
using ITFCode.Core.Domain.Entities.Identity;
using ITFCode.Core.Domain.EntityConfigurations.Base;

namespace ITFCode.Core.Domain.EntityConfigurations.Identity
{
    public class ApplicationRoleConfig : EntityConfig<ApplicationRole> 
    {
        protected override void Configure()
        {
            base.Configure();

            _builder.Property(x => x.Description)
                .HasMaxLength(499)
                .HasColumnOrder(4);

            // Each Role can have many entries in the UserRole join table
            _builder.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            // Each Role can have many associated RoleClaims
            _builder.HasMany(e => e.RoleClaims)
                .WithOne(e => e.Role)
                .HasForeignKey(rc => rc.RoleId)
                .IsRequired();
        }
    }
}
