using RestSharp.Deserializers;

namespace Envato.API.Models
{
    public class TokenResponse
    {
        [DeserializeAs(Name = "refresh_token")]
        public string RefreshToken { get; set; }

        [DeserializeAs(Name = "token_type")]
        public string TokenType { get; set; }

        [DeserializeAs(Name = "access_token")]
        public string AccessToken { get; set; }

        [DeserializeAs(Name = "expires_in")]
        public int ExpiresIn { get; set; }
    }
}
