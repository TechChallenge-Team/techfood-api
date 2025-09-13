using Microsoft.Extensions.DependencyInjection;
using TechFood.Application.Common.Services;
using TechFood.Application.Common.Services.Interfaces;

namespace TechFood.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //Services
        services.AddTransient<IEmailSender, EmailSender>();

        services.AddSingleton<IOrderNumberService, OrderNumberService>();
        services.AddTransient<IImageUrlResolver, ImageUrlResolver>();

        return services;
    }
}
