using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DrugTipDto
{
    public record UpdateDrugTipDto
    {
        public int DrugTipId { get; init; }

        [Required(ErrorMessage = "Başlık alanı zorunludur")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Başlık uzunluğu 2 ile 100 arasında olmalıdır.")]
        public string Title { get; init; }

        [Required(ErrorMessage = "Açıklama zorunludur")]
        [StringLength(500, ErrorMessage = "Açıklama maksimum 500 karakter olmalıdır.")]
        public string Description { get; init; }

        [Required(ErrorMessage = "Resim zorunludur")]
        [Url(ErrorMessage = "Lütfen geçerli bir URL girin.")]
        public string Image { get; init; }
    }
}
