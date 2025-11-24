using Bluwox.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bluwox.Migrations
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<ServiceManagement> ServiceManagements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ServiceManagement>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<ServiceManagement>().HasIndex(x => new { x.Name, x.CreatedDate }); //indexing


            modelBuilder.Entity<ServiceManagement>()
                .HasOne(x => x.Category)
                .WithMany(x => x.ServiceManagements)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<SubCategory>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(sc => sc.CategoryId);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(BaseEntity.CreatedDate))
                        .HasDefaultValueSql("GETUTCDATE()");

                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(BaseEntity.UpdatedDate))
                        .ValueGeneratedOnUpdate();
                }
            }
        }
    }
}
