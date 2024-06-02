namespace LaBarber.Application.Login.Boundaries
{
    public class RefreshTokenInput
    {
        public int CredentialId { get; set; } = 0;
        public string RefreshToken { get; set; } = "";
    }
}