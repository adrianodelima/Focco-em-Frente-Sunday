using Microsoft.Extensions.DependencyInjection;
using System;

namespace FoccoEmFrente.Kanban.Api.Maps.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ActivityToActivityDtoProfile());
                cfg.AddProfile(new ActivityDtoToActivityProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}   