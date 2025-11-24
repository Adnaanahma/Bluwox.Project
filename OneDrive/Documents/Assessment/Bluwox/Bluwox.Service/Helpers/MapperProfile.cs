using AutoMapper;
using Bluwox.Model.Dtos;
using Bluwox.Model.Entities;
using Bluwox.Model.ViewModels;

namespace Bluwox.Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ServiceManagement, ServiceManagementDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<SubCategory, SubCategoryDto>();
        }
    }
}
