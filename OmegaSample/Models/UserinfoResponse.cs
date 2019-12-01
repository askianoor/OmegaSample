using AspNet.Security.OpenIdConnect.Primitives;
using Newtonsoft.Json;
using System;

namespace OmegaSample.Models
{
    public class UserinfoResponse : Resource
    {
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = OpenIdConnectConstants.Claims.Subject)]
        public string Subject { get; set; }

        [JsonProperty(PropertyName = OpenIdConnectConstants.Claims.GivenName)]
        public string GivenName { get; set; }

        [JsonProperty(PropertyName = OpenIdConnectConstants.Claims.FamilyName)]
        public string FamilyName { get; set; }
    }
}
