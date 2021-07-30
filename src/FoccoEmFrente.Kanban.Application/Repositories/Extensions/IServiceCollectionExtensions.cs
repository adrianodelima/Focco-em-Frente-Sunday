using FoccoEmFrente.Kanban.Application.Repositories.Atividade2Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoccoEmFrente.Kanban.Application.Repositories.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IFunctionaryRepository, FunctionaryRepository>();
        }
    }
}
