using ErrorLoggingMiddleware__real_world_scenario.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ErrorLoggingMiddleware__real_world_scenario
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}
