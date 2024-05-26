namespace LaBarber.Application.Login.Boundaries
{
    public class RecoverPasswordInput
    {
        public string Code { get; set; }
        public string Password { get; set; }

        public RecoverPasswordInput()
        {
            Code = string.Empty;
            Password = string.Empty;
        }
    }
}