using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public About TGetAbout()
        {
            return _aboutDal.GetAbout();
        }

        public int TCount()
        {
            return _aboutDal.Count();
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public List<About> TGetAll()
        {
            return _aboutDal.GetAll();
        }

        public About TGetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public About TInsert(About t)
        {
            return _aboutDal.Insert(t);
        }

        public void TUpdate(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
