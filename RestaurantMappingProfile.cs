using AutoMapper;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(d => d.City, r => r.MapFrom(s => s.Address.City))
                .ForMember(d => d.Street, r => r.MapFrom(s => s.Address.Street))
                .ForMember(d => d.PostalCode, r => r.MapFrom(s => s.Address.PostalCode));

            CreateMap<Dish, DishDto>();

            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(d => d.Address,r => r.MapFrom(dto => new Address()
                { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street }));

            CreateMap<UpdateRestaurantDto, Restaurant>()
                .ForMember(r => r.Name, u => u.MapFrom(s => s.Name))
                .ForMember(r => r.Description, u => u.MapFrom(s => s.Description))
                .ForMember(r => r.HasDelivery, u => u.MapFrom(s => s.HasDelivery));
        }
    }
}
