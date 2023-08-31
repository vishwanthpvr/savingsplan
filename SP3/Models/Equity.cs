using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP3.Models
{
    public partial class Equity
    {
        [JsonProperty("assetType")]
        public string AssetType { get; set; }

        [JsonProperty("cusip")]
        public string Cusip { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
