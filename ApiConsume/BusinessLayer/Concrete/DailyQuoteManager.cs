using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DailyQuoteManager : IDailyQuoteService
    {
        private readonly IDailyQuoteDal _dailyQuoteDal;

        public DailyQuoteManager(IDailyQuoteDal dailyQuoteDal)
        {
            _dailyQuoteDal = dailyQuoteDal;
        }

        public void TDelete(DailyQuote t)
        {
            _dailyQuoteDal.Delete(t);
        }

        public List<DailyQuote> TGetAll()
        {
            return _dailyQuoteDal.GetAll();
        }

        public DailyQuote TGetById(int id)
        {
            return _dailyQuoteDal.GetById(id);
        }

        public DailyQuote TInsert(DailyQuote t)
        {
            return _dailyQuoteDal.Insert(t);
        }

        public void TUpdate(DailyQuote t)
        {
            _dailyQuoteDal.Update(t);
        }
    }
}
