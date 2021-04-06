using MarketData.Models;
using MarketData.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketData.Services
{
    public class ValidationService : IValidationService
    {
        public (string uniqueIdentifier, bool isSuccess) ValidateMarketDataContribution(MarketDataContribution marketDataContribution)
        {
            return (Guid.NewGuid().ToString(), true);
        }
    }
}
