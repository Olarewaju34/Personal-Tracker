using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PT.Application.Abstraction.ExternalApi
{
    public class GoogleUserModel
    {
        [JsonProperty("given_name")]
        public string GivenName { get; set; }
        [JsonProperty("family_name")]
        public string FamilyName { get; set; }
        public string Email { get; set; }
        [JsonProperty("email_verified")]
        public bool IsEmailConfirmed { get; set; }
    }
}
