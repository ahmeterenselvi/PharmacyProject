using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.AboutDto
{
    public record UpdateAboutDto
    {
        public int AboutId { get; init; }
        [Required(ErrorMessage = "Başlık alanı gereklidir.")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olmalıdır.")]
        public string Title { get; init; }

        [Required(ErrorMessage = "Açıklama alanı gereklidir.")]
        public string Description { get; init; }

        [Required(ErrorMessage = "Resim alanı gereklidir.")]
        [Url(ErrorMessage = "Lütfen geçerli bir URL girin.")]
        public string Image { get; init; }
    }
}
