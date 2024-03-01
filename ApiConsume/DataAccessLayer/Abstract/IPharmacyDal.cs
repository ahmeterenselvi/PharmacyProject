using DtoLayer.PharmacyDto;
using EntityLayer.Concrete;
using EntityLayer.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPharmacyDal:IGenericDal<Pharmacy>
    {
        IQueryable<Pharmacy> GetAllPharmaciesQueryable();

        PagedList<Pharmacy> GetPaginatedPharmacies(PharmacyParameters pharmacyParameters);

        List<CityPharmacyCountDto> GetTopCitiesWithMostPharmacies();
    }
}
