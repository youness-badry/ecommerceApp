using EcommerceApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication.Data
{
    public class StoreContext : DbContext
    {
        private const string appUser = "SampleApplication";
        private readonly IHttpContextAccessor _httpContextAccessor;
        public StoreContext(DbContextOptions<StoreContext> options,
            IHttpContextAccessor httpContextAccessor = null) : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }


        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }

        public void AddAuditInfo()
        {
            var entities = ChangeTracker.Entries<IEntity>().Where(e => 
                e.State == EntityState.Added || e.State == EntityState.Modified);

            var utcNow = DateTime.UtcNow;
            var user = _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? appUser;
            var ipAddress = _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedOnUtc = utcNow;
                    entity.Entity.CreatedBy = user;
                }

                if (entity.State == EntityState.Modified)
                {
                    entity.Entity.LastModifiedOnUtc = utcNow;
                    entity.Entity.LastModifiedBy = user;
                }

                entity.Entity.IPAddress = ipAddress;
            }
        }
    }
}
