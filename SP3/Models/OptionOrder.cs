using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP3.Models
{
    public partial class OptionOrder
    {
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
        public OptionOrderLegCollection[] OrderLegCollection { get; set; }

        [JsonProperty("childOrderStrategies")]
        public ChildOrderStrategies[] ChildOrderStrategies { get; set; }

        [JsonProperty("complexOrderStrategyType")]
        public string ComplexOrderStrategyType { get; set; }
    }

    public partial class OptionOrderLegCollection
    {
        [JsonProperty("instruction")]
        public string Instruction { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("instrument")]
        public OptionInstrument Instrument { get; set; }
    }

    public partial class OptionInstrument
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("assetType")]
        public string AssetType { get; set; }
    }

    public partial class ChildOrderStrategies
    {
        [JsonProperty("orderStrategyType")]
        public string OrderStrategyType { get; set; }

        [JsonProperty("childOrderStrategies")]
        public ChildOrderStrategy[] ChildOrderStrategiees { get; set; }
    }

    public partial class ChildOrderStrategy
    {
        [JsonProperty("orderStrategyType")]
        public string OrderStrategyType { get; set; }

        [JsonProperty("session")]
        public string Session { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("orderType")]
        public string OrderType { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public double? Price { get; set; }

        [JsonProperty("orderLegCollection")]
        public OrderLegCollection[] OrderLegCollection { get; set; }

        [JsonProperty("stopPrice", NullValueHandling = NullValueHandling.Ignore)]
        public double? StopPrice { get; set; }

        [JsonProperty("limitPrice", NullValueHandling = NullValueHandling.Ignore)]
        public double? LimitPrice { get; set; }
    }

    public partial class OrderLegCollection
    {
        [JsonProperty("instruction")]
        public string Instruction { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("instrument")]
        public OptionInstrument Instrument { get; set; }

    }
    public partial class OptionDeliverable
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("deliverableUnits")]
        public long DeliverableUnits { get; set; }

        [JsonProperty("currencyType")]
        public string CurrencyType { get; set; }

        [JsonProperty("assetType")]
        public string AssetType { get; set; }
    }
}
