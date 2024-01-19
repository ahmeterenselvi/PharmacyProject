using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.PharmacyDto
{
    public record CitiesandDistrictsResultDto
    {
        public string City { get; init; }
        public string District { get; init; }
    }
}
