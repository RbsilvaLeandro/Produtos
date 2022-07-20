using System.Collections.Generic;

namespace Produtos.Application.DTO
{
    public class RequisicaoBuscaProdutosModel
    {
        public RequisicaoBuscaPaginadaModel RequisicaoBuscaPaginadaModel { get; set; }
        public int filtroId { get; set; }
        public string filtroNome { get; set; }
    }
}
