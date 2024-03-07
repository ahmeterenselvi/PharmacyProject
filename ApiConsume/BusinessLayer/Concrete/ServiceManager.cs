using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public record ServiceManager(
    IAboutService AboutService,
    IAnnouncementService AnnouncementService,
    IPharmacyService PharmacyService,
    IDrugTipService DrugTipService,
    IDailyQuoteService DailyQuoteService,
    ISubscribeService SubscribeService,
    IFeedbackService FeedbackService,
    IPharmacyFeedbackService PharmacyFeedbackService) : IServiceManager;
}
