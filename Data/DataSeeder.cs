using AnalyticsDashboard.Models;

namespace AnalyticsDashboard.Data
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // seed user admin
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Username = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123") // pakai BCrypt
                });
                context.SaveChanges();
            }
        }
    }
}
