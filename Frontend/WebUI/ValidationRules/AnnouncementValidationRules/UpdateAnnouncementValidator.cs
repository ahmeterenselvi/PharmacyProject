using DtoLayer.AnnouncementDto;
using FluentValidation;

namespace WebUI.ValidationRules.AnnouncementValidationRules
{
    public class UpdateAnnouncementValidator : AbstractValidator<UpdateAnnouncementDto>
    {
        public UpdateAnnouncementValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık gereklidir.")
                .Length(3, 100).WithMessage("Başlık uzunluğu 3 ile 100 arasında olmalıdır.");

            RuleFor(x => x.Summary)
                .NotEmpty().WithMessage("Özet gereklidir")
                .Length(10, 500).WithMessage("Özet uzunluğu 10 ile 500 arasında olmalıdır.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama gereklidir.");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Resim gereklidir.")
                .WithMessage("Geçersiz resim URL formatı.");
        }

    }
}
