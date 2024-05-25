namespace LaBarber.Domain.Configuration
{
    public class Secrets
    {
        public string ConnectionString { get; set; }
        public string PreSalt { get; set; }
        public string PosSalt { get; set; }
        public string ClientSecret { get; set; }
        public Secrets()
        {
            ConnectionString = string.Empty;
            PreSalt = string.Empty;
            PosSalt = string.Empty;
            ClientSecret = string.Empty;
        }
    }
}
