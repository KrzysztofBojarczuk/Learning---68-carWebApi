using AutoMapper;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1
{
    public class CarMappingProfiles : Profile
    {
        public CarMappingProfiles()
        {
            CreateMap<CarCreateDto, Car>();
            CreateMap<Car, CarGetDto>();
        }
    }
}
