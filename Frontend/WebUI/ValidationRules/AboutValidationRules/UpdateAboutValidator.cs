using DtoLayer.AboutDto;
using FluentValidation;

namespace WebUI.ValidationRules.AboutValidationRules
{
    public class UpdateAboutValidator : AbstractValidator<UpdateAboutDto>
    {
        public UpdateAboutValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı gereklidir.")
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olmalıdır.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı gereklidir.");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Resim alanı gereklidir.")
                .WithMessage("Lütfen geçerli bir URL girin.");
        }
    }
}
