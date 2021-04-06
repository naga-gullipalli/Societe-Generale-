using MarketData.Models;
using MarketData.Repositories.Interface;
using MarketData.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarketData.Services
{
    public class FxQuoteService : IFxQuoteService
    {
        private readonly IFxQuoteRepository _repository;
        private readonly ILogger<FxQuoteService> _logger;

        public FxQuoteService(IFxQuoteRepository repository, ILogger<FxQuoteService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<FxQuote> Create(FxQuote fxQuote)
        {
            try
            {
                return await _repository.Create(fxQuote);
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
                return await _repository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception Log :", ex.StackTrace);
                return null;
            }            
        }
    }
}
