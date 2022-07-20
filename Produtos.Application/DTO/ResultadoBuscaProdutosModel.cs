using System.Collections.Generic;

namespace Produtos.Application.DTO
{
    public class ResultadoBuscaProdutosModel
    {
        public ResultadoBuscaPaginadaModel paginacao { get; set; }
        public List<ProdutoDTO> items { get; set; }
    }
}
