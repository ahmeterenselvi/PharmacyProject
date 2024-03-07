using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.PharmacyDto
{
    public record PharmacyFeedbackResultDto
    {
        public string SenderMail { get; init; }
        public string Topic { get; init; }
        public string Content { get; init; }
        public double Rating { get; init; }
        public DateTime Date { get; init; }
        public string Name { get; init; }
        public string City { get; init; }
        public string District { get; init; }
        public int PharmacyId { get; init; }
    }
}
