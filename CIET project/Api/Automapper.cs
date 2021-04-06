using Api.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Api.IoT
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ProductInsertViewModel, Product>();
            CreateMap<ProductUpdateViewModel, Product>();
            CreateMap<Product, ProductListViewModel>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}
