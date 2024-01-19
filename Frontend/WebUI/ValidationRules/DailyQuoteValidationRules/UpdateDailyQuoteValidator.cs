using DtoLayer.DailyQuote;
using FluentValidation;

namespace WebUI.ValidationRules.DailyQuoteValidationRules
{
    public class UpdateDailyQuoteValidator : AbstractValidator<UpdateDailyQuoteDto>
    {
        public UpdateDailyQuoteValidator()
        {
            RuleFor(x => x.DailyQuoteSource)
                .NotEmpty().WithMessage("Alıntı kaynağı gereklidir.");

            RuleFor(x => x.Quote)
                .NotEmpty().WithMessage("Alıntı gereklidir.");
        }
    }
}
