using Microsoft.Extensions.DependencyInjection;
using ProductBoundedContext.Data.Context;
using ProductBoundedContext.Data.Repositories;
using ProductBoundedContext.Domain.IRepositories;
using ProductBoundedContext.Domain.UseCases.Implementations;
using ProductBoundedContext.Domain.UseCases.Interfaces;

namespace ProductBoundedContext.Dependencies
{
    public class RegisterDependencies
    {
        public static void RegisterData(IServiceCollection services, string connectionString)
        {
            //Singleton
            //Instancia uma única vez a classe.
            services.AddSingleton<ProductSqlDataContext>(new ProductSqlDataContext(connectionString));

            //Scoped
            //Instancia a classe por demanda.
            services.AddScoped<IProductRepository, ProductRepository>(); // IProductRepository x = new ProductRepository(null);
            //A injeção de dependeência é sempre a interface com a classe que está sendo a mesma implementada.
        }

        public static void RegisterDomain(IServiceCollection services)
        {
            //Scoped
            services.AddScoped<ICreateProduct, CreateProduct>();
        }
    }
}