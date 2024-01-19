using DtoLayer.DailyQuote;
using FluentValidation;

namespace WebUI.ValidationRules.DailyQuoteValidationRules
{
    public class CreateDailyQuoteValidator : AbstractValidator<CreateDailyQuoteDto>
    {
        public CreateDailyQuoteValidator()
        {
            RuleFor(x => x.DailyQuoteSource)
                .NotEmpty().WithMessage("Alıntı kaynağı gereklidir.");

            RuleFor(x => x.Quote)
                .NotEmpty().WithMessage("Alıntı gereklidir.");
        }
    }
}
