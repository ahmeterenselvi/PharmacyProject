using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Profile
{
    public record UpdateUserDto
    {
        [Required(ErrorMessage = "Bir ad giriniz.")]
        [MinLength(2), MaxLength(255)]
        public string Name { get; init; }

        [Required(ErrorMessage = "Bir soy ad giriniz.")]
        [MinLength(2), MaxLength(255)]
        public string Surname { get; init; }

        [Required(ErrorMessage = "Bir şifre giriniz.")]
        [MinLength(8), MaxLength(255)]
        public string Password { get; init; }

        [Required(ErrorMessage = "Şifrenizi tekrar giriniz.")]
        [Compare("Password", ErrorMessage = "Şifreler aynı olmalı.")]
        public string ConfirmPassword { get; init; }

        [RegularExpression(@"^(05\d{9})$", ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; init; }

        [StringLength(255, ErrorMessage = "Şehir ismi en fazla 255 karakter olmalıdır.")]
        public string City { get; init; }

        [StringLength(255, ErrorMessage = "İlçe ismi en fazla 255 karakter olmalıdır.")]
        public string District { get; init; }

        [Required(ErrorMessage = "Resim gereklidir.")]
        [Url(ErrorMessage = "Geçersiz resim URL formatı.")]
        public string ImageUrl { get; init; }
    }
}
