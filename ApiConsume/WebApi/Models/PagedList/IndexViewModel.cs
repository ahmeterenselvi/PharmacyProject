using DtoLayer.PharmacyDto;

namespace WebApi.Models.PagedList
{
    public class IndexViewModel
    {
        public IEnumerable<PharmacyResultDto> Pharmacies { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}
