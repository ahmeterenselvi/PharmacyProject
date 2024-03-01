using DtoLayer.PharmacyDto;
using EntityLayer.Concrete;
using EntityLayer.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPharmacyService : IGenericService<Pharmacy>
    {
        IQueryable<Pharmacy> TGetAllPharmaciesQueryable();

        (IEnumerable<Pharmacy> pharmacies, MetaData metaData) TGetPaginatedPharmacies(PharmacyParameters pharmacyParameters);

        List<CityPharmacyCountDto> TGetGetTopCitiesWithMostPharmacies();
    }
}
