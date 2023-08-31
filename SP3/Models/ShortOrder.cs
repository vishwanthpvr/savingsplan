using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP3.Models
{
    public partial class ShortOrder
    {
        [JsonProperty("complexOrderStrategyType")]
        public string ComplexOrderStrategyType { get; set; }

        [JsonProperty("orderType")]
        public string OrderType { get; set; }

        [JsonProperty("session")]
        public string Session { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("orderStrategyType")]
        public string OrderStrategyType { get; set; }

        [JsonProperty("orderLegCollection")]
        public ShortOrderLegCollection[] OrderLegCollection { get; set; }
    }

    public partial class ShortOrderLegCollection
    {
        [JsonProperty("instruction")]
        public string Instruction { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("instrument")]
        public ShortInstrument Instrument { get; set; }
    }

    public partial class ShortInstrument
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("assetType")]
        public string AssetType { get; set; }
    }
}
