using System.ComponentModel.DataAnnotations;

namespace Pedidos.Models.Pedido
{
    public class PedidoViewModelInput
    {
        [Required(ErrorMessage = "Campo Nome do Cliente é obrigatório!")]
        [StringLength(60, ErrorMessage = "O Nome do Cliente deve ter no máximo 60 caracteres")]
        public string NomeCliente { get; set; }
        [Required(ErrorMessage = "Campo Email do Cliente é obrigatório!")]
        [StringLength(60, ErrorMessage = "O Email do Cliente deve ter no máximo 60 caracteres")]
        public string EmailCliente { get; set; }
        [Required(ErrorMessage = "Campo Data de Criação é obrigatório!")]
        public DateTime DataCriacao { get; set; }
        [Required(ErrorMessage = "Campo Pago é obrigatório!")]
        public bool Pago { get; set; }

    }
}
