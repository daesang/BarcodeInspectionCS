using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeInspection.Models
{
    public class LoginUser
    {
        public LoginUser()
        {

        }

        [JsonProperty("compky")]
        public string Compky { get; set; }

        [JsonProperty("compnm")]
        public string Compnm { get; set; }

        [JsonProperty("wareky")]
        public string Wareky { get; set; }

        [JsonProperty("warenm")]
        public string Warenm { get; set; }

        [JsonProperty("userid")]
        public string Userid { get; set; }

        [JsonProperty("passwd")]
        public string Passwd { get; set; }

        [JsonProperty("auth_token")]
        public string AuthToken { get; set; }

    }
}
