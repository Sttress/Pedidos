using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Bussines.Entities;
using Pedidos.Filters;
using Pedidos.Infraestruture.Data;
using Pedidos.Models.Usuario;
using Pedidos.Models;
using Pedidos.Models.Pedido;
using Pedidos.Bussines.DTO;
using Pedidos.Bussines.Repositories;
using System.Text.Encodings.Web;

namespace Pedidos.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoContext _db;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(PedidoContext db,IPedidoRepository pedidoRepository)
        {
            _db = db;
            _pedidoRepository = pedidoRepository;
        }
        /// <summary>
        /// Retorna um pedido
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [ProducesResponseType(typeof(JsonPedidoDTO), 200)]
        [ProducesResponseType(typeof(ValidaCampos), 400)]
        [ProducesResponseType(typeof(ErroGenerico), 500)]
        [HttpGet]
        [Route("")]
        public JsonPedidoDTO Get(int Id)
        {
            var modelo = _pedidoRepository.GetPedido(Id);
            return modelo;
        }
        /// <summary>
        /// Criar um novo pedido
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(PedidoViewModelInput), 200)]
        [ProducesResponseType(typeof(ValidaCampos), 400)]
        [ProducesResponseType(typeof(ErroGenerico), 500)]
        [HttpPost]
        [Route("create")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Create(PedidoViewModelInput modelo)
        {
            try
            {
                _pedidoRepository.Add(modelo);
                _pedidoRepository.Commit();

                return Created("",modelo);
            }
            catch
            {
                return BadRequest("Não foi possivel gravar um novo pedido");
            }
        }
        /// <summary>
        /// editar um pedido
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Pedido), 200)]
        [ProducesResponseType(typeof(ValidaCampos), 400)]
        [ProducesResponseType(typeof(ErroGenerico), 500)]
        [HttpPut]
        [Route("edit")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Edit(Pedido modelo)
        {
            try
            {
                _pedidoRepository.Edit(modelo);
                _pedidoRepository.Commit();
                return Ok(modelo);
            }
            catch
            {
                return BadRequest("Ouve um problema ao editar o pedido selecionado");
            }
        }
        /// <summary>
        /// exluir um pedido
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
                _pedidoRepository.Remove(Id);
                _pedidoRepository.Commit();
                return Ok();
            }
            catch
            {
                return BadRequest("Ouve um problema ao editar o pedido selecionado");
            }
        }
    }
}
