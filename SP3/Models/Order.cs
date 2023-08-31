using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP3.Models
{
    public partial class Order
    {
        [JsonProperty("session")]
        public string Session { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("orderType")]
        public string OrderType { get; set; }

        [JsonProperty("cancelTime")]
        public CancelTime CancelTime { get; set; }

        [JsonProperty("complexOrderStrategyType")]
        public string ComplexOrderStrategyType { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("filledQuantity")]
        public long FilledQuantity { get; set; }

        [JsonProperty("remainingQuantity")]
        public long RemainingQuantity { get; set; }

        [JsonProperty("requestedDestination")]
        public string RequestedDestination { get; set; }

        [JsonProperty("destinationLinkName")]
        public string DestinationLinkName { get; set; }

        [JsonProperty("releaseTime")]
        public string ReleaseTime { get; set; }

        [JsonProperty("stopPrice")]
        public long StopPrice { get; set; }

        [JsonProperty("stopPriceLinkBasis")]
        public string StopPriceLinkBasis { get; set; }

        [JsonProperty("stopPriceLinkType")]
        public string StopPriceLinkType { get; set; }

        [JsonProperty("stopPriceOffset")]
        public long StopPriceOffset { get; set; }

        [JsonProperty("stopType")]
        public string StopType { get; set; }

        [JsonProperty("priceLinkBasis")]
        public string PriceLinkBasis { get; set; }

        [JsonProperty("priceLinkType")]
        public string PriceLinkType { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("taxLotMethod")]
        public string TaxLotMethod { get; set; }

        [JsonProperty("orderLegCollection")]
        public OrderLegCollection[] OrderLegCollection { get; set; }

        [JsonProperty("activationPrice")]
        public long ActivationPrice { get; set; }

        [JsonProperty("specialInstruction")]
        public string SpecialInstruction { get; set; }

        [JsonProperty("orderStrategyType")]
        public string OrderStrategyType { get; set; }

        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("cancelable")]
        public bool Cancelable { get; set; }

        [JsonProperty("editable")]
        public bool Editable { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("enteredTime")]
        public string EnteredTime { get; set; }

        [JsonProperty("closeTime")]
        public string CloseTime { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("accountId")]
        public long AccountId { get; set; }

        [JsonProperty("orderActivityCollection")]
        public OrderActivity[] OrderActivityCollection { get; set; }

        [JsonProperty("replacingOrderCollection")]
        public ChildOrderStrategy[] ReplacingOrderCollection { get; set; }

        [JsonProperty("childOrderStrategies")]
        public ChildOrderStrategy[] ChildOrderStrategies { get; set; }

        [JsonProperty("statusDescription")]
        public string StatusDescription { get; set; }
    }

    public partial class CancelTime
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("shortFormat")]
        public bool ShortFormat { get; set; }
    }
}
