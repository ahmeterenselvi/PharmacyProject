using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.PharmacyDto
{
    public record CreatePharmacyDto
    {
        [Required(ErrorMessage = "İsim alanı gereklidir.")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Şehir alanı gereklidir.")]
        public string City { get; init; }

        [Required(ErrorMessage = "İlçe alanı gereklidir.")]
        public string District { get; init; }

        [Required(ErrorMessage = "Telefon numarası alanı gereklidir.")]
        [RegularExpression(@"^0 \(\d{3}\) \d{3}-\d{2}-\d{2}$", ErrorMessage = "Geçersiz telefon numarası formatı.")]
        public string Number { get; init; }

        [Required(ErrorMessage = "Adres alanı gereklidir.")]
        public string Address { get; init; }
        [Required(ErrorMessage = "Puan alanı gereklidir.")]
        [Range(1, 5, ErrorMessage = "Puan alanı 1 ile 5 arasında olmalıdır.")]
        public double Rate { get; init; }
    }
}
