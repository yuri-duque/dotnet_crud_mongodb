using Api.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Api.IoT
{
    public class AutomapperIot : Profile
    {
        public AutomapperIot()
        {
            CreateMap<ProductInsertViewModel, Product>();
            CreateMap<ProductUpdateViewModel, Product>();
            CreateMap<Product, ProductListViewModel>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}
