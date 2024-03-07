using AutoMapper;
using DtoLayer.AboutDto;
using DtoLayer.AnnouncementDto;
using DtoLayer.DailyQuote;
using DtoLayer.DrugTipDto;
using DtoLayer.FeedbackDto;
using DtoLayer.LoginDto;
using DtoLayer.PharmacyDto;
using DtoLayer.RegisterDto;
using DtoLayer.SubscribeDto;
using EntityLayer.Concrete;

namespace WebApi.Extensions
{
    public static class ConfigureMappingProfileExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(i => i.AddProfile(new AutoMapperMappingProfile()));

            IMapper mapper = mappingConfig.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }
    }

    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            CreateMap<CreatePharmacyDto, Pharmacy>().ReverseMap();
            CreateMap<PharmacyResultDto, Pharmacy>().ReverseMap();
            CreateMap<UpdatePharmacyDto, Pharmacy>().ReverseMap();
            CreateMap<CitiesandDistrictsResultDto, Pharmacy>().ReverseMap();
            CreateMap<CitiesandDistrictsResultDto, PharmacyResultDto>().ReverseMap();

            CreateMap<AnnouncementResultDto, Announcement>().ReverseMap();
            CreateMap<CreateAnnouncementDto, Announcement>().ReverseMap();
            CreateMap<UpdateAnnouncementDto, Announcement>().ReverseMap();

            CreateMap<DrugTipResultDto, DrugTip>().ReverseMap();
            CreateMap<CreateDrugTipDto, DrugTip>().ReverseMap();
            CreateMap<UpdateDrugTipDto, DrugTip>().ReverseMap();

            CreateMap<AboutResultDto, About>().ReverseMap();

            CreateMap<DailyQuoteResultDto, DailyQuote>().ReverseMap();
            CreateMap<CreateDailyQuoteDto, DailyQuote>().ReverseMap();
            CreateMap<UpdateDailyQuoteDto, DailyQuote>().ReverseMap();

            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();

            CreateMap<CreateFeedbackDto, Feedback>().ReverseMap();

            CreateMap<CreatePharmacyFeedbackDto, PharmacyFeedback>().ReverseMap();

            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
            CreateMap<LoginUserDto, AppUser>().ReverseMap();
        }
    }
}
