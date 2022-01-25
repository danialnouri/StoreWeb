using AutoMapper;
using Store.Data;
using Store.Models;

namespace Store.Mapping
{
    public class Maps: Profile
    {
        public Maps()
        {
            CreateMap<Kala, DetailKalaViewModel>().ReverseMap();
            CreateMap<Kala, CreateKalaViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<OrderApp, OrderAppViewModel>().ReverseMap();
            
        }
        
    }
}