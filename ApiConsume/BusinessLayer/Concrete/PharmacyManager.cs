﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.PharmacyDto;
using EntityLayer.Concrete;
using EntityLayer.RequestFeatures;
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

        public (IEnumerable<Pharmacy> pharmacies, MetaData metaData) TGetPaginatedPharmacies(PharmacyParameters pharmacyParameters)
        {
            var pharmacies = _pharmacyDal.GetPaginatedPharmacies(pharmacyParameters);

            return (pharmacies, pharmacies.MetaData);
        }

        public int TCount()
        {
            return _pharmacyDal.Count();
        }

        public List<CityPharmacyCountDto> TGetGetTopCitiesWithMostPharmacies()
        {
            return _pharmacyDal.GetTopCitiesWithMostPharmacies();
        }
    }
}
