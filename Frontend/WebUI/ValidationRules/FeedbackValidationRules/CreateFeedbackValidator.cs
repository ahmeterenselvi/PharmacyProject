using DtoLayer.FeedbackDto;
using FluentValidation;

namespace WebUI.ValidationRules.FeedbackValidationRules
{
    public class CreateFeedbackValidator : AbstractValidator<CreateFeedbackDto>
    {
        public CreateFeedbackValidator()
        {
            RuleFor(x => x.SenderName)
                .NotEmpty().WithMessage("Gönderen adı boş olamaz.");

            RuleFor(x => x.SenderMail)
                .NotEmpty().WithMessage("Gönderen e-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.Topic)
                .NotEmpty().WithMessage("Konu boş olamaz.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("İçerik boş olamaz.");
        }
    }
}
