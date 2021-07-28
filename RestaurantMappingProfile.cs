﻿using AutoMapper;
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

        }
    }
}
