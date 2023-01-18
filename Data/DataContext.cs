using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace server.Data{
    public class DataContext : DbContext{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<WorkOrder>()
                .Property(p => p.Email)
                .HasColumnType("nvarchar(50)");
    modelBuilder.Entity<WorkOrder>()
                .Property(p => p.Status)
                .HasColumnType("nvarchar(20)");
    modelBuilder.Entity<WorkOrder>()
                .Property(p => p.DateReceived)
                .HasColumnType("datetime");
    modelBuilder.Entity<WorkOrder>()
                .Property(p => p.DateAssigned)
                .HasColumnType("datetime");
    modelBuilder.Entity<WorkOrder>()
                .Property(p => p.DateComplete)
                .HasColumnType("datetime");
    modelBuilder.Entity<WorkOrder>()
                .Property(p => p.ContactName)
                .HasColumnType("nvarchar(50)");
    modelBuilder.Entity<WorkOrder>()
                .Property(p => p.TechnicianComments)
                .HasColumnType("nvarchar(MAX)");
    modelBuilder.Entity<WorkOrder>()
                .Property(p => p.ContactNumber)
                .HasColumnType("nvarchar(25)");
    modelBuilder.Entity<WorkOrder>()
                .Property(p => p.TechnicianID)
                .HasColumnType("int");
    modelBuilder.Entity<WorkOrder>()
                .Property(p => p.Problem)
                .HasColumnType("nvarchar(MAX)");
    modelBuilder.Entity<WorkOrder>()
                .HasOne(e => e.Technician)
                .WithMany(d => d.WorkOrders)
                .HasForeignKey(e => e.TechnicianID);
    modelBuilder.Entity<Technician>()
                .Property(p => p.TechnicianName)
                .HasColumnType("nvarchar(30)");
    modelBuilder.Entity<Technician>()
                .Property(p => p.TechnicianEmail)
                .HasColumnType("nvarchar(50)");

}
// Data context for the info in DB 
        public DbSet<WorkOrder> WorkOrders => Set<WorkOrder>();
        public DbSet<Technician> Technicians => Set<Technician>();
    }
}