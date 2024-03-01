using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DtoLayer.PharmacyDto;
using EntityLayer.Concrete;
using EntityLayer.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfPharmacyDal : GenericRepository<Pharmacy>, IPharmacyDal
    {
        private readonly RepositoryContext _context;

        public EfPharmacyDal(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Pharmacy> GetAllPharmaciesQueryable()
        {
            return _context.Set<Pharmacy>();
        }

        public PagedList<Pharmacy> GetPaginatedPharmacies(PharmacyParameters pharmacyParameters)
        {
            var pharmacies = GetAll()
                .OrderBy(p => p.Name)
                .ToList();

            return PagedList<Pharmacy>
                .ToPagedList(pharmacies,
                pharmacyParameters.PageNumber,
                pharmacyParameters.PageSize);
        }

        public List<CityPharmacyCountDto> GetTopCitiesWithMostPharmacies()
        {
            var citiesPharmacyCount = _context.Pharmacies
            .GroupBy(p => p.City)
            .Select(g => new CityPharmacyCountDto
            {
                City = g.Key,
                PharmacyCount = g.Count()
            })
            .OrderByDescending(x => x.PharmacyCount)
            .Take(3)
            .ToList();

            return citiesPharmacyCount;

        }
    }
}
