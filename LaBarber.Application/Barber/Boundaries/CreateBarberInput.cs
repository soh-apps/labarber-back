using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.Application.Barber.Boundaries
{
    public class CreateBarberInput : BarberInput
    {
        [SwaggerSchema(
            Title = "Username",
            Description = "Nome de usuário do barbeiro a ser criado",
            Format = "string")]
        public string Username { get; set; } = string.Empty;

        [SwaggerSchema(
            Title = "Email",
            Description = "E-mail do barbeiro a ser criado",
            Format = "string")]
        public string Email { get; set; } = string.Empty;

        [SwaggerSchema(
            Title = "Password",
            Description = "Senha para criação do usuário barbeiro",
            Format = "string")]
        public string Password { get; set; } = string.Empty;
    }
}
