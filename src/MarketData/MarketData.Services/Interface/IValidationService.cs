using MarketData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketData.Services.Interface
{
    public interface IValidationService
    {
        (string uniqueIdentifier, bool isSuccess) ValidateMarketDataContribution(MarketDataContribution marketDataContribution);
    }
}
