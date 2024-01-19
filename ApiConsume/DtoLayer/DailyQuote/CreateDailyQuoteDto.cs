using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DailyQuote
{
    public record CreateDailyQuoteDto
    {
        [Required(ErrorMessage = "Alıntı kaynağı gereklidir.")]
        public string DailyQuoteSource { get; init; }

        [Required(ErrorMessage = "Alıntı gereklidir.")]
        public string Quote { get; init; }
    }
}
