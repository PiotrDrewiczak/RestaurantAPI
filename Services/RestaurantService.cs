using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI.Serices
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantDbContext dbContext;
        private readonly IMapper mapper;

        public RestaurantService(RestaurantDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public RestaurantDto GetById(int id)
        {
            var restaurant = dbContext
            .Restaurants
            .Include(r => r.Address)
            .Include(r => r.Dishes)
            .FirstOrDefault(r => r.Id == id);

            if (restaurant is null)
            {
                return null;
            }

            var result = mapper.Map<RestaurantDto>(restaurant);

            return result;
        }
        public IEnumerable<RestaurantDto> GetAll()
        {
            var restaurants = dbContext
                .Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .ToList();

            var restaurantsDto = mapper.Map<List<RestaurantDto>>(restaurants);

            return restaurantsDto;
        }
        public int Create(CreateRestaurantDto dto)
        {
            var restaurant = mapper.Map<Restaurant>(dto);
            dbContext.Restaurants.Add(restaurant);
            dbContext.SaveChanges();
            return restaurant.Id;
        }
        public bool Delete(int id)
        {
            var restaurant = dbContext.Restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant is null)
            {
                return false;
            }

            dbContext.Restaurants.Remove(restaurant);
            dbContext.SaveChanges();
            return true;
        }
        public bool Update(int id, UpdateRestaurantDto dto)
        {
            var restaurant = dbContext.Restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant is null)
            {
                return false;
            }

            restaurant.Name = dto.Name;
            restaurant.Description = dto.Description;
            restaurant.HasDelivery = dto.HasDelivery;
            dbContext.SaveChanges();


             
            return true;
        }
    }
}
