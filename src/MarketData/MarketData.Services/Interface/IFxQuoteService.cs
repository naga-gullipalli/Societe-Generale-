using MarketData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarketData.Services.Interface
{
    public interface IFxQuoteService
    {
        Task<FxQuote> Create(FxQuote fxQuote);
        Task<IEnumerable<FxQuote>> GetAll();
    }
}
