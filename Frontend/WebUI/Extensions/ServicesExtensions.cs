using DataAccessLayer.Concrete;
using DtoLayer.AboutDto;
using DtoLayer.AnnouncementDto;
using DtoLayer.DailyQuote;
using DtoLayer.DrugTipDto;
using DtoLayer.FeedbackDto;
using DtoLayer.LoginDto;
using DtoLayer.PharmacyDto;
using DtoLayer.RegisterDto;
using DtoLayer.SubscribeDto;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebUI.ValidationRules.AboutValidationRules;
using WebUI.ValidationRules.AnnouncementValidationRules;
using WebUI.ValidationRules.DailyQuoteValidationRules;
using WebUI.ValidationRules.DrugTipValidationRules;
using WebUI.ValidationRules.FeedbackValidationRules;
using WebUI.ValidationRules.LoginValidationRules;
using WebUI.ValidationRules.PharmacyValidationRules;
using WebUI.ValidationRules.RegisterValidationRules;
using WebUI.ValidationRules.SubscribeValidationRules;

namespace WebUI.Extensions
{
    public static class ServicesExtensions
    {
        public static void RegisterSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<RepositoryContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }

        public static void ConfigureValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UpdateAboutDto>, UpdateAboutValidator>();

            services.AddTransient<IValidator<CreateAnnouncementDto>, CreateAnnouncementValidator>();
            services.AddTransient<IValidator<UpdateAnnouncementDto>, UpdateAnnouncementValidator>();

            services.AddTransient<IValidator<CreateDailyQuoteDto>, CreateDailyQuoteValidator>();
            services.AddTransient<IValidator<UpdateDailyQuoteDto>, UpdateDailyQuoteValidator>();

            services.AddTransient<IValidator<CreateDrugTipDto>, CreateDrugTipValidator>();
            services.AddTransient<IValidator<UpdateDrugTipDto>, UpdateDrugTipValidator>();

            services.AddTransient<IValidator<CreateFeedbackDto>, CreateFeedbackValidator>();

            services.AddTransient<IValidator<LoginUserDto>, LoginUserValidator>();
            services.AddTransient<IValidator<CreateNewUserDto>, CreateNewUserValidator>();

            services.AddTransient<IValidator<CreatePharmacyDto>, CreatePharmacyValidator>();
            services.AddTransient<IValidator<UpdatePharmacyDto>, UpdatePharmacyValidator>();

            services.AddTransient<IValidator<CreateSubscribeDto>, CreateSubscribeValidator>();
        }
    }
}
