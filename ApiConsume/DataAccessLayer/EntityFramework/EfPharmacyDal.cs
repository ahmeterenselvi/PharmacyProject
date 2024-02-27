using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
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
    }
}
