using RestaurantAPI.Models;
using System.Collections.Generic;

namespace RestaurantAPI
{
    public interface IRestaurantService
    {
        public RestaurantDto GetById(int id);
        public IEnumerable<RestaurantDto> GetAll();
        public int Create(CreateRestaurantDto dto);
        public bool Delete(int id);
        public bool Update(int id, UpdateRestaurantDto dto);

    }
}
