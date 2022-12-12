using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Bussines.Entities
{
    public class ItensPedido
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Pedido do Item do produto é obrigatório!")]
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }
        public int IdProduto { get; set; }
        public Pedido Pedido { get; set; }
        public int IdPedido { get; set; }

    }
}
