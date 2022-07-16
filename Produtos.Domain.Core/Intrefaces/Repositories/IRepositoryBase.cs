using System.Collections.Generic;
using System.Threading.Tasks;

namespace Produtos.Domain.Core.Intrefaces.Repositories
{
    public interface IRepositoryBase<Tentity> where Tentity : class
    {
        void Add(Tentity obj);
        void Update(Tentity obj);
        void Remove(Tentity obj);
        IEnumerable<Tentity> GetAll();
        Tentity GetById(int id);
    }
}
