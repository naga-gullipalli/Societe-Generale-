using MarketData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketData.Repositories.Interface
{
    public interface IFxQuoteRepository
    {
        Task<FxQuote> Create(FxQuote fxQuote);
        Task<IEnumerable<FxQuote>> GetAll();

    }
}
