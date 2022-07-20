using Microsoft.AspNetCore.Mvc;
using Produtos.Application.DTO;
using Produtos.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Produtos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : Controller
    {
        private readonly IApplicationProdutoService _applicationServiceProduto;       
        public ProdutosController(IApplicationProdutoService applicationServiceProduto)
        {
            _applicationServiceProduto = applicationServiceProduto;            
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok(_applicationServiceProduto.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            return Ok(_applicationServiceProduto.GetById(id));
        }

        [HttpPost("BuscaPaginada")]
        public ActionResult BuscaPaginada([FromBody] RequisicaoBuscaProdutosModel requisicao)
        {
            return Ok(_applicationServiceProduto.BuscaPaginada(requisicao));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                List<string> Errors = new List<string>();
                var validarModel = _applicationServiceProduto.ValidarModel(produtoDTO);

                if(validarModel.Count > 0)
                {
                    foreach (var erros in validarModel)
                        Errors.Add(erros.ErrorMessage);

                    return BadRequest(Errors);
                }

                if (produtoDTO == null)
                    return NotFound();

                if (produtoDTO.Id > 0)
                    _applicationServiceProduto.Update(produtoDTO);

                _applicationServiceProduto.Add(produtoDTO);

                return Ok(produtoDTO.Id > 0 ? "Produto atualizado com sucesso" : "Produto cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                List<string> Errors = new List<string>();
                var validarModel = _applicationServiceProduto.ValidarModel(produtoDTO);

                if (produtoDTO.Id <= 0)
                    return BadRequest("Informe o id do produto");

                if (validarModel.Count > 0)
                {
                    foreach (var erros in validarModel)
                        Errors.Add(erros.ErrorMessage);

                    return BadRequest(Errors);
                }             

                _applicationServiceProduto.Update(produtoDTO);
                return Ok("Produto atualizado com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var produtoDTO = _applicationServiceProduto.GetById(id);

                if (produtoDTO == null)
                    return NotFound();

                _applicationServiceProduto.Remove(produtoDTO);
                return Ok("Produto excluido com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
