
namespace Cars.Models.Car
{
    public class CarsIndexViewModel
    {
        public Guid? Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public string Drivetrain { get; set; }
        public string Fuel { get; set; }
    }
}
