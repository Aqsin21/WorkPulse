using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace WorkPulse.DAL.DataContext
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // 1. DAL projesinin bin dizininden başla
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

            // 2. API projesine git (solution yapısına göre 3-4 üst klasör)
            var apiProjectPath = Path.GetFullPath(Path.Combine(basePath, "..", "..", "..", "..", "WorkPulse.API"));
            apiProjectPath = Path.GetFullPath(apiProjectPath); // Normalize

            // 3. Configuration oluştur
            var configuration = new ConfigurationBuilder()
                .SetBasePath(apiProjectPath)
                .AddJsonFile("appsettings.json", optional: false) // Zorunlu
                .AddJsonFile("appsettings.Development.json", optional: true) // Sadece dev'de
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException($"Connection string 'DefaultConnection' not found in {apiProjectPath}");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // Log için (isteğe bağlı)
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}