using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DtoLayer.FeedbackDto
{
    public record CreateFeedbackDto
    {
        public int FeedbackId { get; init; }

        [Required(ErrorMessage = "Gönderen adı boş olamaz.")]
        public string SenderName { get; init; }

        [Required(ErrorMessage = "Gönderen e-posta boş olamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string SenderMail { get; init; }

        [Required(ErrorMessage = "Konu boş olamaz.")]
        public string Topic { get; init; }

        [Required(ErrorMessage = "İçerik boş olamaz.")]
        public string Content { get; init; }

        public DateTime Date { get; init; } = DateTime.Now;
    }
}
