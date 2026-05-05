using Microsoft.EntityFrameworkCore;

namespace TestApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<WeatherForecast> Forecasts { get; set; }
    }
}
