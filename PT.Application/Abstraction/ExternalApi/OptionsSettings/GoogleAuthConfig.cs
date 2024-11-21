using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Abstraction.ExternalApi.OptionsSettings
{
    public class GoogleAuthConfig
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string Endpoint { get; set; }
        public string ClientName { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
