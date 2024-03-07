using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.RegisterDto
{
    public record CreateNewUserDto
    {
        [Required(ErrorMessage = "Bir ad giriniz.")]
        [MinLength(2), MaxLength(255)]
        public string Name { get; init; }

        [Required(ErrorMessage = "Bir soy ad giriniz.")]
        [MinLength(2), MaxLength(255)]
        public string Surname { get; init; }

        [Required(ErrorMessage = "Bir kullanıcı adı giriniz.")]
        [MinLength(3), MaxLength(255)]
        public string Username { get; init; }

        [Required(ErrorMessage = "Bir mail adresi giriniz.")]
        [EmailAddress]
        public string Mail { get; init; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "Geçerli bir Türkiye kimlik numarası giriniz.")]
        public string TurkishIdentityNumber { get; init; }

        [Required(ErrorMessage = "Bir şifre giriniz.")]
        [MinLength(8), MaxLength(255)]
        public string Password { get; init; }

        [Required(ErrorMessage = "Şifrenizi tekrar giriniz.")]
        [Compare("Password", ErrorMessage = "Şifreler aynı olmalı.")]
        public string ConfirmPassword { get; init; }
    }
}
