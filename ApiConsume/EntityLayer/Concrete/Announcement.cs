using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Image { get; set; }
    }
}
