using DtoLayer.DrugTipDto;
using FluentValidation;

namespace WebUI.ValidationRules.DrugTipValidationRules
{
    public class CreateDrugTipValidator : AbstractValidator<CreateDrugTipDto>
    {
        public CreateDrugTipValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı zorunludur.")
                .Length(2, 100).WithMessage("Başlık uzunluğu 2 ile 100 arasında olmalıdır.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama zorunludur.")
                .MaximumLength(500).WithMessage("Açıklama maksimum 500 karakter olmalıdır.");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Resim zorunludur.")
                .Must(BeAValidUrl).When(x => !string.IsNullOrEmpty(x.Image)).WithMessage("Lütfen geçerli bir URL girin.");
        }

        private bool BeAValidUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return true;

            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
