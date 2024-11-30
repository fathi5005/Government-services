
namespace Government.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
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
        }

    }
}
