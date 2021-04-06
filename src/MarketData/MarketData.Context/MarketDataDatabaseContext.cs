using MarketData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketData.Context
{
    public class MarketDataDatabaseContext  : DbContext
    {
        public MarketDataDatabaseContext(DbContextOptions<MarketDataDatabaseContext> options) : base(options)
        {

        }

        public DbSet<FxQuote> FxQuotes { get; set; }

       
    }
}
