using System.Collections.Generic;

namespace Produtos.Domain.Core.Intrefaces.Services
{
    public interface IServiceBase<Tentity> where Tentity : class
    {
        void Add(Tentity obj);
        void Update(Tentity obj);
        void Remove(Tentity obj);
        IEnumerable<Tentity> GetAll();
        Tentity GetById(int id);
    }
}
