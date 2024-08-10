using LaBarber.Domain.Dtos.Service;

namespace LaBarber.Domain.Entities.Service
{
    public interface IServiceRepository 
    {
        Task CreateService(ServiceDto dto);
        Task UpdateService(ServiceDto dto);
        Task<ServiceDto> GetServiceById(int id);
        Task<bool> ServiceExists(int id);
        Task<List<ServiceDto>> ListServicesByBarberUnit(int barberUnitId);
        Task DeleteServiceById(int id);
    }
}