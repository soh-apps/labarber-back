namespace LaBarber.Domain.Dtos.Login
{
    public class LoginDto
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public int UserId { get; set; }
        public LoginDto()
        {
            Name = string.Empty;
            Role = string.Empty;
            UserId = 0;
        }

        public LoginDto(string name, string role, int userId)
        {
            Name = name;
            Role = role;
            UserId = userId;
        }
    }
}
