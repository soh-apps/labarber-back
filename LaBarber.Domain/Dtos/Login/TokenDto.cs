namespace LaBarber.Domain.Dtos.Login
{
    public class TokenDto
    {
        public TokenDto()
        {
            Token = string.Empty;
            RefreshToken = string.Empty;
        }

        public TokenDto(string token, string refreshToken)
        {
            Token = token;
            RefreshToken = refreshToken;
        }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}