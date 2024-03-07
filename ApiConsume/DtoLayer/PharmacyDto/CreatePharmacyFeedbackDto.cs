using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.PharmacyDto
{
    public record CreatePharmacyFeedbackDto
    {

        [Required(ErrorMessage = "Gönderici e-postası gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string SenderMail { get; init; }

        [Required(ErrorMessage = "Konu alanı gereklidir.")]
        public string Topic { get; init; }

        [Required(ErrorMessage = "İçerik alanı gereklidir.")]
        public string Content { get; init; }

        [Range(1, 5, ErrorMessage = "Derecelendirme 1 ile 5 arasında olmalıdır.")]
        public double Rating { get; init; }
        [Required(ErrorMessage = "Eczane Id'si gereklidir.")]
        public int PharmacyId { get; set; }

        [Required(ErrorMessage = "Eczane bilgisi gereklidir.")]
        public Pharmacy Pharmacy { get; init; }
    }
}
