using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace server.Data{
    public class DataContext : DbContext{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<WorkOrder> WorkOrders => Set<WorkOrder>();
        public DbSet<Technician> Technicians => Set<Technician>();

        
    }
}