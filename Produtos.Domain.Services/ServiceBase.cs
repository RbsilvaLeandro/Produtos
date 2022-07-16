using Produtos.Domain.Core.Intrefaces.Repositories;
using Produtos.Domain.Core.Intrefaces.Services;
using System.Collections.Generic;

namespace Produtos.Domain.Services
{
    public class ServiceBase<Tentity> : IServiceBase<Tentity> where Tentity : class
    {
        private readonly IRepositoryBase<Tentity> _repositoryBase;

        public ServiceBase(IRepositoryBase<Tentity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public void Add(Tentity obj)
        {
            _repositoryBase.Add(obj);
        }

        public IEnumerable<Tentity> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public Tentity GetById(int id)
        {
            return _repositoryBase.GetById(id);
        }

        public void Remove(Tentity obj)
        {
            _repositoryBase.Remove(obj);
        }

        public void Update(Tentity obj)
        {
            _repositoryBase.Update(obj);
        }
    }
}
