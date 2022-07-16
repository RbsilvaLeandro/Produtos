using AutoMapper;
using Produtos.Application.DTO;
using Produtos.Domain.Entities;

namespace Produtos.Application.Mapper
{
    public class ModelToDtoMapperProduto : Profile
    {
        public ModelToDtoMapperProduto()
        {
            CreateMapDtoProduto();
        }

        private void CreateMapDtoProduto()
        {
            CreateMap<Produto, ProdutoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Preco, opt => opt.MapFrom(x => x.Preco));
        }
    }
}
