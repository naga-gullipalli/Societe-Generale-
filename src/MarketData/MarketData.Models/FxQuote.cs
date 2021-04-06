using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketData.Models
{
    public class FxQuote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string  Currency { get; set; }

        public double Ask { get; set; }

        public double Bid { get; set; }

        public DateTime QuoteDateTime { get; set; }

    }
}
