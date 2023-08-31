using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP3.Models
{
    public partial class OrderActivity
    {
        public Execution Execution { get; set; }
    }
    public partial class Execution
    {
        [JsonProperty("activityType")]
        public string ActivityType { get; set; }

        [JsonProperty("executionType")]
        public string ExecutionType { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("orderRemainingQuantity")]
        public long OrderRemainingQuantity { get; set; }

        [JsonProperty("executionLegs")]
        public ExecutionLeg[] ExecutionLegs { get; set; }
    }

    public partial class ExecutionLeg
    {
        [JsonProperty("legId")]
        public long LegId { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("mismarkedQuantity")]
        public long MismarkedQuantity { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
