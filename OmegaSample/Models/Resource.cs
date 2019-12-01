using Newtonsoft.Json;

namespace OmegaSample.Models
{
    public abstract class Resource : Link
    {
        [JsonIgnore]
        public Link Self { get; set; }
    }
}
