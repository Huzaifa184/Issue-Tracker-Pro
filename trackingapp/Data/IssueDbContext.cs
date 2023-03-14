using Microsoft.EntityFrameworkCore;
using trackingapp.Models;

namespace trackingapp.Data
{
    public class IssueDbContext : DbContext
    {
        public DbSet<Issue> Issues { get; set; }

        public IssueDbContext(DbContextOptions<IssueDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Set the database provider and connection string
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\DELL\\source\\repos\\trackingapp\\trackingapp\\Data\\Database\\Issue.db");
        }
    }
}
