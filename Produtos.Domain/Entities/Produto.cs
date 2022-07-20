using System.ComponentModel.DataAnnotations.Schema;

namespace Produtos.Domain.Entities
{
    public class Produto : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
