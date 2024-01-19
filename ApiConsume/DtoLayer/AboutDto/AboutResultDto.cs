using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.AboutDto
{
    public record AboutResultDto
    {
        public int AboutId { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string Image { get; init; }
    }
}
