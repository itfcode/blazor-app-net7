using ITFCode.Core.Domain.DataContext;
using ITFCode.Domain.DataContext.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITFCode.Domain.DataContext
{
    public class ApplicationDbContext : ApplicationDbContextCore, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
