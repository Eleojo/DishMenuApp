using Menu.Models;

namespace Menu.Services
{
    public interface IDishCreationService
    {
        Task<bool> CreateDishAsync(DishDTO dishDTO);
    }
}