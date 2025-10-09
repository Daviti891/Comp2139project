using Microsoft.EntityFrameworkCore;
using Comp2139Project.Models;

namespace Comp2139Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
    }
}