using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IServiceManager
    {
        IAboutService AboutService { get; }
        IAnnouncementService AnnouncementService { get; }
        IPharmacyService PharmacyService { get; }
        IDrugTipService DrugTipService { get; }
        IDailyQuoteService DailyQuoteService { get; }
        ISubscribeService SubscribeService { get; }
        IFeedbackService FeedbackService { get; }
        IPharmacyFeedbackService PharmacyFeedbackService { get; }
    }
}
