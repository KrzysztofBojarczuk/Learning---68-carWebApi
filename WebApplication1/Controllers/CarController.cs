using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Dtos;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepo;
        private readonly IMapper _mapper;

        public CarController(ICarRepository carRepo, IMapper mapper)
        {
            _carRepo = carRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCar()
        {
            var car = await _carRepo.GetAllCarAsync();
            var carGet = _mapper.Map<List<CarGetDto>>(car);
            return Ok(carGet);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetCarByID(int id)
        {
            var car = await _carRepo.GetCarByIdAsync(id);
            if (car is null)
            {
                return NotFound();
            }
            var carGet = _mapper.Map<CarGetDto>(car);
            return Ok(carGet);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> CreateCar([FromBody] CarCreateDto car)
        {
            var domainCar = _mapper.Map<Car>(car);
            await _carRepo.CreateCarAsync(domainCar);
            var carGet = _mapper.Map<CarGetDto>(domainCar);
            return CreatedAtAction(nameof(GetCarByID), new { id = domainCar.CarId }, carGet);

        }
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> UpdateCar([FromBody] CarCreateDto updateCar ,int id )
        {
            var toUpdate = _mapper.Map<Car>(updateCar);
            toUpdate.CarId = id;
            await _carRepo.UpdateTodoAsync(toUpdate);
            return NoContent();
        }
        [HttpGet("Dlete/{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _carRepo.DeleteCarAsync(id);
            if (car is null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
