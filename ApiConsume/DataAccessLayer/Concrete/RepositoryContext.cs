using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class RepositoryContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<DrugTip> DrugTips { get; set; }
        public DbSet<DailyQuote> DailyQuotes { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<PharmacyFeedback> PharmacyFeedbacks { get; set; }
    }
}
