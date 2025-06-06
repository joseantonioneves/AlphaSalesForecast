
using Repositories;
using DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace WebAPIRequest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // referencia a outros projetos e tomada da string de conexão
            builder.Services.AddDbContext<SsoDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Desenvolvimento")));
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<UserLoginRepository>();
            builder.Services.AddScoped<OrganizationRepository>();
            builder.Services.AddScoped<RoleRepository>();
            builder.Services.AddScoped<EnrollmentRepository>();
            builder.Services.AddScoped<SignatureRepository>();
            // Adicionar os serviços para o container.

            builder.Services.AddControllers();
            // Saiba mais sobre configuração Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // PUT YOUR CODE HERE: Middleware e Roteamento neste ponto:
            // --------------------------------------------------------
            // remover esta linha de comentário e inserir código aqui.
            // --------------------------------------------------------

            app.MapControllers();

            app.Run();
        }
    }
}