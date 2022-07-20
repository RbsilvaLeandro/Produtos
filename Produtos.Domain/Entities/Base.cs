using System.ComponentModel.DataAnnotations.Schema;

namespace Produtos.Domain.Entities
{
    public class Base
    {
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
    }
}
