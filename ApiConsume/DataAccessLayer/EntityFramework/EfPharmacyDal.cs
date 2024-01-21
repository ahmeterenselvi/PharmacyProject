﻿using DataAccessLayer.Abstract;
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
    public class EfPharmacyDal:GenericRepository<Pharmacy>,IPharmacyDal
    {
        private readonly RepositoryContext _context;

        public EfPharmacyDal(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Pharmacy> GetAllPharmaciesQueryable()
        {
            return _context.Set<Pharmacy>();
        }
    }
}
