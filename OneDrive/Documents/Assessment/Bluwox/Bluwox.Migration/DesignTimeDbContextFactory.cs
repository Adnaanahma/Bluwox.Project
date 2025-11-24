using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Bluwox.Migrations
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            using JsonDocument jsonDocument = JsonDocument.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}\\config.json"));
            string connectionString = jsonDocument.RootElement.GetProperty("ConnectionStrings").GetProperty("DefaultConnection").GetString()!;
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}
