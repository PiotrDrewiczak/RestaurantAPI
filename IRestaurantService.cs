using RestaurantAPI.Models;
using System.Collections.Generic;

namespace RestaurantAPI
{
    public interface IRestaurantService
    {
        public RestaurantDto GetById(int id);
        public IEnumerable<RestaurantDto> GetAll();
        public int Create(CreateRestaurantDto dto);
        public void Delete(int id);
        public void Update(int id, UpdateRestaurantDto dto);
    }
}
