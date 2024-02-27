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
    public class FeedbackManager : IFeedbackService
    {
        private readonly IFeedbackDal _feedbackDal;

        public FeedbackManager(IFeedbackDal feedbackDal)
        {
            _feedbackDal = feedbackDal;
        }

        public int TCount()
        {
            return _feedbackDal.Count();
        }

        public void TDelete(Feedback t)
        {
            _feedbackDal.Delete(t);
        }

        public List<Feedback> TGetAll()
        {
            return _feedbackDal.GetAll();
        }

        public Feedback TGetById(int id)
        {
            return _feedbackDal.GetById(id);
        }

        public Feedback TInsert(Feedback t)
        {
            return _feedbackDal.Insert(t);
        }

        public void TUpdate(Feedback t)
        {
            _feedbackDal.Update(t);
        }
    }
}
