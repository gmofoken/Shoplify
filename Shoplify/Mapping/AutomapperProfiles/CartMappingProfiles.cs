using AutoMapper;
using Shoplify.Models.DTOs;
using Shoplify.Models;

namespace Shoplify.Mapping.AutomapperProfiles
{
    public class CartMappingProfiles : Profile
    {
        public CartMappingProfiles()
        {
            CreateMap<Models.Item, Models.DTOs.Item>();
        }
    }
}
