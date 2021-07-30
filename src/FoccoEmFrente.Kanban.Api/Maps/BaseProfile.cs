using AutoMapper;

namespace FoccoEmFrente.Kanban.Api.Maps
{
    public abstract class BaseProfile : Profile
    {
        protected void Ignore<TSource, TDestination, TMember>(IMemberConfigurationExpression<TSource, TDestination, TMember> memberConfig)
        {
            memberConfig.Ignore();
        }
    }
}