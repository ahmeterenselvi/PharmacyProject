using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.FeedbackDto
{
    public record FeedbackResultDto
    {
        public int FeedbackId { get; init; }
        public string SenderName { get; init; }
        public string SenderMail { get; init; }
        public string Topic { get; init; }
        public string Content { get; init; }
        public DateTime Date { get; init; }
    }
}
