using FoccoEmFrente.Kanban.Api.Models;
using FoccoEmFrente.Kanban.Application.Entities;
using FoccoEmFrente.Kanban.Application.Enums;
using System;

namespace FoccoEmFrente.Kanban.Api.Maps
{
    public class ActivityDtoToActivityProfile : BaseProfile
    {
        public ActivityDtoToActivityProfile()
        {
            CreateMap<ActivityDto, Activity>()
                .ForMember(p => p.Status, Ignore)
                .AfterMap(MapStatus);
        }

        private void MapStatus(ActivityDto activityDto, Activity activity)
        {
            activity.Status = Enum.Parse<ActivityStatus>(activityDto.Status);
        }
    }
}