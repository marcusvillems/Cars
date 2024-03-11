using Cars.Core.Domain;
using Cars.Core.Dto;
using Cars.Core.ServiceInterface;
using Microsoft.EntityFrameworkCore;
using Cars.Data;

namespace Cars.ApplicationService.Services
{
    public class CarsServices : ICarsServices
    {
        private readonly CarsContext _context;

        public CarsServices(CarsContext context)
        {
            _context = context;
        }

        public async Task<Car> Create(CarDto dto)
        {
            Car car = new();

            car.Id = Guid.NewGuid();
            car.Make = dto.Make;
            car.Model = dto.Model;
            car.Color = dto.Color;
            car.Year = dto.Year;
            car.Transmission = dto.Transmission.ToString();
            car.Power = dto.Power;
            car.Fuel = dto.Fuel.ToString();
            car.Drivetrain = dto.Drivetrain.ToString();

            car.CreatedAt = DateTime.Now;
            car.UpdatedAt = DateTime.Now;

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }


        public async Task<Car> Update(CarDto dto)
        {
            Car domain = new();

            domain.Id = dto.Id;
            domain.Make = dto.Make;
            domain.Model = dto.Model;
            domain.Color = dto.Color;
            domain.Year = dto.Year;
            domain.Transmission = dto.Transmission.ToString();
            domain.Power = dto.Power;
            domain.Fuel = dto.Fuel.ToString();
            domain.Drivetrain = dto.Drivetrain.ToString();
            domain.CreatedAt = DateTime.Now;
            domain.UpdatedAt = DateTime.Now;


            _context.Cars.Update(domain);
            await _context.SaveChangesAsync();
            return domain;

        }

        public async Task<Car> DetailsAsync(Guid Id)
        {
            var result = await _context.Cars.FirstOrDefaultAsync(x => x.Id == Id);
            return result;
        }

        public async Task<Car> Delete(Guid Id)
        {
            var id = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == Id);

            _context.Cars.Remove(id);
            await _context.SaveChangesAsync();

            return id;
        }
    }
}
