using DtoLayer.LoginDto;
using FluentValidation;

namespace WebUI.ValidationRules.LoginValidationRules
{
    public class LoginUserValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı Adı Giriniz.")
                .Length(3, 255).WithMessage("Kullanıcı adı 3 ile 255 karakter arasında olmalıdır.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre giriniz.")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
                .MaximumLength(255).WithMessage("Şifre en fazla 255 karakter olmalıdır.");
        }
    }
}
