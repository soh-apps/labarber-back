using LaBarber.Domain.Dtos.Service;

namespace LaBarber.Application.Service.UseCase
{
    public interface IServiceUseCase
    {
        Task CreateService(ServiceDto dto);
        Task UpdateService(ServiceDto dto);
        Task<ServiceDto> GetServiceById(int id);
        Task<List<ServiceDto>> GetServicesByBarberUnit(int barberUnitId);
    }
}