using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.AnnouncementDto
{
    public record UpdateAnnouncementDto
    {
        public int AnnouncementId { get; init; }

        [Required(ErrorMessage = "Başlık gereklidir.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Başlık uzunluğu 3 ile 100 arasında olmalıdır.")]
        public string Title { get; init; }

        [Required(ErrorMessage = "Özet gereklidir.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Özet uzunluğu 10 ile 500 arasında olmalıdır.")]
        public string Summary { get; init; }

        [Required(ErrorMessage = "Açıklama gereklidir.")]
        public string Description { get; init; }
        public DateTime Date { get; init; }

        [Required(ErrorMessage = "Resim gereklidir.")]
        [Url(ErrorMessage = "Geçersiz resim URL formatı.")]
        public string Image { get; init; }
    }
}
