using FoccoEmFrente.Kanban.Api.Maps.Extensions;
using FoccoEmFrente.Kanban.Application.Repositories.Extensions;
using FoccoEmFrente.Kanban.Application.Services.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace FoccoEmFrente.Kanban.Web
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddApplicationRepositories();
            services.AddApplicationServices();
            services.AddAutoMapperConfiguration();
        }
    }
}