using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Bussines.Entities;
using Pedidos.Filters;
using Pedidos.Infraestruture.Data;
using Pedidos.Models;
using Pedidos.Models.Usuario;

namespace Pedidos.Controllers
{

    [Route("api/v1/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly PedidoContext _db;

        public ProdutoController(PedidoContext db)
        {
            _db = db;
        }
        /// <summary>
        /// retorna uma lista de produtos
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<Produto>), 200)]
        [ProducesResponseType(typeof(ValidaCampos), 400)]
        [ProducesResponseType(typeof(ErroGenerico),500)]
        [HttpGet]
        [Route("list")]
        public IActionResult GetList()
        {
            try
            {
                var produtos = _db.PRODUTO.ToList();
                return Ok(produtos);
            }
            catch
            {
                return BadRequest("Ouve um problema ao buscar a lista de Produtos");
            }
        }
        /// <summary>
        /// Criar um novo produto
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ProdutoViewModelInput),200)]
        [ProducesResponseType(typeof(ValidaCampos),400)]
        [ProducesResponseType(typeof(ErroGenerico), 500)]
        [HttpPost]
        [Route("create")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Create(ProdutoViewModelInput modelo)
        {
            try
            {
                var produto = new Produto();
                produto.NomeProduto = modelo.NomeProduto;
                produto.Valor = modelo.Valor;
                _db.Add(produto);
                _db.SaveChanges();
                return Created("", produto);
            }
            catch
            {
                return BadRequest("Não foi possivel gravar um novo produto");
            }
        }
        /// <summary>
        /// edita um produto
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Produto), 200)]
        [ProducesResponseType(typeof(ValidaCampos), 400)]
        [ProducesResponseType(typeof(ErroGenerico), 500)]
        [HttpPut]
        [Route("edit")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Edit(Produto modelo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ValidaCampos(ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage)));
                }
                var produto = _db.PRODUTO.Where(e => e.Id == modelo.Id).FirstOrDefault();
                produto.NomeProduto = modelo.NomeProduto;
                produto.Valor = modelo.Valor;
                _db.Entry(produto).State = EntityState.Modified;
                _db.SaveChanges();
                return Ok(produto);
            }
            catch
            {
                return BadRequest("Ouve um problema ao editar o produto selecionado");
            }
        }
        /// <summary>
        /// exclui um produto
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ValidaCampos), 400)]
        [ProducesResponseType(typeof(ErroGenerico), 500)]
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(int Id)
        {
            try
            {
                var produto = _db.PRODUTO.Where(e => e.Id == Id).FirstOrDefault();
                _db.Remove(produto);
                _db.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest("Ouve um problema ao editar o produto selecionado");
            }
        }
    }
}
