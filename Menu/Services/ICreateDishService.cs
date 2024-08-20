using Menu.Models;

namespace Menu.Services
{
    public interface ICreateDishService
    {
        Task<bool> CreateDish(DishDTO dishDTO);
    }
}