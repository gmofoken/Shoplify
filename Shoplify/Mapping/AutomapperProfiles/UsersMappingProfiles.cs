using AutoMapper;
using Shoplify.Models;
using Shoplify.Models.DTOs;

namespace Shoplify.Mapping.AutomapperProfiles
{
    public class UsersMappingProfiles : Profile
    {
        public UsersMappingProfiles()
        {
            CreateMap<User, Users>();
        }
    }
}
