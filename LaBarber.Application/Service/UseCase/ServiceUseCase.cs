using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.Service;
using LaBarber.Domain.Entities.Service;

namespace LaBarber.Application.Service.UseCase
{
    public class ServiceUseCase : IServiceUseCase
    {
        private readonly IServiceRepository _repository;
        private readonly IMediatorHandler _handler;

        public ServiceUseCase(IServiceRepository repository, IMediatorHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        public async Task CreateService(ServiceDto dto)
        {
            await _repository.CreateService(dto);
        }

        public async Task<ServiceDto> GetServiceById(int id)
        {
            return await _repository.GetServiceById(id);
        }

        public async Task UpdateService(ServiceDto dto)
        {
            var exists = await _repository.ServiceExists(dto.Id);
            if (exists)
            {
                await _repository.UpdateService(dto);
            }
            else
            {
                await _handler.PublishNotification(new DomainNotification("Service", "serviço não encontrado"));
            }
        }
    }
}