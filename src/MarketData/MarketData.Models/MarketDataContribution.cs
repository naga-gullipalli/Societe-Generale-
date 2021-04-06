using System;
using System.Collections.Generic;
using System.Text;

namespace MarketData.Models
{
    public class MarketDataContribution
    {
        public int MarketDataType { get; set; }
        public FxQuote FxQuote { get; set; }

    }
}
