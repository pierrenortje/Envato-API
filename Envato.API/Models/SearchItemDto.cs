using RestSharp.Deserializers;

namespace Envato.API.Models
{
    public class SearchItemDto
    {
        [DeserializeAs(Name = "took")]
        public int Took { get; set; }
    }
}
