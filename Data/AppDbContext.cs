using Microsoft.EntityFrameworkCore;
using AnalyticsDashboard.Models;

namespace AnalyticsDashboard.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TrafficLog> TrafficLogs { get; set; }
        public DbSet<User> Users { get; set; }  // 👈 Tambahkan ini
    }

    public class TrafficLog
    {
        public int Id { get; set; }
        public string SourceDomain { get; set; } = "";
        public int LocalIPs { get; set; }
        public int OtherIPs { get; set; }
        public int TotalClicks { get; set; }
        public int UniqueClicks { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
