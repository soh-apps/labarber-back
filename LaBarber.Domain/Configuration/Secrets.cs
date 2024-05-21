namespace LaBarber.Domain.Configuration
{
    public class Secrets
    {
        public string ConnectionString { get; set; }
        public Secrets()
        {
            ConnectionString = string.Empty;
        }
    }
}
