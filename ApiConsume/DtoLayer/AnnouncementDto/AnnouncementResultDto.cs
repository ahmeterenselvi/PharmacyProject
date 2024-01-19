using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.AnnouncementDto
{
    public record AnnouncementResultDto
    {
        public int AnnouncementId { get; init; }
        public string Title { get; init; }
        public string Summary { get; init; }
        public string Description { get; init; }
        public DateTime Date { get; init; }
        public string Image { get; init; }
    }
}
