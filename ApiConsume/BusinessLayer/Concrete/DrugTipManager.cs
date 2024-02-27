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
    public class DrugTipManager : IDrugTipService
    {
        private readonly IDrugTipDal _drugTipDal;

        public DrugTipManager(IDrugTipDal drugTipDal)
        {
            _drugTipDal = drugTipDal;
        }

        public int TCount()
        {
            return _drugTipDal.Count();
        }

        public void TDelete(DrugTip t)
        {
            _drugTipDal.Delete(t);
        }

        public List<DrugTip> TGetAll()
        {
            return _drugTipDal.GetAll();
        }

        public DrugTip TGetById(int id)
        {
            return _drugTipDal.GetById(id);
        }

        public DrugTip TInsert(DrugTip t)
        {
            return _drugTipDal.Insert(t);
        }

        public void TUpdate(DrugTip t)
        {
            _drugTipDal.Update(t);
        }
    }
}
