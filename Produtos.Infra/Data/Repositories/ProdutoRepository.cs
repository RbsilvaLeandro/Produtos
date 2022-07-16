using Produtos.Domain.Core.Intrefaces.Repositories;
using Produtos.Domain.Entities;

namespace Produtos.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        private readonly SqlContext _sqlContext;

        public ProdutoRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }        
    }
}
