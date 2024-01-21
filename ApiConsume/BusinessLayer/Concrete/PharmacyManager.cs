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
    public class PharmacyManager : IPharmacyService
    {
        private readonly IPharmacyDal _pharmacyDal;

        public PharmacyManager(IPharmacyDal pharmacyDal)
        {
            _pharmacyDal = pharmacyDal;
        }

        public IQueryable<Pharmacy> TGetAllPharmaciesQueryable()
        {
            return _pharmacyDal.GetAllPharmaciesQueryable();
        }

        public void TDelete(Pharmacy t)
        {
            _pharmacyDal.Delete(t);
        }

        public List<Pharmacy> TGetAll()
        {
            return _pharmacyDal.GetAll();
        }

        public Pharmacy TGetById(int id)
        {
            return _pharmacyDal.GetById(id);
        }

        public Pharmacy TInsert(Pharmacy t)
        {
            return _pharmacyDal.Insert(t);
        }

        public void TUpdate(Pharmacy t)
        {
            _pharmacyDal.Update(t);
        }
    }
}
