using AutoMapper;
using Shoplify.Models;
using Shoplify.Models.DTOs;

namespace Shoplify.Mapping.AutomapperProfiles
{
    public class ProductsMappingProfiles : Profile
    {
        public ProductsMappingProfiles()
        {
            CreateMap<Product, Products>();
        }
    }
}
