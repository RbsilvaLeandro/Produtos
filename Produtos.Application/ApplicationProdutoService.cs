using AutoMapper;
using FluentValidation.Results;
using Produtos.Application.DTO;
using Produtos.Application.Interfaces;
using Produtos.Application.Validator;
using Produtos.Domain.Core.Intrefaces.Services;
using Produtos.Domain.Entities;
using System;
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

        public ResultadoBuscaProdutosModel BuscaPaginada(RequisicaoBuscaProdutosModel requisicao)
        {
            var produtos = _produtoService.GetAll();            

            if (!string.IsNullOrEmpty(requisicao.filtroNome) || requisicao.filtroId > 0)
            {
                produtos = requisicao.filtroId > 0 ?
                    produtos.Where(p => p.Id == requisicao.filtroId).ToList() :
                    produtos.Where(p => p.Nome.Contains(requisicao.filtroNome)).ToList();
            }

            var itensBusca = new ResultadoBuscaPaginadaModel()
            {
                paginaAtual = requisicao.RequisicaoBuscaPaginadaModel.paginaAtual,
                totalItens = produtos.Count(),
                totalPaginas = (int)Math.Ceiling(produtos.Count() / (double)requisicao.RequisicaoBuscaPaginadaModel.itensPorPagina)
            };
            var produtoDto = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
            var ListaItens = new ResultadoBuscaProdutosModel()
            {
                paginacao = itensBusca,
                items = produtoDto.Skip((requisicao.RequisicaoBuscaPaginadaModel.paginaAtual - 1) * requisicao.RequisicaoBuscaPaginadaModel.itensPorPagina).Take(requisicao.RequisicaoBuscaPaginadaModel.itensPorPagina).ToList()
            };
            
            return ListaItens;
        }

        public IEnumerable<ProdutoDTO> GetAll()
        {
            var produto = _produtoService.GetAll();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produto);
        }

        public ProdutoDTO GetById(long id)
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

        public List<ValidationFailure> ValidarModel(ProdutoDTO produtoDto)
        {
            ProdutoDTOIncluirValidator validator = new ProdutoDTOIncluirValidator();

            var validatorModel = validator.Validate(produtoDto);
            return validatorModel.Errors;
        }
    }
}
