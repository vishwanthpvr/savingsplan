using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP3.Models
{
    public partial class Instrument
    {
        public Option option { get; set; }

        public Equity equity { get; set; }
    }
    public partial class Option
    {
        [JsonProperty("assetType")]
        public string assetType { get; set; }

        [JsonProperty("cusip")]
        public string cusip { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("putCall")]
        public string PutCall { get; set; }

        [JsonProperty("underlyingSymbol")]
        public string UnderlyingSymbol { get; set; }

        [JsonProperty("optionMultiplier")]
        public long OptionMultiplier { get; set; }

        [JsonProperty("optionDeliverables")]
        public OptionDeliverable[] OptionDeliverables { get; set; }
    }    
}
