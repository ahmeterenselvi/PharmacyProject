using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void RegisterSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<RepositoryContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }

        public static void AddScopedEfDals(this IServiceCollection services)
        {
            services.AddScoped<IAboutDal,EfAboutDal>();
            services.AddScoped<IAnnouncementDal,EfAnnouncementDal>();
            services.AddScoped<IPharmacyDal,EfPharmacyDal>();
            services.AddScoped<IDrugTipDal,EfDrugTipDal>();
            services.AddScoped<IDailyQuoteDal,EfDailyQuoteDal>();
            services.AddScoped<ISubscribeDal,EfSubscribeDal>();
            services.AddScoped<IFeedbackDal,EfFeedbackDal>();
        }

        public static void RegisterManagers(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IPharmacyService, PharmacyManager>();
            services.AddScoped<IDrugTipService, DrugTipManager>();
            services.AddScoped<IDailyQuoteService, DailyQuoteManager>();
            services.AddScoped<ISubscribeService, SubscribeManager>();
            services.AddScoped<IFeedbackService, FeedbackManager>();
        }

        public static void AddApiCors(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("PharmacyApiCors", opts =>
                {
                    opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));
        }

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }
    }
}
