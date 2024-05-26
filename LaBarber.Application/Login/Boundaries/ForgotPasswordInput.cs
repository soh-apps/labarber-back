namespace LaBarber.Application.Login.Boundaries
{
    public class ForgotPasswordInput
    {
        public ForgotPasswordInput()
        {
            Email = string.Empty;
        }
        public string Email { get; set; }
    }
}