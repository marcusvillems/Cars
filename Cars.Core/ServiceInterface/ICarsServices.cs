using Cars.Core.Domain;
using Cars.Core.Dto;

namespace Cars.Core.ServiceInterface
{
    public interface ICarsServices
    {
        Task<Car> Create(CarDto dto);
        Task<Car> Update(CarDto dto);
        Task<Car> Delete(Guid id);
        Task<Car> DetailsAsync(Guid id);
    }
}
