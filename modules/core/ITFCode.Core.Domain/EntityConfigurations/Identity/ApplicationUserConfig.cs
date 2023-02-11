using ITFCode.Core.Domain.Entities.Identity;
using ITFCode.Core.Domain.EntityConfigurations.Base;

namespace ITFCode.Core.Domain.EntityConfigurations.Identity
{
    public  class ApplicationUserConfig : EntityConfig<ApplicationUser>
    {
        protected override void Configure()
        {
            base.Configure();

            _builder.Property(x => x.FirstName).HasMaxLength(99);
            _builder.Property(x => x.LastName).HasMaxLength(99);

            // Each User can have many UserClaims
            _builder.HasMany(e => e.Claims)
                .WithOne(e => e.User)
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

            // Each User can have many UserLogins
            _builder.HasMany(e => e.Logins)
                .WithOne(e => e.User)
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            // Each User can have many UserTokens
            _builder.HasMany(e => e.Tokens)
                .WithOne(e => e.User)
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

            // Each User can have many entries in the UserRole join table
            _builder.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        }
    }
}
