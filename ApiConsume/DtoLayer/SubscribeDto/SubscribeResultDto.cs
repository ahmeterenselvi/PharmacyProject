using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.SubscribeDto
{
    public record SubscribeResultDto
    {
        public int SubscribeId { get; init; }
        public string Mail { get; init; }
    }
}
