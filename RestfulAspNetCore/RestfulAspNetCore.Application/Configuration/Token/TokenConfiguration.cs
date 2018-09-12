namespace RestfulAspNetCore.Application.Configuration.Token
{
    public class TokenConfiguration
    {
        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
