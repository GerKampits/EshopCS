using AutoMapper;
using EShopApp.DTO;
using EShopApp.Models;

namespace EShopApp.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CustomerCreateDTO, Customer>().ReverseMap();
            CreateMap<CustomerUpdateDTO, Customer>().ReverseMap();
            CreateMap<CustomerReadOnlyDTO, Customer>().ReverseMap();
            CreateMap<OrderCreateDTO, Order>().ReverseMap();
            CreateMap<OrderUpdateDTO, Order>().ReverseMap();
            CreateMap<Order, OrderReadOnlyDTO>().ForMember(q =>
            q.CustomerName, d => d.MapFrom(map =>
            $"{map.Customer!.Firstname} {map.Customer.Lastname}")).ReverseMap();
        }
    }
}
