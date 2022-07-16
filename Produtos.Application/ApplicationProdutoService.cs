using AutoMapper;
using Produtos.Application.DTO;
using Produtos.Application.Interfaces;
using Produtos.Domain.Core.Intrefaces.Services;
using Produtos.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Produtos.Application
{
    public class ApplicationProdutoService : IApplicationProdutoService
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ApplicationProdutoService(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }
        public void Add(ProdutoDTO ProdutoDTO)
        {
            var produto = _mapper.Map<Produto>(ProdutoDTO);
            _produtoService.Add(produto);
        }

        public IEnumerable<ProdutoDTO> GetAll()
        {
            var produto = _produtoService.GetAll();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produto);
        }

        public ProdutoDTO GetById(int id)
        {
            var produto = _produtoService.GetById(id);
            return _mapper.Map<ProdutoDTO>(produto);
        }        

        public void Remove(ProdutoDTO ProdutoDTO)
        {
            var produto = _mapper.Map<Produto>(ProdutoDTO);
            _produtoService.Remove(produto);
        }

        public void Update(ProdutoDTO ProdutoDTO)
        {
            var produto = _mapper.Map<Produto>(ProdutoDTO);
            _produtoService.Update(produto);
        }
    }
}
