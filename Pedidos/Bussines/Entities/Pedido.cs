using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Bussines.Entities
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
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
        public ICollection<ItensPedido> ItensPedido { get; set; }
    }
}
