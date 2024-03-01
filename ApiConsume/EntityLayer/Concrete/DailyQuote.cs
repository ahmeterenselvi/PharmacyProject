using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class DailyQuote
    {
        public int DailyQuoteId { get; set; }
        public string DailyQuoteSource { get; set; }
        public string Quote { get; set; }
        public DateTime Date { get; set; }=DateTime.Now;
    }
}
