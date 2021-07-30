using FoccoEmFrente.Kanban.Api.Models;
using FoccoEmFrente.Kanban.Application.Entities;
using FoccoEmFrente.Kanban.Application.Enums;
using System;

namespace FoccoEmFrente.Kanban.Api.Maps
{
    public class ActivityToActivityDtoProfile : BaseProfile
    {
        public ActivityToActivityDtoProfile()
        {
            CreateMap<Activity, ActivityDto>()
                .ForMember(p => p.Status, Ignore)
                .AfterMap(MapStatus);
        }

        private void MapStatus(Activity activity, ActivityDto activityDto)
        {
            activityDto.Status = Enum.GetName(typeof(ActivityStatus), activity.Status);
        }
    }
}