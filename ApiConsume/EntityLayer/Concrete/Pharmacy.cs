using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Pharmacy
    {
        public int PharmacyId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Directions { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool IsOnDuty { get; set; }
        public double Rate { get; set; }
        public List<PharmacyFeedback> Feedbacks { get; set; }
    }
}
