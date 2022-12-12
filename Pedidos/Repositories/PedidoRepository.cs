using Microsoft.EntityFrameworkCore;
using Pedidos.Bussines.DTO;
using Pedidos.Bussines.Entities;
using Pedidos.Bussines.Repositories;
using Pedidos.Infraestruture.Data;
using Pedidos.Models.Pedido;

namespace Pedidos.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {

        private readonly PedidoContext _db;

        public PedidoRepository(PedidoContext db)
        {
            _db = db;
        }

        public void Add(PedidoViewModelInput modelo)
        {
            try
            {
                var pedido = new Pedido();
                pedido.NomeCliente = modelo.NomeCliente;
                pedido.EmailCliente = modelo.EmailCliente;
                pedido.DataCriacao = modelo.DataCriacao;
                pedido.Pago = modelo.Pago;
                _db.Add(pedido);
            }
            catch
            {
                throw new Exception("Falha ao criar um novo pedido");
            }

        }

        public void Commit()
        {
            try
            {
                _db.SaveChanges();

            }
            catch
            {
                throw new Exception("Falha ao salvar no banco de dados");
            }
        }

        public void Edit(Pedido modelo)
        {
            try
            {
                var pedido = _db.PEDIDO.Where(e => e.Id == modelo.Id).FirstOrDefault();
                pedido.NomeCliente = modelo.NomeCliente;
                pedido.EmailCliente = modelo.EmailCliente;
                pedido.DataCriacao = modelo.DataCriacao;
                pedido.Pago = modelo.Pago;
                _db.Entry(pedido).State = EntityState.Modified;
            }
            catch
            {
                throw new Exception("Falha ao editar o pedido selecionado");
            }

        }

        public JsonPedidoDTO GetPedido(int Id)
        {
            try
            {
                var modelo = new JsonPedidoDTO();
                var pedido = _db.PEDIDO.Where(e => e.Id == Id).FirstOrDefault();
                modelo.Id = pedido.Id;
                modelo.NomeCliente = pedido.NomeCliente;
                modelo.EmailCliente = pedido.EmailCliente;
                modelo.Pago = pedido.Pago;
                modelo.ValorTotal = 0;
                var itens = new List<ItensPedidoDTO>();
                if (pedido.ItensPedido is object)
                {
                    foreach (var item in pedido.ItensPedido)
                    {
                        var itemPedido = new ItensPedidoDTO()
                        {
                            Id = item.Id,
                            IdProduto = item.Produto.Id,
                            NomeProduto = item.Produto.NomeProduto,
                            ValorUnitario = item.Produto.Valor,
                            Quantidade = item.Quantidade
                        };
                        itens.Add(itemPedido);
                    }
                    modelo.Itens = itens;

                }
                else
                {
                    var item = new ItensPedidoDTO()
                    {
                        Id = 0,
                        IdProduto = 0,
                        NomeProduto = "",
                        ValorUnitario = 0,
                        Quantidade = 0
                    };

                    modelo.Itens.Add(item);
                }

                return modelo;
            }
            catch
            {
                throw new Exception("Falha ao contruir o Json de Pedidos !");
            }
            
        }

        public void Remove(int Id)
        {
            try
            {
                var pedido = _db.PEDIDO.Where(e => e.Id == Id).FirstOrDefault();
                _db.Remove(pedido);
            }
            catch
            {
                throw new Exception("Falha ao excluir o pedido selecionado");
            }

        }
    }
}
