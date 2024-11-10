using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            string apiProjectPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "API");

            if (string.IsNullOrEmpty(apiProjectPath))
            {
                throw new InvalidOperationException("API_PROJECT_PATH environment variable not set.");
            }

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(apiProjectPath) 
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlite(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
