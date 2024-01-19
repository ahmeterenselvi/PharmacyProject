using DtoLayer.PharmacyDto;
using FluentValidation;

namespace WebUI.ValidationRules.PharmacyValidationRules
{
    public class UpdatePharmacyValidator : AbstractValidator<UpdatePharmacyDto>
    {
        public UpdatePharmacyValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim alanı gereklidir.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir alanı gereklidir.");

            RuleFor(x => x.District)
                .NotEmpty().WithMessage("İlçe alanı gereklidir.");

            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Telefon numarası alanı gereklidir.")
                .Matches(@"^0 \(\d{3}\) \d{3}-\d{2}-\d{2}$").WithMessage("Geçersiz telefon numarası formatı.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres alanı gereklidir.");

            RuleFor(x => x.Rate)
                .NotEmpty().WithMessage("Puan alanı gereklidir.")
                .InclusiveBetween(1, 5).WithMessage("Puan alanı 1 ile 5 arasında olmalıdır.");
        }
    }
}
