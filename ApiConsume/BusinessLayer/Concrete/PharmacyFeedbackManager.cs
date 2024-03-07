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
    public class PharmacyFeedbackManager : IPharmacyFeedbackService
    {
        private readonly IPharmacyFeedbackDal _pharmacyFeedbackDal;

        public PharmacyFeedbackManager(IPharmacyFeedbackDal pharmacyFeedbackDal)
        {
            _pharmacyFeedbackDal = pharmacyFeedbackDal;
        }

        public int TCount()
        {
            return _pharmacyFeedbackDal.Count();
        }

        public void TDelete(PharmacyFeedback t)
        {
            _pharmacyFeedbackDal.Delete(t);
        }

        public List<PharmacyFeedback> TGetAll()
        {
            return _pharmacyFeedbackDal.GetAll();
        }

        public PharmacyFeedback TGetById(int id)
        {
            return _pharmacyFeedbackDal.GetById(id);
        }

        public PharmacyFeedback TInsert(PharmacyFeedback t)
        {
            return _pharmacyFeedbackDal.Insert(t);
        }

        public void TUpdate(PharmacyFeedback t)
        {
            _pharmacyFeedbackDal.Update(t);
        }
    }
}
