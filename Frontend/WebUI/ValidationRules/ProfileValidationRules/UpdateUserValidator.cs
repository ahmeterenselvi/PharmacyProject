using FluentValidation;
using System.Text.RegularExpressions;

namespace DtoLayer.Profile
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Bir ad giriniz.")
                .MinimumLength(2).WithMessage("Ad en az 2 karakter olmalıdır.")
                .MaximumLength(255).WithMessage("Ad en fazla 255 karakter olabilir.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Bir soy ad giriniz.")
                .MinimumLength(2).WithMessage("Soyad en az 2 karakter olmalıdır.")
                .MaximumLength(255).WithMessage("Soyad en fazla 255 karakter olabilir.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Bir şifre giriniz.")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
                .MaximumLength(255).WithMessage("Şifre en fazla 255 karakter olabilir.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Şifrenizi tekrar giriniz.")
                .Equal(x => x.Password).WithMessage("Şifreler eşleşmiyor.");

            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email alanı boş bırakılamaz.")
            .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

            RuleFor(x => x.PhoneNumber)
                .Must(BeAValidPhoneNumber).When(x => !string.IsNullOrEmpty(x.PhoneNumber))
                .WithMessage("Geçerli bir telefon numarası giriniz.");

            RuleFor(x => x.City)
                .MaximumLength(255).WithMessage("Şehir ismi en fazla 255 karakter olmalıdır.");

            RuleFor(x => x.District)
                .MaximumLength(255).WithMessage("İlçe ismi en fazla 255 karakter olmalıdır.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Resim gereklidir.")
                .WithMessage("Geçersiz resim URL formatı.");
        }

        private bool BeAValidPhoneNumber(string phoneNumber)
        {
            Regex regex = new Regex(@"^(05\d{9,10})$");
            return regex.IsMatch(phoneNumber);
        }
    }
}
