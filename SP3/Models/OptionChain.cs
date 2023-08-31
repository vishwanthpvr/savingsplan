﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP3.Models
{
    public partial class OptionChain
    {
        [JsonProperty("putCall")]
        public string PutCall { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("exchangeName")]
        public string ExchangeName { get; set; }

        [JsonProperty("bid")]
        public double Bid { get; set; }

        [JsonProperty("ask")]
        public double Ask { get; set; }

        [JsonProperty("last")]
        public double Last { get; set; }

        [JsonProperty("mark")]
        public double Mark { get; set; }

        [JsonProperty("bidSize")]
        public long BidSize { get; set; }

        [JsonProperty("askSize")]
        public long AskSize { get; set; }

        [JsonProperty("bidAskSize")]
        public string BidAskSize { get; set; }

        [JsonProperty("lastSize")]
        public long LastSize { get; set; }

        [JsonProperty("highPrice")]
        public double HighPrice { get; set; }

        [JsonProperty("lowPrice")]
        public double LowPrice { get; set; }

        [JsonProperty("openPrice")]
        public long OpenPrice { get; set; }

        [JsonProperty("closePrice")]
        public double ClosePrice { get; set; }

        [JsonProperty("totalVolume")]
        public long TotalVolume { get; set; }

        [JsonProperty("tradeDate")]
        public object TradeDate { get; set; }

        [JsonProperty("tradeTimeInLong")]
        public long TradeTimeInLong { get; set; }

        [JsonProperty("quoteTimeInLong")]
        public long QuoteTimeInLong { get; set; }

        [JsonProperty("netChange")]
        public double NetChange { get; set; }

        [JsonProperty("volatility")]
        public double Volatility { get; set; }

        [JsonProperty("delta")]
        public double Delta { get; set; }

        [JsonProperty("gamma")]
        public double Gamma { get; set; }

        [JsonProperty("theta")]
        public double Theta { get; set; }

        [JsonProperty("vega")]
        public double Vega { get; set; }

        [JsonProperty("rho")]
        public double Rho { get; set; }

        [JsonProperty("openInterest")]
        public long OpenInterest { get; set; }

        [JsonProperty("timeValue")]
        public double TimeValue { get; set; }

        [JsonProperty("theoreticalOptionValue")]
        public double TheoreticalOptionValue { get; set; }

        [JsonProperty("theoreticalVolatility")]
        public long TheoreticalVolatility { get; set; }

        [JsonProperty("optionDeliverablesList")]
        public object OptionDeliverablesList { get; set; }

        [JsonProperty("strikePrice")]
        public long StrikePrice { get; set; }

        [JsonProperty("expirationDate")]
        public long ExpirationDate { get; set; }

        [JsonProperty("daysToExpiration")]
        public long DaysToExpiration { get; set; }

        [JsonProperty("expirationType")]
        public string ExpirationType { get; set; }

        [JsonProperty("lastTradingDay")]
        public long LastTradingDay { get; set; }

        [JsonProperty("multiplier")]
        public long Multiplier { get; set; }

        [JsonProperty("settlementType")]
        public string SettlementType { get; set; }

        [JsonProperty("deliverableNote")]
        public string DeliverableNote { get; set; }

        [JsonProperty("isIndexOption")]
        public object IsIndexOption { get; set; }

        [JsonProperty("percentChange")]
        public double PercentChange { get; set; }

        [JsonProperty("markChange")]
        public double MarkChange { get; set; }

        [JsonProperty("markPercentChange")]
        public double MarkPercentChange { get; set; }

        [JsonProperty("mini")]
        public bool Mini { get; set; }

        [JsonProperty("inTheMoney")]
        public bool InTheMoney { get; set; }

        [JsonProperty("nonStandard")]
        public bool NonStandard { get; set; }
    }
}
