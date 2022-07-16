using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Core.Intrefaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Produtos.Infra.Data.Repositories
{
    public class RepositoryBase<Tentity> : IRepositoryBase<Tentity> where Tentity : class
    {
        private readonly SqlContext sqlContext;
        public RepositoryBase(SqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public void Add(Tentity obj)
        {
            try
            {
                sqlContext.Set<Tentity>().Add(obj);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public IEnumerable<Tentity> GetAll()
        {
            return sqlContext.Set<Tentity>().ToList();
        }

        public Tentity GetById(int id)
        {
            return sqlContext.Set<Tentity>().Find(id);
        }

        public void Remove(Tentity obj)
        {
            try
            {
                sqlContext.Set<Tentity>().Remove(obj);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Update(Tentity obj)
        {
            try
            {
                sqlContext.Entry(obj).State = EntityState.Modified;
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
