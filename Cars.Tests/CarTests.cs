using Cars.Core.Dto;
using Cars.Core.ServiceInterface;

namespace Cars.Tests
{
    public class CarTests : TestBase 
    {
        [Fact]
        public async Task DONOT_AddEmptyCar_WhenReturnResult()
        {

            CarDto car = new();
            {
                car.Id = null;
                car.Make = "Nissan";
                car.Model = "GTR";
                car.Color = "gray";
                car.Year = DateTime.Now.Year - 25;
                car.Power = "400";
                car.Transmission = TransmissionType.Manual;
                car.Drivetrain = "RWD";
                car.Fuel = "Diesel";
                car.CreatedAt = DateTime.Now;
                car.UpdatedAt = DateTime.Now;
            };


            var result = await Svc<ICarsServices>().Create(car);


            Assert.NotNull(result);
        }



        [Fact]
        public async Task UpdateCar_WhenUpdateData()
        {
            CarDto dto = MockCarData();
            var createCar = await Svc<ICarsServices>().Create(dto);

            CarDto update = MockUpdateCarData();
            var result = await Svc<ICarsServices>().Update(update);

            Assert.DoesNotMatch(result.Make, createCar.Make);
            Assert.NotEqual(result.UpdatedAt, createCar.UpdatedAt);
            Assert.NotEqual(result.Model, createCar.Model);
        }

        [Fact]
        public async Task GetByCarId_WhenReturnsEqual()
        {
            Guid databaseGuid = Guid.Parse("ce7b3b9e-91d9-4a7b-b168-f3a9f3e1d85f");
            Guid guid = Guid.Parse("ce7b3b9e-91d9-4a7b-b168-f3a9f3e1d85f");

            await Svc<ICarsServices>().DetailsAsync(guid);

            Assert.Equal(databaseGuid, guid);
        }
        [Fact]
        public async Task DONOT_UpdateCar_WhenNotUpdateData()
        {
            CarDto dto = MockCarData();
            var createRealestate = await Svc<ICarsServices>().Create(dto);

            CarDto nullUpdate = MockNullCar();
            var result = await Svc<ICarsServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;

            Assert.True(dto.Id == nullId);
        }
        private CarDto MockCarData()
        {
            CarDto car = new()
            {
                Id = null,
                Make = "Ford",
                Model = "F-150",
                Color = "Blue",
                Year = DateTime.Now.Year - 25,
                Power = "335",
                Transmission = TransmissionType.Manual,
                Drivetrain = "AWD",
                Fuel = "Diesel",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            return car;
        }

        private CarDto MockUpdateCarData()
        {
            CarDto car = new()
            {
                Id = null,
                Make = "Nissan",
                Model = "GTR",
                Color = "gray",
                Year = DateTime.Now.Year - 25,
                Power = "400",
                Transmission = TransmissionType.Manual,
                Drivetrain = "AWD",
                Fuel = "Petrol",
                CreatedAt = DateTime.Now.AddYears(1),
                UpdatedAt = DateTime.Now.AddDays(+3),
            };

            return car;
        }
        private CarDto MockNullCar()
        {
            CarDto nullDto = new()
            {
                Id = null,
                Make = "Subaru",
                Model = "Impreza",
                Color = "blue",
                Year = DateTime.Now.Year - 20,
                Power = "225",
                Transmission = TransmissionType.Automatic,
                Drivetrain = "AWD",
                Fuel = "Diesel",
                CreatedAt = DateTime.Now.AddMonths(6),
                UpdatedAt = DateTime.Now.AddDays(+5),

            };

            return nullDto;
        }

    }
}