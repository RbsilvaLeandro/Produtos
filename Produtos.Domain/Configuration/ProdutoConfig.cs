using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos.Domain.Entities;

namespace Produtos.Domain.Configuration
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(c => c.Nome).HasMaxLength(40);
            builder.Property(c => c.Preco).HasPrecision(8, 2);            
        }
    }
}
