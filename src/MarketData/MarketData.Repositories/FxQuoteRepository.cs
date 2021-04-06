using MarketData.Context;
using MarketData.Models;
using MarketData.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketData.Repositories
{
    public class FxQuoteRepository : IFxQuoteRepository
    {
        private readonly IServiceScope _scope;
        private readonly MarketDataDatabaseContext _databaseContext;
        private readonly ILogger<FxQuoteRepository> _logger;

        public FxQuoteRepository(IServiceProvider services, ILogger<FxQuoteRepository> logger)
        {
            _scope = services.CreateScope();

            _logger = logger;
            _databaseContext = _scope.ServiceProvider.GetRequiredService<MarketDataDatabaseContext>();
        }

        public async Task<FxQuote> Create(FxQuote fxQuote)
        {
            try
            {
                _databaseContext.FxQuotes.Add(fxQuote);

                var numberOfItemsCreated = await _databaseContext.SaveChangesAsync();

                if (numberOfItemsCreated == 1)
                    return fxQuote;
                else
                    return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Log :", ex.StackTrace);
                return null;
            }            
        }

        public async Task<IEnumerable<FxQuote>> GetAll()
        {
            try
            {
                return await _databaseContext.FxQuotes.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Log :", ex.StackTrace);
                return null;
            }         
        }
    }
}
