namespace Griedy.Lib.Models
{
    public class Config
    {
        public string AADInstance { get; set; }
        public string Tenant { get; set; }
        public string Audience { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public string OnPremisesGatewayClientId { get; set; }
        public string OnPremisesGatewayUrl { get; set; }
    }
}
