using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProvaPub.Application.Interfaces;
using ProvaPub.Application.Services;
using ProvaPub.Infra.Data.Context;
using ProvaPub.Infra.Data.Repositories;

namespace ProvaPub.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddScoped<CategoriaService>();
            services.AddScoped<PessoaService>();
            services.AddScoped<TransacaoService>();

            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();



            services.AddDbContext<TestDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ctx"), b => b.MigrationsAssembly("ProvaPub.Infra.Data")));

            return services;
        }
    }
}
