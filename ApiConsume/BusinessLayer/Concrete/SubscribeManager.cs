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
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public int TCount()
        {
            return _subscribeDal.Count();
        }

        public void TDelete(Subscribe t)
        {
            _subscribeDal.Delete(t);
        }

        public List<Subscribe> TGetAll()
        {
            return _subscribeDal.GetAll();
        }

        public Subscribe TGetById(int id)
        {
            return _subscribeDal.GetById(id);
        }

        public Subscribe TInsert(Subscribe t)
        {
            var existingSubscribe = _subscribeDal.CheckEmailExistence(t.Mail);
            if (existingSubscribe == null)
            {
                return _subscribeDal.Insert(t);
            }
            return existingSubscribe;

        }

        public void TUpdate(Subscribe t)
        {
            _subscribeDal.Update(t);
        }
    }
}
