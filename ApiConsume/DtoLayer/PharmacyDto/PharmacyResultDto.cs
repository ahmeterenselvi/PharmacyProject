using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.PharmacyDto
{
    public record PharmacyResultDto
    {
        public int PharmacyId { get; init; }
        public string Name { get; init; }
        public string City { get; init; }
        public string District { get; init; }
        public string Number { get; init; }
        public string Address { get; init; }
        public bool IsOnDuty { get; init; }

        public double Rate { get; init; }
    }
}
