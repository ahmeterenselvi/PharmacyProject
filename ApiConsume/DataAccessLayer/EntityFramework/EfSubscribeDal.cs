using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfSubscribeDal : GenericRepository<Subscribe>, ISubscribeDal
    {
        public EfSubscribeDal(RepositoryContext context) : base(context)
        {

        }

        public Subscribe CheckEmailExistence(string mail)
        {
            return GetAll().FirstOrDefault(m => m.Mail == mail);
        }
    }
}
