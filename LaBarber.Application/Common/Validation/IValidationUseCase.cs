namespace LaBarber.Application.Common.Validation
{
    public interface IValidationUseCase 
    {
        Task<int> ChecksRealBarberUnitId(int userId, int barberUnitId, string role);
        Task<bool> UserHasPermissionOnBarberUnit(int userId, int barberUnitId, string role);
    }
}