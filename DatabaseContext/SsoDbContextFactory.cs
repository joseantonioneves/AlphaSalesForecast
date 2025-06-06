using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DatabaseContext
{
    public class SsoDbContextFactory : IDesignTimeDbContextFactory<SsoDbContext>
    {
        // Configurar o DBContext
        public SsoDbContext CreateDbContext(string[] args)
        {
            // Configurar o IConfigurationBuilder
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            // Criar a Instancia do IConfiguration
            IConfiguration configuration = builder.Build();

            // Obter a string de conexão
            string connectionString = configuration.GetConnectionString("Desenvolvimento")!;
            var optionsBuilder = new DbContextOptionsBuilder<SsoDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-TAFAH9C;Database=AlphaSSODb;Trusted_Connection=True;TrustServerCertificate=true;");

            return new SsoDbContext(optionsBuilder.Options);
        }
    }
}