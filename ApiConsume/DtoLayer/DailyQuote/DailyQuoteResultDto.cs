using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DailyQuote
{
    public record DailyQuoteResultDto
    {
        public int DailyQuoteId { get; init; }
        public string DailyQuoteSource { get; init; }
        public string Quote { get; init; }
        public DateTime Date { get; init; }
    }
}
