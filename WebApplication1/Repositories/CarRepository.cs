using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _ctx;

        public CarRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Car> CreateCarAsync(Car car)
        {
            _ctx.CarsEntity.Add(car);
            await _ctx.SaveChangesAsync();
            return car;
        }

        public async Task<Car> DeleteCarAsync(int id)
        {
            var car = await _ctx.CarsEntity.SingleOrDefaultAsync(x => x.CarId == id);
            if (car is null)
            {
                return null;
            }
            _ctx.CarsEntity.Remove(car);
            await _ctx.SaveChangesAsync();
            return car;
        }

        public async Task<List<Car>> GetAllCarAsync()
        {
            return await _ctx.CarsEntity.ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            var car = await _ctx.CarsEntity.FirstOrDefaultAsync(h => h.CarId == id);
            if (car is null)
            {
                return null;
            }
            return car;
        }

        public async Task<Car> UpdateTodoAsync(Car updateCar)
        {
            _ctx.CarsEntity.Update(updateCar);
            await _ctx.SaveChangesAsync();
            return updateCar;   
        }
    }
}
