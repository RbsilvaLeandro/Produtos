using Produtos.Application.DTO;
using System.Collections.Generic;

namespace Produtos.Application.Interfaces
{
    public interface IApplicationProdutoService
    {
        void Add(ProdutoDTO produtoDTO);
        void Update(ProdutoDTO produtoDTO);
        void Remove(ProdutoDTO produtoDTO);
        IEnumerable<ProdutoDTO> GetAll();
        ProdutoDTO GetById(int id);      
    }
}
