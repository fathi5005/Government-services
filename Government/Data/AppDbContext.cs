using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Claims;

namespace Government.Data
{
    public class AppDbContext : IdentityDbContext<Admin>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppDbContext(DbContextOptions<AppDbContext> options , IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceData> ServicesData { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<ServiceField> ServicesField { get; set; }
        public DbSet<RequiredDocument> RequiredDocuments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<AttachedDocument> AttachedDocuments { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminResponse> AdminsResponse { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder); // Ensure Identity setup is applied
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    var entries = ChangeTracker.Entries<Request>();
        //    var UserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);


        //    foreach (var entry in entries)
        //    {

        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property(x => x.UserId).CurrentValue = UserId!;
        //           // entry.Property(x => x.RequestDate).CurrentValue = DateTime.UtcNow;


        //        }

        //    }


        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}
