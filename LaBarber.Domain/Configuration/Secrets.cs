namespace LaBarber.Domain.Configuration
{
    public class Secrets
    {
        public string ConnectionString { get; set; }
        public string PreSalt { get; set; }
        public string PosSalt { get; set; }
        public string ClientSecret { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public string SendGridApiKey { get; set; }
        public Secrets()
        {
            ConnectionString = string.Empty;
            PreSalt = string.Empty;
            PosSalt = string.Empty;
            ClientSecret = string.Empty;
            FromAddress = string.Empty;
            FromName = string.Empty;
            SendGridApiKey = string.Empty;
        }
    }
}
