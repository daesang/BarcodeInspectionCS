using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeInspection.Models
{
    public class WarehouseModel
    {
        [JsonProperty("wareky")]
        public string Wareky { get; set; }

        [JsonProperty("warenm")]
        public string Warenm { get; set; }
    }
}
