using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.LoginDto
{
    public record LoginUserDto
    {
        [Required(ErrorMessage = "Kullanıcı Adı Giriniz.")]
        [MinLength(3), MaxLength(255)]
        public string Username { get; init; }

        [Required(ErrorMessage = "Şifre giriniz.")]
        [PasswordPropertyText]
        [MinLength(8), MaxLength(255)]
        public string Password { get; init; }
    }
}
