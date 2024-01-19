using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAboutService> _aboutService;
        private readonly Lazy<IAnnouncementService> _announcementService;
        private readonly Lazy<IPharmacyService> _pharmacyService;
        private readonly Lazy<IDrugTipService> _drugTipService;
        private readonly Lazy<IDailyQuoteService> _dailyQuoteService;
        private readonly Lazy<ISubscribeService> _subscribeService;
        private readonly Lazy<IFeedbackService> _feedbackService;

        public ServiceManager()
        {
            _aboutService=new Lazy<IAboutService> ();
            _announcementService=new Lazy<IAnnouncementService> ();
            _pharmacyService=new Lazy<IPharmacyService> ();
            _drugTipService = new Lazy<IDrugTipService> ();
            _dailyQuoteService = new Lazy<IDailyQuoteService> ();
            _subscribeService = new Lazy<ISubscribeService> ();
            _feedbackService = new Lazy<IFeedbackService> ();
        }

        public IAboutService AboutService =>_aboutService.Value;
        public IAnnouncementService AnnouncementService =>_announcementService.Value;
        public IPharmacyService PharmacyService =>_pharmacyService.Value;
        public IDrugTipService DrugTipService => _drugTipService.Value;
        public IDailyQuoteService DailyQuoteService => _dailyQuoteService.Value;
        public ISubscribeService SubscribeService => _subscribeService.Value;
        public IFeedbackService FeedbackService => _feedbackService.Value;
    }
}
