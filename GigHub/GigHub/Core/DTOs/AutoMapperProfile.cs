using AutoMapper;
using GigHub.Core.Models;

namespace GigHub.Core.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Gig, GigDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}