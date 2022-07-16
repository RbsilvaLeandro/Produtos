using Produtos.Domain.Core.Intrefaces.Repositories;
using Produtos.Domain.Core.Intrefaces.Services;
using Produtos.Domain.Entities;

namespace Produtos.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _repositoryProduto;


        public ProdutoService(IProdutoRepository repositoryProduto) : base(repositoryProduto)
        {
            _repositoryProduto = repositoryProduto;
        }       
    }
}
