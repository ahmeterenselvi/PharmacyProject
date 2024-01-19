using DtoLayer.SubscribeDto;
using FluentValidation;

namespace WebUI.ValidationRules.SubscribeValidationRules
{
    public class CreateSubscribeValidator : AbstractValidator<CreateSubscribeDto>
    {
        public CreateSubscribeValidator()
        {
            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("E-posta adresi gereklidir.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
        }
    }
}
