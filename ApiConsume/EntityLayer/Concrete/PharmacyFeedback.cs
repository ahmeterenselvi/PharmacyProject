using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PharmacyFeedback
    {
        public int PharmacyFeedbackId { get; set; }
        public string SenderMail { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [ForeignKey(nameof(PharmacyFeedbackId))]
        public int PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; }
    }
}
