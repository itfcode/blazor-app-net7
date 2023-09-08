using ITFCode.Core.Domain.DataContext.Interfaces;
using ITFCode.Core.Domain.Entities.Identity;
using ITFCode.Core.Domain.EntityConfigurations.Base;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ITFCode.Core.Domain.DataContext
{
    public abstract class ApplicationDbContextCore : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaim,
        ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>, IApplicationDbContextCore
    {
        #region Constructors 

        public ApplicationDbContextCore(DbContextOptions options)
            : base(options)
        {
        }

        #endregion

        #region Protected Methods 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            BuildModelConfigurations(modelBuilder, typeof(EntityConfig<>), Assembly.GetExecutingAssembly().GetTypes());
        }

        protected void BuildModelConfigurations(ModelBuilder modelBuilder, Type baseType, Type[] types)
        {
            ArgumentNullException.ThrowIfNull(modelBuilder, nameof(modelBuilder));
            ArgumentNullException.ThrowIfNull(baseType, nameof(baseType));
            ArgumentNullException.ThrowIfNull(types, nameof(types));

            types.Where(type =>
                    (type.BaseType != null && type.BaseType.IsGenericType && !type.IsAbstract)
                    &&
                    (type.BaseType.GetGenericTypeDefinition() == baseType))
                .ToList()
                .ForEach(type =>
                {
                    dynamic instance = Activator.CreateInstance(type) ?? throw new NullReferenceException();
                    modelBuilder.ApplyConfiguration(instance);
                });
        }

        #endregion
    }
}