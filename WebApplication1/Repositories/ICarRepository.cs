using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllCarAsync();
        Task<Car> GetCarByIdAsync(int id);
        Task<Car> CreateCarAsync(Car car);
        Task<Car> UpdateTodoAsync(Car updateCar);
        Task<Car> DeleteCarAsync(int id);
    }
}
