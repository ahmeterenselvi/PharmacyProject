using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DrugTipDto
{
    public record DrugTipResultDto
    {
        public int DrugTipId { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string Image { get; init; }
    }
}
