using Microsoft.EntityFrameworkCore;

namespace DepartmentMangementMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<DepartmentMangementMVC.Models.Department> Departments { get; set; }
        public DbSet<DepartmentMangementMVC.Models.Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MS535M4\\SQLEXPRESS;Database=DepartmentManagementDB;Trusted_Connection=True;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between Employee and Department
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DepartmentMangementMVC.Models.Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);
            // seedind
            modelBuilder.Entity<DepartmentMangementMVC.Models.Department>().HasData(
                new DepartmentMangementMVC.Models.Department { Id = 1, Name = "HR", ManagerName = "John Doe" },
                new DepartmentMangementMVC.Models.Department { Id = 2, Name = "IT", ManagerName = "Jane Smith" }
            );
            modelBuilder.Entity<DepartmentMangementMVC.Models.Employee>().HasData(
                new DepartmentMangementMVC.Models.Employee { Id = 1, Name = "Alice Johnson", DepartmentId = 1 },
                new DepartmentMangementMVC.Models.Employee { Id = 2, Name = "Bob Williams", DepartmentId = 1 },
                new DepartmentMangementMVC.Models.Employee { Id = 3, Name = "Charlie Brown", DepartmentId = 2 },
                new DepartmentMangementMVC.Models.Employee { Id = 4, Name = "Diana Davis", DepartmentId = 2 }
            );

        }
    }
}
