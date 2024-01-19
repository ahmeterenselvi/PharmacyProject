using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public string SenderName { get; set; }
        public string SenderMail { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }=DateTime.Now;
    }
}
