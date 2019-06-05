using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeInspection.Models
{
    public class DlwrkyModel
    {
        [JsonProperty("dlwrky")]
        public string Dlwrky { get; set; }
        [JsonProperty("dlwrnm")]
        public string Dlwrnm { get; set; }
    }
}
