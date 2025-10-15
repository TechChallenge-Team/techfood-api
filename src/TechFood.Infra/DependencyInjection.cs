using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using TechFood.Application.Categories.Queries;
using TechFood.Application.Common.Services.Interfaces;
using TechFood.Application.Customers.Queries;
using TechFood.Application.Menu.Queries;
using TechFood.Application.Orders.Queries;
using TechFood.Application.Preparations.Queries;
using TechFood.Application.Products.Queries;
using TechFood.Domain.Enums;
using TechFood.Domain.Repositories;
using TechFood.Infra.Payments.MercadoPago;
using TechFood.Infra.Persistence.Contexts;
using TechFood.Infra.Persistence.ImageStorage;
using TechFood.Infra.Persistence.Queries;
using TechFood.Infra.Persistence.Repositories;
using TechFood.Shared.Infra.Extensions;

namespace TechFood.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        //Context
        services.AddSharedInfra<ApiTechFoodContext>(new InfraOptions
        {
            AssemblyLoad = typeof(Application.DependencyInjection).Assembly,
            DbContext = (serviceProvider, options) =>
            {
                var config = serviceProvider.GetRequiredService<IConfiguration>();
                options.UseSqlServer(config.GetConnectionString("DataBaseConection"));
            }
        });

        //Data
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPreparationRepository, PreparationRepository>();

        //Queries
        services.AddScoped<IProductQueryProvider, ProductQueryProvider>();
        services.AddScoped<ICategoryQueryProvider, CategoryQueryProvider>();
        services.AddScoped<ICustomerQueryProvider, CustomerQueryProvider>();
        services.AddScoped<IPreparationQueryProvider, PreparationQueryProvider>();
        services.AddScoped<IMenuQueryProvider, MenuQueryProvider>();
        services.AddScoped<IOrderQueryProvider, OrderQueryProvider>();

        services.AddScoped<IImageStorageService, LocalDiskImageStorageService>();

        // Payments
        services.AddOptions<MercadoPagoOptions>()
            .Configure<IConfiguration>((options, config) =>
            {
                var configSection = config.GetSection(MercadoPagoOptions.SectionName);
                configSection.Bind(options);
            });

        services.AddKeyedTransient<IPaymentService, MercadoPagoPaymentService>(PaymentType.MercadoPago);

        services.AddHttpClient(MercadoPagoOptions.ClientName, (serviceProvider, client) =>
        {
            client.BaseAddress = new Uri(MercadoPagoOptions.BaseAddress);
            client.DefaultRequestHeaders.Add("X-Idempotency-Key", Guid.NewGuid().ToString());

            client.DefaultRequestHeaders.Authorization = new("Bearer", serviceProvider.GetRequiredService<IOptions<MercadoPagoOptions>>().Value.AccessToken);
        });

        return services;
    }
}
