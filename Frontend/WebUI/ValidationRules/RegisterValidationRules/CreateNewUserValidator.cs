using DtoLayer.RegisterDto;
using FluentValidation;

namespace WebUI.ValidationRules.RegisterValidationRules
{
    public class CreateNewUserValidator : AbstractValidator<CreateNewUserDto>
    {
        public CreateNewUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Bir ad giriniz.")
                .Length(2, 255).WithMessage("Adınız 2 ile 255 karakter arasında olmalıdır.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Bir soy ad giriniz.")
                .Length(2, 255).WithMessage("Soyadınız 2 ile 255 karakter arasında olmalıdır.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Bir kullanıcı adı giriniz.")
                .Length(3, 255).WithMessage("Kullanıcı adınız 3 ile 255 karakter arasında olmalıdır.");

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("Bir mail adresi giriniz.")
                .EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Bir şifre giriniz.")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
                .MaximumLength(255).WithMessage("Şifre en fazla 255 karakter olmalıdır.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Şifrenizi tekrar giriniz.")
                .Equal(x => x.Password).WithMessage("Şifreler eşleşmiyor.");
        }
    }
}
